using NUnit.Framework;

namespace CodeWarsExercise.Test
{
    public class Tests
    {
        private readonly RomanNumeralDecoder _romanNumeralDecoder = new();

        [SetUp]
        public void Setup()
        {
        }

        [TestCase("I", 1)]
        [TestCase("IV", 4)]
        [TestCase("XXIX", 29)]
        [TestCase("CXLIX", 149)]
        [TestCase("CCC", 300)]
        [TestCase("DXLIX", 549)]
        [TestCase("DCCCXXXIII", 833)]
        [TestCase("CMXLIX", 949)]
        [TestCase("MCMXCIV", 1994)]
        [TestCase("MMCDXCIV", 2494)]
        [TestCase("MMCDLXXXIII", 2483)]
        [TestCase("MMM", 3000)]
        [TestCase("MMMCDXCIV", 3494)]
        [TestCase("MMMDCLIX", 3659)]
        [TestCase("MMMCMLVII", 3957)]
        [TestCase("MMMCMXCIX", 3999)]
        public void RomanNumeralDecoderSuccessful(string romanNumberal, int decodedNumber)
        {
            var test_pass = _romanNumeralDecoder.TryDecodeRomanNumber(romanNumberal, out int testNumber);
            Assert.IsTrue(test_pass);
            Assert.AreEqual(decodedNumber, testNumber);
        }

        [TestCase("XVXI", 6)]
        [TestCase("IL", 49)]
        [TestCase("CIL", 149)]
        [TestCase("DIL", 549)]
        [TestCase("MMMM", 4000)]
        public void RomanNumeralDecoderFailed(string romanNumberal, int decodedNumber)
        {
            var test_failed = _romanNumeralDecoder.TryDecodeRomanNumber(romanNumberal, out int testNumber);
            Assert.IsFalse(test_failed);
            Assert.AreNotEqual(decodedNumber, testNumber);
        }
    }
}