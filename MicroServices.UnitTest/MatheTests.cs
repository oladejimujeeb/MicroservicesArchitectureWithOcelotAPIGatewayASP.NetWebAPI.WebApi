using NUnit.Framework;
using Product.Microservice.Implementation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = NUnit.Framework.Assert;

namespace MicroServices.UnitTest
{
    [TestFixture]
    public class MatheTests
    {
        private Mathe _mathe;
        //Setup
        [SetUp]
        public void Setup()
        {
            _mathe = new Mathe();
        }
       
        [Test]
        public void Add_WhenCalled_ReturnSumOfArguments()
        {
            //Arrage  
            var math = new Mathe();

            //Act
            var result = math.Add(1,2);

            // Assert
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        [TestCase(3,1,3)]
        [TestCase(1,2,2)]
        [TestCase(1,1,1)]
        public void Max_WhenCalled_ReturnTheGreaterArgument(int a, int b, int expectedResult)
        {
            //var math = new Mathe();

            var result = _mathe.Max(a, b);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        /*[Test]
        public void Max_SecondArgumentIsGreater_ReturnSecondArgument()
        {
            //var math = new Mathe();

            var result = _mathe.Max(4, 9);

            Assert.That(result, Is.EqualTo(9));
        }
        [Test]
        public void Max_ArgumentAreEqual_ReturnSameArgument()
        {
            //var math = new Mathe();

            var result = _mathe.Max(4, 4);

            Assert.That(result, Is.EqualTo(4));
        }*/

        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToLimit()
        {
            var result = _mathe.GetOddNumbers(5);

            //Assert.That(result, Is.Not.Null);

            Assert.That(result.Count, Is.EqualTo(3));

            Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5 }));
        }
    }
}
