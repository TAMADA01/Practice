using System;

namespace BuyingApartment
{
    public class Strategy : IComparable<Strategy>
    {
        private bool _isBought = false;
        private float _sum = 0;
        private float _procent;
        private IStrategy _strategy;

        public float Sum => _sum > 0 ? _sum : 0;
        private FormData _data => ProjectContext.Instance.FormData;
        public Strategy(float procent) 
        {
            _procent = procent / 100f;
            if (_procent == 0)
            {
                _sum = -_data.ApartmentCost;
                _strategy = new Mortgage();
                _isBought = true;
            }
            else
            {
                _strategy = new Deposit();
                _isBought = false;
            }
        }

        public void Update()
        {
            if (_sum >= _data.ApartmentCost && !_isBought)
            {
                _sum -= _data.ApartmentCost;
                _isBought = true;
            }

            if (_sum >= 0)
            {
                _strategy = new Deposit();
            }

            if (_sum >= _data.ApartmentCost * _procent && !_isBought)
            {
                _strategy = new Mortgage();
                _isBought = true;
                _sum = -(_data.ApartmentCost - _sum);
            }

            _strategy.Calculate(ref _sum);
            _sum -= _isBought ? 0 : _data.RentingCost;
        }

        public override string ToString()
        {
            return $"{_procent * 100}% - {Sum}";
        }

        public int CompareTo(Strategy other)
        {
            return (int)(Sum - other.Sum);
        }
    }
}
