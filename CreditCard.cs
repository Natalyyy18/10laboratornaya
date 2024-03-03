using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary10
{
    public class CreditCard : BankCard
    {
        protected double limit;
        protected Random rnd2 = new Random();
        protected int termoffcredit;
        public double Limit
        {
            get => limit;
            set
            {
                if (value < 0)
                    limit = 0;
                else
                    limit = value;
            }
        }
        public int TermOffCeredit
        {
            get => termoffcredit;
            set
            {
                if (value < 0)
                    termoffcredit = 0;
                else
                    termoffcredit = value;
            }
        }
        public CreditCard() : base()
        {
            Limit = 0;
            TermOffCeredit = 0;
        }
        public CreditCard(int number, string name, DateTime term, double limit, int termoffcredit, int number1) : base(number, name, term, number1) //4 намбер не тот
        {
            Limit = limit;
            TermOffCeredit = termoffcredit;
        }
        public override bool Equals(object obj)
        {
            CreditCard card = obj as CreditCard;
            if (card != null)
                return this.Number == card.Number && this.Name == card.Name && this.Term == card.Term && this.Limit == card.Limit && this.TermOffCeredit == card.TermOffCeredit;
            else
                return false;
        }
        public double GetLimit() { return Limit; }
        public override string ToString()
        {
            return base.ToString() + $",  лимит: { Limit} рублей, срок погашения: { TermOffCeredit} месяцев";
        }
        public override void Init()
        {
            base.Init();
            Console.WriteLine("введите лимит:");

            try
            {
                Limit = Double.Parse(Console.ReadLine());
            }
            catch
            {
                Limit = 1000;
            }
            Console.WriteLine("Введите срок погашения карты в месяцах");
            try
            {
                TermOffCeredit = int.Parse(Console.ReadLine());
            }
            catch
            {
                TermOffCeredit = 72;
            }


        }
        public virtual void RandomInit()
        {
            base.RandomInit();
            Limit = rnd2.Next(1000, 1000000);
            TermOffCeredit = rnd2.Next(12, 72);
        }
        
        public override void Show()
        {

            Console.WriteLine($"CreditCard: Номер = {Number}, имя = {Name}, срок действия = {Term}, лимит = {Limit} рублей, срок погашения кредита = {TermOffCeredit} месяцев");
        }
        public new void Print()
        {

            Console.WriteLine($"CreditCard: Номер = {Number}, имя = {Name}, срок действия = {Term}, лимит = {Limit} рублей, срок погашения кредита = {TermOffCeredit} месяцев");
        }

    }
}
