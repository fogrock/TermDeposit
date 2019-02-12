using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TermDepositsLibrary;
using TermDeposit;

namespace TermDeposit.Tests.LibraryTest
{
    [TestClass]
    public class LibraryTest
    {
        const int mn = 1000000;
        [TestMethod]
        public void GetIntRandom()
        {
            // Arrange
            int min = 1;
            int max = 3;

            // Act
            int result = TermDepositsLibrary.Utility.GetIntRandom(min, max);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result >= min && result <= max);
        }
        [TestMethod]
        public void GetDoulbeRandom()
        {
            // Arrange
            double min = 1;
            double max = 1.02;

            // Act
            double result = TermDepositsLibrary.Utility.GetDoubleRandom(min, max);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result >= min && result <= max);
        }

        [TestMethod]
        public void GetTermDeposit()
        {
            // Arrange
            var tdp = new TDPortfolio();
            double min = 1 * mn;
            double max = 3 * mn;
            double minL = 3 * mn;
            double maxL = 5 * mn;
            // Act
            var result = tdp.GetTermDeposit(min, max);
            var resultLarge = tdp.GetTermDeposit(minL, maxL, true);

            //// Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(resultLarge);
            Assert.IsTrue(result.principal >= min);
            Assert.IsTrue(result.principal <= max);
            Assert.IsTrue(resultLarge.maturityAmount >= minL);
            Assert.IsTrue(resultLarge.maturityAmount <= maxL);
        }

        [TestMethod]
        public void GetTDPortfolio()
        {
            // Arrange                        

            int count = 50;
            double minTotalMV = 70 * mn;
            double maxTotalMV = 100 * mn;

            // Act
            var result = new TDPortfolio();

            // Assert
            Assert.IsTrue(result.GetPortfolioMV() >= minTotalMV);
            Assert.IsTrue(result.GetPortfolioMV() <= maxTotalMV);
            Assert.IsTrue(result.holdngsList.Count == count);
            Assert.IsNotNull(result);
        }
    }
}

