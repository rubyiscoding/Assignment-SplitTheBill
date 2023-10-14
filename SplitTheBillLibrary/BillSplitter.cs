namespace SplitTheBillLibrary
{
    public class BillSplitter
    {
        public decimal SplitBillAmount(decimal amount, int numberOfPeople)
        {
            if (numberOfPeople == 0)
            {
                throw new DivideByZeroException("Number of people should not be zero.");
            }
            
            return Math.Round(amount / numberOfPeople, 2);
        }
    }
}
