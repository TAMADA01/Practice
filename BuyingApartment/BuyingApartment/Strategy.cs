using System;
using System.Deployment.Application;
using System.Xml.Linq;

namespace BuyingApartment
{
    public class Strategy
    {
        public bool IsBought = false;
        public bool IsStop = false;
        public bool IsFirst = true;
        public bool IsDeposit = false;
        public float Sum = 0;
        private float _procent;
        private float _credit;

        private FormData _data => ProjectContext.Instance.FormData;
        public Strategy(float procent) 
        {
            _procent = procent / 100f;
            if (_procent == 0)
            {
                IsDeposit = false;
                IsBought = true;
                _credit = _data.ApartmentCost ;
                Sum = 0;
            }
            else
            {
                IsDeposit = true;
            }
        }

        public void Update()
        {
            if (Sum >= _data.ApartmentCost && !IsBought)
            {
                Sum -= _data.ApartmentCost;
                IsBought = true;
                IsStop = true;
            }

            if (IsDeposit)
            {
                CalculateDeposit();
            }
            else
            {
                CalculateMortgage();
            }
        }

        private void CalculateMortgage()
        {
            if (_credit <= 0)
            {
                IsDeposit = true;
                IsStop = true;
                return;
            }

            _credit += _credit * (_data.MortgageRate / 100f) / 12 - _data.Income;
        }

        private void CalculateDeposit()
        {
            if (Sum >= _data.ApartmentCost * _procent && !IsBought)
            {
                IsDeposit = false;
                IsBought = true;
                _credit = _data.ApartmentCost - Sum;
                Sum = 0;
                return;
            }
            if (IsBought)
            {
                Sum += Sum * (_data.DepositRate / 100f) / 12 + _data.Income;
            }
            else
            {
                Sum += Sum * (_data.DepositRate / 100f) / 12 + _data.Income - _data.RentingCost;
            }
        }

        public void GetMonth(int month)
        {
            if (month > 500) 
            {
                IsStop = true;
            }
            if (IsStop && IsFirst)
            {
                IsFirst = false;
                Console.WriteLine($"{_procent*100}% - {month} месяц");
            }
        }
    }
}
