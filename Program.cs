using System;

namespace CSharpPiggyBankLamdas
{

    public delegate void MyEventHandler(decimal _amount);

    class PiggyBank
    {

        private decimal _amount;
        public event MyEventHandler amountChanged;

        public decimal Amount
        {
            get { return _amount; }

            set
            {
                _amount = value;
                amountChanged(_amount);
            }
        }
    } // End class PiggyBank

    public class Program
    {

        public static void Main(string[] args)
        {
            PiggyBank pb = new PiggyBank();
            pb.amountChanged += (amount) => Console.WriteLine("Value was updated by {0} amount", amount);
            pb.amountChanged += (amount) => { if (amount > 500) Console.WriteLine("You have reached your savings goal {0}", amount); };

            string str;
            decimal amount;

            do
            {
                Console.WriteLine("What is the amount that you would to add? :");
                str = Console.ReadLine();
                if (!str.Equals("exit"))
                {
                    amount = decimal.Parse(str);
                    pb.Amount += amount;
                }
            } while (!str.Equals("exit"));
        }
    }
}