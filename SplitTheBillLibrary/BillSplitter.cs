namespace SplitTheBillLibrary
{
    public class BillSplitter
    {
        /// <summary>
        /// Splits the total bill amount among the specified number of people.
        /// </summary>
        /// <param name="amount">Total bill amount.</param>
        /// <param name="numberOfPeople">Number of people splitting the bill.</param>
        /// <returns>Amount that each person needs to pay.</returns>
        /// <exception cref="DivideByZeroException">This exception is thrown when the number of people is zero.</exception>
        public decimal SplitBillAmount(decimal amount, int numberOfPeople)
        {
            if (numberOfPeople == 0)
            {
                throw new DivideByZeroException("Number of people should not be zero.");
            }
           
        // Making sure that dividing the amount by numberOfPeople does not exceed the max value allowed by the datatype 
        decimal splitAmount = (amount / numberOfPeople) > decimal.MaxValue ? 0 : amount / numberOfPeople;

        return Math.Round(splitAmount, 2);

        }

        /// <summary>
        /// Calculates the tip amount for each person based on individual meal costs and tip percentage.
        /// </summary>
        /// <param name="mealCosts">Dictionary containing names and individual meal costs.</param>
        /// <param name="tipPercentage">Tip percentage for the entire bill.</param>
        /// <returns>Dictionary with names as keys and tip amounts as values.</returns>
        /// <exception cref="ArgumentException">This exception is thrown when the tip percentage is negative.</exception>
        public Dictionary<string, decimal> CalculateTip(Dictionary<string, decimal> mealCosts, float tipPercentage)
        {
            // Check for negative tip percentage
            if (tipPercentage < 0)
            {
                throw new ArgumentException("Tip percentage cannot be negative.");
            }

            Dictionary<string, decimal> tipAmounts = new Dictionary<string, decimal>();

            // Calculate the total cost (total weight)
            decimal totalCost = mealCosts.Values.Sum();

            // Calculate the total tip amount
            decimal totalTip = totalCost * (decimal)(tipPercentage / 100);

            // Looping through the mealCosts dictionary and calculating individual tips using weighted average
            foreach (var entry in mealCosts)
            {
                // Calculate individual tip using weighted average formula
                decimal individualTip = (entry.Value / totalCost) * totalTip;

                // Round the individual tip and add it to the result dictionary
                tipAmounts.Add(entry.Key, Math.Round(individualTip, 2, MidpointRounding.AwayFromZero));
            }

            return tipAmounts;
        }

        /// <summary>
        /// Calculates the amount of tip per person based on total price, number of patrons, and tip percentage.
        /// </summary>
        /// <param name="totalPrice">Total price of the bill.</param>
        /// <param name="numberOfPatrons">Number of patrons sharing the bill.</param>
        /// <param name="tipPercentage">Tip percentage for the entire bill.</param>
        /// <returns>Amount of tip per person.</returns>
        /// <exception cref="ArgumentException">This exception is thrown when the number of patrons is less than or equal to zero.</exception>
        public decimal CalculateTipPerPerson(decimal totalPrice, int numberOfPatrons, float tipPercentage)
        {
            // Check for invalid number of patrons
            if (numberOfPatrons <= 0)
            {
                throw new ArgumentException("Number of patrons must be greater than zero.");
            }
            // Check for negative tip percentage
            if (tipPercentage < 0)
            {
                throw new ArgumentException("Tip percentage cannot be negative.");
            }

            decimal totalTipAmount = totalPrice * (decimal)(tipPercentage / 100);
            return Math.Round(totalTipAmount / numberOfPatrons, 2);
        }

    }
}