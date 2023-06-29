namespace BuyingApartment
{
    public interface IStrategy
    {
        void Calculate(ref float value);
    }

    public class Deposit : IStrategy
    {
        private FormData _data => ProjectContext.Instance.FormData;
        public void Calculate(ref float sum)
        {
            sum += sum * (_data.DepositRate / 100f) / 12f + _data.Income;
        }
    }

    public class Mortgage : IStrategy
    {
        private FormData _data => ProjectContext.Instance.FormData;
        public void Calculate(ref float credit)
        {
            credit += credit * (_data.MortgageRate / 100f) / 12f + _data.Income;
        }
    }
}
