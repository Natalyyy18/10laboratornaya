using ClassLibrary10;
using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using Microsoft.Analytics.UnitTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace USqlCSharpUdoUnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestToString()
        {
            // Arrange
            IdNumber id = new IdNumber(42);

            // Act
            string result = id.ToString();

            // Assert
            Assert.AreEqual("42", result);
        }
        [TestMethod]
        public void TestEquals()
        {
            // Arrange
            IdNumber id1 = new IdNumber(42);
            IdNumber id2 = new IdNumber(42);
            IdNumber id3 = new IdNumber(24);

            // Act & Assert
            Assert.IsTrue(id1.Equals(id2));
            Assert.IsFalse(id1.Equals(id3));
        }

        [TestMethod]
        public void TestNumberSetter()
        {
            // Arrange
            BankCard card = new BankCard();

            // Act
            card.Number = -10;

            // Assert
            Assert.AreEqual(0, card.Number);
        }
        [TestMethod]
        public void TestNumberGetter()
        {
            // Arrange
            BankCard card = new BankCard();
            card.Number = 100;

            // Act
            int result = card.Number;

            // Assert
            Assert.AreEqual(100, result);
        }

        [TestMethod]
        public void TestNameSetter()
        {
            // Arrange
            BankCard card = new BankCard();

            // Act
            card.Name = "John";

            // Assert
            Assert.AreEqual("John", card.Name);
        }
        [TestMethod]
        public void TestNameGetter()
        {
            // Arrange
            BankCard card = new BankCard();
            card.Name = "John";

            // Act
            string result = card.Name;

            // Assert
            Assert.AreEqual("John", result);
        }
        [TestMethod]
        public void Compare_WhenComparingTwoBankCardsWithDifferentNumbers_ShouldReturnCorrectResult()
        {
            BankCard card1 = new BankCard();
            card1.Number = 1234;
            BankCard card2 = new BankCard();
            card2.Number = 5678;

            int result = card1.Compare(card1, card2);

            Assert.AreEqual(-1, result);
        }
        [TestMethod]
        public void Clone_WhenCloningBankCard_ShouldCreateNewInstanceWithSameProperties()
        {
            BankCard originalCard = new BankCard();
            originalCard.Number = 1234;
            originalCard.Name = "OriginalCard";
            originalCard.Term = DateTime.Now;

            BankCard clonedCard = (BankCard)originalCard.Clone();

            Assert.AreEqual(originalCard.Number, clonedCard.Number);
            Assert.AreEqual(originalCard.Name, clonedCard.Name);
            Assert.AreEqual(originalCard.Term, clonedCard.Term);
        }
        [TestMethod]
        public void CompareTo_WhenComparingTwoBankCardsWithDifferentNames_ShouldReturnCorrectResult()
        {
            BankCard card1 = new BankCard();
            card1.Name = "Card1";
            BankCard card2 = new BankCard();
            card2.Name = "Card2";
            int result = card1.CompareTo(card2);

            Assert.AreEqual(-1, result);
        }
        [TestMethod]
        public void DebitCard_Constructor_DefaultBalanceIsZero()
        {
            // Arrange
            DebitCard debitCard = new DebitCard();
            // Act
            double balance = debitCard.GetBalance();

            // Assert
            Assert.AreEqual(0, balance);
        }
        [TestMethod]
        public void DebitCard_Constructor_InitialBalanceSetCorrectly()
        {
            // Arrange
            int number = 1234;
            string name = "John Doe";
            DateTime term = DateTime.Today;
            double balance = 100.50;
            int number1 = 5678;

            // Act
            DebitCard debitCard = new DebitCard(number, name, term, balance, number1);

            // Assert
            Assert.AreEqual(number, debitCard.Number);
            Assert.AreEqual(name, debitCard.Name);
            Assert.AreEqual(term, debitCard.Term);
            Assert.AreEqual(balance, debitCard.GetBalance());
            //Assert.AreEqual(number1, debitCard.GetNumber1());
        }
        [TestMethod]
        public void DebitCard_Equals_ReturnsTrueIfEqual()
        {
            // Arrange
            DebitCard card1 = new DebitCard(1234, "John Doe", DateTime.Today, 100.50, 5678);
            DebitCard card2 = new DebitCard(1234, "John Doe", DateTime.Today, 100.50, 5678);

            // Act
            bool result = card1.Equals(card2);

            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void testCashbackPositiveValue()
        {
            YoungCard card = new YoungCard();
            card.Cashback = 5.5;
            Assert.AreEqual(5.5, card.Cashback, 0.01);
        }
        [TestMethod]
        public void testCashbackNegativeValue()
        {
            YoungCard card = new YoungCard();
            card.Cashback = -3.0;
            Assert.AreEqual(0, card.Cashback, 0.01);
        }
        [TestMethod]
        public void testEquals()
        {
            YoungCard card1 = new YoungCard(1, "Alice", new DateTime(2022, 12, 31), 100.0, 5.0, 123456);
            YoungCard card2 = new YoungCard(1, "Alice", new DateTime(2022, 12, 31), 100.0, 5.0, 123456);
            Assert.IsTrue(card1.Equals(card2));
        }
        [TestMethod]
        public void testNotEquals()
        {
            YoungCard card1 = new YoungCard(1, "Alice", new DateTime(2022, 12, 31), 100.0, 5.0, 123456);
            YoungCard card2 = new YoungCard(2, "Bob", new DateTime(2023, 1, 1), 150.0, 7.0, 654321);
            Assert.IsFalse(card1.Equals(card2));
        }
        [TestMethod]
        public void TestLimitSet()
        {
            // Arrange
            CreditCard card = new CreditCard();
            // Act
            card.Limit = 1000;

            // Assert
            Assert.AreEqual(1000, card.Limit);
        }
        [TestMethod]
        public void TestLimitSetNegative()
        {
            // Arrange
            CreditCard card = new CreditCard();

            // Act
            card.Limit = -1000;

            // Assert
            Assert.AreEqual(0, card.Limit);
        }
        [TestMethod]
        public void TestTermOffCereditSet()
        {
            // Arrange
            CreditCard card = new CreditCard();

            // Act
            card.TermOffCeredit = 12;

            // Assert
            Assert.AreEqual(12, card.TermOffCeredit);
        }
        [TestMethod]
        public void TestTermOffCereditSetNegative()
        {
            // Arrange
            CreditCard card = new CreditCard();

            // Act
            card.TermOffCeredit = -5;

            // Assert
            Assert.AreEqual(0, card.TermOffCeredit);
        }
        [TestMethod]
        public void TestEqualsMethod()
        {
            // Arrange
            CreditCard card1 = new CreditCard(1234, "John Doe", new DateTime(2022, 12, 31), 1500, 24, 5678);
            CreditCard card2 = new CreditCard(1234, "John Doe", new DateTime(2022, 12, 31), 1500, 24, 5678);
            CreditCard card3 = new CreditCard(4321, "Jane Doe", new DateTime(2023, 12, 31), 2000, 12, 9876);

            // Act
            bool result1 = card1.Equals(card2);
            bool result2 = card1.Equals(card3);

            // Assert
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
        }

        [TestMethod]
        public void TestGetLimitMethod()
        {
            // Arrange
            CreditCard card = new CreditCard();
            card.Limit = 2000;

            // Act
            double result = card.GetLimit();

            // Assert
            Assert.AreEqual(2000, result);
        }




    }
}
