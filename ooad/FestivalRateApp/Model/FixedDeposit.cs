using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalRateApp.Model
{
    class FixedDeposit
    {
        private int _accountNumber;
        private string _accountName;
        private double _amount;
        private double _principle;
        private IFestivalRate festType;
        private int years;

        public FixedDeposit(int accountNumber, string accountName, double amount, double principle, IFestivalRate festivalType, int years)
        {
            _accountNumber = accountNumber;
            _accountName = accountName;
            _amount = amount;
            _principle = principle;
            this.festType = festivalType;
            this.years = years;
        }

        

        public int AccountNumber { get => _accountNumber; }
        public string AccountName { get => _accountName;}
        public double Amount { get => _amount; }
        public double Principle { get => _principle;  }
        public int Years { get => years;}
        internal IFestivalRate FestType { get => festType; }

        public double CalculateSimpleIntrest()
        {
            
                return (Principle * Years * FestType.GetIntrestRate());
        }


    }
}
