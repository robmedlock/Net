using ClassLibrary.Util;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ClassLibrary.Test.Util
{
    public class MathsTest
    {
        [Fact]
        public void Factorial_ShouldReturnCorrectValues()
        {
            //act
            double actual = Maths.Factorial(5);
            //assert
            Assert.Equal(120, actual);
        }

        [Theory]
        [InlineData(3, 6)]
        [InlineData(6, 720)]
        public void Factorial_ParameterizedTest(int n, double expected)
        {
            //act
            double actual = Maths.Factorial(n);
            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Factorial_NegativeArgument_ShouldThrowArgumentOutOfRangeException()
        {
            //act
            //assert
            Assert.Throws<ArgumentOutOfRangeException>(() => Maths.Factorial(-1));
        }

        [Theory]
        [InlineData(10, 2, 45)]
        [InlineData(52, 4, 270725)]
        public void Combination_ParameterizedTest(int n, int r, double expected)
        {
            //act
            double actual = Maths.Combination(n, r);
            //assert
            Assert.Equal(expected, actual, 5); //precision in decimal places
        }

        [Fact]
        public void Fibonacci_ShouldReturnCorrectSequence()
        {
            int[] expected = { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 };
            int[] actual = Maths.Fibonacci(10);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1e1, 4)]
        [InlineData(1e2, 25)]
        [InlineData(1e3, 168)]
        [InlineData(1e4, 1229)]
        [InlineData(1e5, 9592)]
        [InlineData(1e6, 78498)]
        [InlineData(1e7, 664579)]
        public async void PrimeCountAsyncTest(int limit, int count)
        {
            //act
            int actual = await Maths.PrimeCountAsync(limit);
            //assert
            Assert.Equal(count, actual);
        }


    }
}
