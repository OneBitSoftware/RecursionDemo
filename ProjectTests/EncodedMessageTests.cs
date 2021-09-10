using RecursionDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ProjectTests
{
    public class EncodedMessageTests
    {
        [Fact]
        public void GetEncodedMessage_ShouldNotBeEmpty()
        {
            // Assert
            Assert.Throws<ArgumentException>(() => EncodedMessageHelper.GetSecretCodeVariations(string.Empty).ToArray());
        }

        [Fact]
        public void GetEncodedMessage_ShouldReturnA()
        {
            // Arrange

            // Act
            var getResult = EncodedMessageHelper.GetSecretCodeVariations("A");

            // Assert
            Assert.NotEmpty(getResult);
            Assert.Single(getResult);
            Assert.Equal("A", getResult.First());
        }

        [Fact]
        public void GetEncodedMessage_ShouldReturnABC()
        {
            // Arrange

            // Act
            var getResult = EncodedMessageHelper.GetSecretCodeVariations("ABC");

            // Assert
            var currentResultArray = getResult.ToArray();

            Assert.NotEmpty(getResult);
            Assert.Equal("ABC", currentResultArray[0]);
            Assert.Equal("A BC", currentResultArray[1]);
            Assert.Equal("AB C", currentResultArray[2]);
            Assert.Equal("A B C", currentResultArray[3]);
        }

        [Fact]
        public void GetEncodedMessage_ShouldReturn123Sequence()
        {
            // Arrange

            // Act
            var getResult = EncodedMessageHelper.GetSecretCodeVariations("123");

            // Assert
            var currentResultArray = getResult.ToArray();

            Assert.NotEmpty(getResult);
            Assert.Equal("123", currentResultArray[0]);
            Assert.Equal("1 23", currentResultArray[1]);
            Assert.Equal("12 3", currentResultArray[2]);
            Assert.Equal("1 2 3", currentResultArray[3]);
        }

        [Fact]
        public void GetEncodedMessage_ShouldReturn1234Sequence()
        {
            // Arrange

            // Act
            var getResult = EncodedMessageHelper.GetSecretCodeVariations("1234");

            // Assert
            var currentResultArray = getResult.ToArray();

            Assert.NotEmpty(getResult);
            Assert.Equal("1234", currentResultArray[0]);
            Assert.Equal("1 234", currentResultArray[1]);
            Assert.Equal("12 34", currentResultArray[2]);
            Assert.Equal("1 2 34", currentResultArray[3]);
            Assert.Equal("123 4", currentResultArray[4]);
            Assert.Equal("1 23 4", currentResultArray[5]);
            Assert.Equal("12 3 4", currentResultArray[6]);
            Assert.Equal("1 2 3 4", currentResultArray[7]);
        }

        [Fact]
        public void GetStringCharacters_CanYield()
        {
            // Arrange

            // Act
            var getResult = this.GetStringCharactersOneByOne();

            // Assert
            getResult.ToList();
            Assert.NotEmpty(getResult);
        }

        [Fact]
        public void TestCipherLogicInput1_ShouldReturnAllValidOptions()
        {
            // Arrange
            string secretCode = "1122";
            string cipher = "A1B12C11D2";

            // Act
            var result = EncodedMessageHelper.ExecuteCipherLogic(secretCode, cipher).ToList();

            // Assert
            Assert.Equal(3, result.Count());
            Assert.Contains("ABD", result);
            Assert.Contains("AADD", result);
            Assert.Contains("CDD", result);
        }

        private IEnumerable<string> GetStringCharactersOneByOne()
        {
            yield return "A";
            yield return "B";
            yield return "C";
            yield return "D";
            yield return "E";
        }

        private string GetStringCharacters(string passedString)
        {
            return "A";
            return "B"; // this code cannot be reached
            return "C"; // this code cannot be reached
        }
    }
}
