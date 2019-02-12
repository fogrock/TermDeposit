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

            // Act
            var result = TermDepositsLibrary.TDPortfolio.GetTermDeposit();
            var resultLarge = TermDepositsLibrary.TDPortfolio.GetTermDeposit(true);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(resultLarge);
        }

        [TestMethod]
        public void GetTDPortfolio()
        {
            // Arrange                        

            // Act
            var result = TermDepositsLibrary.TDPortfolio.GetTDPortfolio();           

            // Assert
            Assert.IsNotNull(result);            
        }
    }
}

