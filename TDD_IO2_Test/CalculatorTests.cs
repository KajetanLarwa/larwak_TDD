using System;
using TDD_IO2;
using Xunit;

namespace TDD_IO2_Test
{
    public class CalculatorTests
    {
        private readonly StringCalculator _calculator;

        public CalculatorTests()
        {
            _calculator = new StringCalculator();
        }
        
        [Fact]
        public void WhenEmptyString_ThenReturnsZero()
        {
            var result = _calculator.Add("");
            
            Assert.Equal(0, result);
        }
        
        [Theory]
        [InlineData(2)]
        [InlineData(7)]
        public void WhenSingleNumber_ThenReturnsValue(int expected)
        {
            var result = _calculator.Add($"{expected}");
            
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void WhenTwoNumbersCommaDelimited_ThenReturnsSum()
        {
            var number1 = 2;
            var number2 = 3;
            var expected = 5;

            var result = _calculator.Add($"{number1},{number2}");
            
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void WhenTwoNumbersNewlineDelimited_ThenReturnsSum()
        {
            var number1 = 2;
            var number2 = 3;
            var expected = 5;

            var result = _calculator.Add($"{number1}\n{number2}");
            
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void WhenThreeNumbersCommaOrNewlineDelimited_ThenReturnsSum()
        {
            var number1 = 2;
            var number2 = 3;
            var number3 = 4;
            var expected = 9;

            var result = _calculator.Add($"{number1}\n{number2},{number3}");
            
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void WhenNegativeNumber_ThenThrowArgumentOufOfRangeException()
        {
            var number1 = 2;
            var number2 = 3;
            var number3 = -4;

            Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Add($"{number1}\n{number2},{number3}"));
        }
        
        [Fact]
        public void WhenNumberGreaterThan1000_ThenIgnoreIt()
        {
            var number1 = 2;
            var number2 = 1001;
            var number3 = 4;
            var expected = 6;

            var result = _calculator.Add($"{number1}\n{number2},{number3}");
            
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void WhenSingleCharDelimiterDefined_ThenReturnsSum()
        {
            var number1 = 2;
            var number2 = 3;
            var number3 = 4;
            var expected = 9;

            var result = _calculator.Add($"//#{number1}#{number2}#{number3}");
            
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void WhenMultiCharDelimiterDefined_ThenReturnsSum()
        {
            var number1 = 2;
            var number2 = 3;
            var number3 = 4;
            var expected = 9;

            var result = _calculator.Add($"//[###]{number1}###{number2}###{number3}");
            
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void WhenMultiOrSingleCharDelimitersDefined_ThenReturnsSum()
        {
            var number1 = 2;
            var number2 = 3;
            var number3 = 4;
            var expected = 9;

            var result = _calculator.Add($"//[*][###]{number1}###{number2}*{number3}");
            
            Assert.Equal(expected, result);
        }
    }
}