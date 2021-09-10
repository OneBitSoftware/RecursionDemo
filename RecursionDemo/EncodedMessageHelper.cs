namespace RecursionDemo
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
    using System.Text.RegularExpressions;

    public static class EncodedMessageHelper
    {
        public static IEnumerable<string> GetSecretCodeVariations(string secretCode)
        {
            // method parameter validation
            if (string.IsNullOrWhiteSpace(secretCode))
            {
                throw new System.ArgumentException($"'{nameof(secretCode)}' cannot be null or whitespace.", nameof(secretCode));
            }

            // First exit condition on a 0 or 1 length string
            if (secretCode.Length <= 1)
            {
                yield return secretCode;
                yield break;
            }

            // Get and keep the current iteration character, then remove it.
            // I am using long variable names to assist with readability.
            var currentIterationCharacter = secretCode[0];
            var stringAfterRemovingTheCurrentIterationCharacter = secretCode.Remove(0, 1);
            
            // Proceed with recursion
            var recursionResult = GetSecretCodeVariations(stringAfterRemovingTheCurrentIterationCharacter);

            foreach (var rest in recursionResult)
            {
                yield return string.Concat(currentIterationCharacter, rest);
                yield return $"{currentIterationCharacter} {rest}";
            }
        }

        public static IDictionary<string, string> GetCipherVariations(string keyInput)
        {
            if (string.IsNullOrWhiteSpace(keyInput))
            {
                throw new System.ArgumentException($"'{nameof(keyInput)}' cannot be null or whitespace.", nameof(keyInput));
            }

            var chipher = new Dictionary<string, string>(capacity: keyInput.Length);
            var pattern = new Regex("([A-Z])([0-9]+)");

            foreach (Match match in pattern.Matches(keyInput))
            {
                string matchString = match.Value;
                char value = matchString[0]; // Retrieves the letter
                string key = matchString.Substring(1); // Retrieves the numbers after the letter
                if (!chipher.ContainsKey(key))
                {
                    chipher[key] = value.ToString();
                }
            }

            return chipher;
        }

        public static IEnumerable<string> ExecuteCipherLogic(string secretCode, string cipher)
        {
            var codeVariationsEnumerable = EncodedMessageHelper.GetSecretCodeVariations(secretCode);
             // var list = codeVariationsEnumerable.ToList(); // Do not materialize here

            var cipherVariations = EncodedMessageHelper.GetCipherVariations(cipher);

            var possibleMessages = new List<string>(capacity: cipher.Length);

            foreach (var combination in codeVariationsEnumerable)
            {
                var stringValue = string.Empty;
                
                foreach (var currentCombination in combination.Split())
                {
                    if (!cipherVariations.ContainsKey(currentCombination))
                    {
                        if (stringValue.Length > 0)
                        {
                            stringValue = string.Empty;
                        }

                        break;
                    }
                    else
                    {
                        stringValue = $"{stringValue}{cipherVariations[currentCombination]}";
                    }
                }

                if (stringValue.Length > 0)
                {
                    possibleMessages.Add(stringValue);
                }
            }

            return possibleMessages;
        }
    }
}
