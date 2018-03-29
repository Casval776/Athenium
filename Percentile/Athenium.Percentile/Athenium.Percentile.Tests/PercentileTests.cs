using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Athenium.Percentile.Tests
{
    [TestClass]
    public class PercentileTests
    {
        [TestMethod]
        public void FirstPercentileTest()
        {
            //Arrange
            var scores = new List<int>();
            scores.AddRange(new List<int> { 72, 5, 26, 27, 55, 39, 79, 84, 59, 19, 9, 57, 10, 12, 93, 55 });

            //Act
            var results = PercentileHelper.Percentile(scores);

            //Assert
            if (!(new List<int> { 72, 79, 84, 93 }).SequenceEqual(results['A'])) throw new Exception("Test Failed");
            if (!(new List<int> { 55, 55, 57, 59 }).SequenceEqual(results['B'])) throw new Exception("Test Failed");
            if (!(new List<int> { 27, 39 }).SequenceEqual(results['C'])) throw new Exception("Test Failed");
            if (!(new List<int> { 12, 19, 26 }).SequenceEqual(results['D'])) throw new Exception("Test Failed");
            if (!(new List<int> { 5, 9, 10 }).SequenceEqual(results['F'])) throw new Exception("Test Failed");
        }

        [TestMethod]
        public void ThirdPercentileTest()
        {
            //Arrange
            var scores = new List<int>() { 99, 92, 91, 91, 89, 85, 83, 82, 80, 79, 78, 78, 77, 76, 75, 74, 62, 55, 43, 20 };

            //Act
            var results = PercentileHelper.Percentile(scores);

            //Assert
            if (!(new List<int> { 91, 91, 92, 99 }).SequenceEqual(results['A'])) throw new Exception("Test Failed");
            if (!(new List<int> { 82, 83, 85, 89 }).SequenceEqual(results['B'])) throw new Exception("Test Failed");
            if (!(new List<int> { 78, 78, 79, 80 }).SequenceEqual(results['C'])) throw new Exception("Test Failed");
            if (!(new List<int> { 74, 75, 76, 77 }).SequenceEqual(results['D'])) throw new Exception("Test Failed");
            if (!(new List<int> { 20, 43, 55, 62 }).SequenceEqual(results['F'])) throw new Exception("Test Failed");
        }
    }
}
