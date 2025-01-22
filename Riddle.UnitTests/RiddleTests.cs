using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Riddle.UnitTests
{
    [TestClass]
    public class RiddleTests
    {
        private Riddle _riddle;

        [TestInitialize]
        public void Init()
        {
            _riddle = new Riddle(1, 100);
        }

        [TestMethod]
        [DataRow("50")]
        [DataRow("1")]
        [DataRow("100")]
        public void Guess_WithValidNumber_ReturnsCorrectHintOrSuccess(string guess)
        {
            var result = _riddle.Guess(guess);

            Assert.IsTrue(result == "Plus haut !" || result == "Plus bas !" || result == "Correct !");
        }

        [TestMethod]
        [DataRow("-1")]
        [DataRow("0")]
        [DataRow("101")]
        public void Guess_WithNumberOutOfRange_ReturnsErrorMessage(string guess)
        {
            var result = _riddle.Guess(guess);

            Assert.AreEqual("Veuillez deviner un nombre entre 1 et 100.", result);
        }

        [TestMethod]
        [DataRow("abc")]
        [DataRow("!@#")]
        [DataRow("")]
        public void Guess_WithInvalidInput_ReturnsValidationError(string input)
        {
            var result = _riddle.Guess(input);

            Assert.AreEqual("Veuillez entrer un nombre valide.", result);
        }

        [TestMethod]
        public void Guess_WhenGuessEqualsSecretNumber_ReturnsCorrect()
        {
            var secretNumberField = typeof(Riddle).GetField("_secretNumber", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            secretNumberField.SetValue(_riddle, 51);

            var result = _riddle.Guess("50");

            Assert.AreEqual("Correct !", result);
        }

        [TestMethod]
        public void Guess_WhenGuessLowerThanSecretNumber_ReturnsHigherHint()
        {
            var secretNumberField = typeof(Riddle).GetField("_secretNumber", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            secretNumberField.SetValue(_riddle, 26);

            var result = _riddle.Guess("25");

            Assert.AreEqual("Plus haut !", result);
        }

        [TestMethod]
        public void Guess_WhenGuessHigherThanSecretNumber_ReturnsLowerHint()
        {
            var secretNumberField = typeof(Riddle).GetField("_secretNumber", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            secretNumberField.SetValue(_riddle, 50);

            var result = _riddle.Guess("75");

            Assert.AreEqual("Plus bas !", result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_WithInvalidRange_ThrowsException()
        {
            var invalidRiddle = new Riddle(10, 5);
        }
    }
}