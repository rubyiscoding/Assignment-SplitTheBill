using SplitTheBillLibrary;

namespace SplitTheBillTests
{
    [TestClass]
    public class BillSplitterTests
    {
        // Test for SplitBillAmount method
        [TestMethod]
        public void SplitBillAmount_ShouldReturnCorrectAmountForNonZeroAmountAndPeople()
        {
            // Arrange
            var billSplitter = new BillSplitter();
            decimal totalAmount = 100;
            int numberOfPeople = 5;

            // Act
            decimal splitAmount = billSplitter.SplitBillAmount(totalAmount, numberOfPeople);

            // Assert
            Assert.AreEqual(20, splitAmount);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void SplitBillAmount_ShouldThrowExceptionForZeroPeople()
        {
            // Arrange
            var billSplitter = new BillSplitter();
            decimal totalAmount = 100;
            int numberOfPeople = 0;

            // Act & Assert (Exception is expected here)
            decimal splitAmount = billSplitter.SplitBillAmount(totalAmount, numberOfPeople);
        }

        // Test for CalculateTip method
        [TestMethod]
        public void CalculateTip_ShouldReturnCorrectTipAmountsForDifferentPercentages()
        {
            // Arrange
            var billSplitter = new BillSplitter();
            var mealCosts = new Dictionary<string, decimal>
            {
                {"Rick", 50},
                {"Morty", 30}
            };
            float tipPercentage = 10;

            // Act
            var tipAmounts = billSplitter.CalculateTip(mealCosts, tipPercentage);

            // Assert
            Assert.AreEqual(5, tipAmounts["Rick"]);
            Assert.AreEqual(3, tipAmounts["Morty"]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculateTip_ShouldThrowExceptionForNegativeTipPercentage()
        {
            // Arrange
            var billSplitter = new BillSplitter();
            var mealCosts = new Dictionary<string, decimal>
            {
                {"Rick", 50},
                {"Morty", 30}
            };
            float tipPercentage = -10;

            // Act & Assert (Exception is expected here)
            var tipAmounts = billSplitter.CalculateTip(mealCosts, tipPercentage);
        }

        // Test for CalculateTipPerPerson method
        [TestMethod]
        public void CalculateTipPerPerson_ShouldReturnCorrectTipPerPersonForNonZeroValues()
        {
            // Arrange
            var billSplitter = new BillSplitter();
            decimal totalPrice = 100;
            int numberOfPatrons = 4;
            float tipPercentage = 15;

            // Act
            decimal tipPerPerson = billSplitter.CalculateTipPerPerson(totalPrice, numberOfPatrons, tipPercentage);

            // Assert
            Assert.AreEqual(3.75M, tipPerPerson);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculateTipPerPerson_ShouldThrowExceptionForZeroPatrons()
        {
            // Arrange
            var billSplitter = new BillSplitter();
            decimal totalPrice = 100;
            int numberOfPatrons = 0;
            float tipPercentage = 15;

            // Act & Assert (Exception is expected here)
            decimal tipPerPerson = billSplitter.CalculateTipPerPerson(totalPrice, numberOfPatrons, tipPercentage);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculateTipPerPerson_ShouldThrowExceptionForNegativeTipPercentage()
        {
            // Arrange
            var billSplitter = new BillSplitter();
            decimal totalPrice = 100;
            int numberOfPatrons = 4;
            float tipPercentage = -15;

            // Act & Assert (Exception is expected here)
            decimal tipPerPerson = billSplitter.CalculateTipPerPerson(totalPrice, numberOfPatrons, tipPercentage);
        }

        // Check if SplitBillAmount handles large amount and people count
        [TestMethod]
        public void SplitBillAmount_ShouldReturnCorrectAmountForSmallValues()
        {
            // Arrange
            var billSplitter = new BillSplitter();
            decimal totalAmount = 0.01M;
            int numberOfPeople = 1;

            // Act
            decimal splitAmount = billSplitter.SplitBillAmount(totalAmount, numberOfPeople);

            // Assert
            Assert.AreEqual(0.01M, splitAmount); // Since both values are small, split amount should be the same as total amount

        }

        // Check if CalculateTipPerPerson handles zero tip percentage correctly
        [TestMethod]
        public void CalculateTipPerPerson_ShouldReturnZeroTipForZeroPercentage()
        {
            // Arrange
            var billSplitter = new BillSplitter();
            decimal totalPrice = 100;
            int numberOfPatrons = 4;
            float tipPercentage = 0;

            // Act
            decimal tipPerPerson = billSplitter.CalculateTipPerPerson(totalPrice, numberOfPatrons, tipPercentage);

            // Assert
            Assert.AreEqual(0, tipPerPerson); // Tip should be 0 for 0% tip percentage
        }
    }
}
