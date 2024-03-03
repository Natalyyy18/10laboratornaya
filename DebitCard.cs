using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary10
{
    public class DebitCard : BankCard
    {
        protected Random rnd1 = new Random();
        public double Balance { get; set; }
        //protected double balance;
        public DebitCard() : base()
        {
            Balance = 0;
        }
        public DebitCard(int number, string name, DateTime term, double balance, int number1) : base(number, name, term, number1)
        {
            Balance = balance;
        }
        public double GetBalance() { return Balance;}
        public override bool Equals(object obj)
        {
            DebitCard card = obj as DebitCard;
            if (card != null) 
                return this.Number == card.Number && this.Name == card.Name && this.Term == card.Term && this.Balance == card.Balance;
            else
                return false;
        }
        public override string ToString()
        {
            return base.ToString() +  $", баланс: {Balance} рублей";
        }
        public override void Init()
        {
            base.Init();
            Console.WriteLine("введите баланс:");
            
            try
            {
                Balance = Double.Parse(Console.ReadLine());
            }
            catch 
            {
                Balance = 100;
            }

        }
        public virtual void RandomInit()
        {
            base.RandomInit();
            Balance = rnd1.Next(-1000000,1000000) ;
        }
        
        public override void Show()
        {

            Console.WriteLine($"DebitCard: Номер = {Number}, имя = {Name}, срок действия = {Term}, баланс = {Balance} рублей");
        }
        public new void Print()
        {

            Console.WriteLine($"DebitCard: Номер = {Number}, имя = {Name}, срок действия = {Term}, баланс = {Balance} рублей");
        }
    }
}

