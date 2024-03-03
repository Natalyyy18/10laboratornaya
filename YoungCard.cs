using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary10
{
    public class YoungCard : DebitCard
    {
        protected double cashback;
        protected Random rnd3 = new Random();
        public double Cashback
        {
            get => cashback;
            set
            {
                if (value < 0)
                    cashback = 0;
                else
                    cashback = value;
            }
        }

        public YoungCard() : base()
        {
            Cashback = 0;
        }
        public YoungCard(int number, string name, DateTime term, double balance, double cashback, int number1) : base(number, name, term, balance, number1)
        {
            Cashback = cashback;
        }
        public override bool Equals(object obj)
        {
            YoungCard card = obj as YoungCard;
            if (card != null)
                return this.Number == card.Number && this.Name == card.Name && this.Term == card.Term && this.Balance == card.Balance && this.Cashback == card.Cashback;
            else
                return false;
        }
        public override string ToString()
        {
            return base.ToString() + $", кэшбек: {Cashback}%" ;
        }
        public override void Init()
        {
            base.Init();
            Console.WriteLine("введите кешбек в процентах:");

            try
            {
                Cashback = Double.Parse(Console.ReadLine());
            }
            catch
            {
                Cashback = 100;
            }

        }
        public virtual void RandomInit()
        {
            base.RandomInit();
            Cashback = rnd3.Next(1, 20);
        }
       
        public override void Show()
        {

            Console.WriteLine($"YoungCard: Номер = {Number}, имя = {Name}, срок действия = {Term},баланс = {Balance} рублей, кэшбек = {Cashback} %");
        }
        public new void Print()
        {

            Console.WriteLine($"YoungCard: Номер = {Number}, имя = {Name}, срок действия = {Term},баланс = {Balance} рублей, кэшбек = {Cashback} %");
        }

    }
}
