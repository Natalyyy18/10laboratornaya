using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ClassLibrary10
{
    public class IdNumber
    {
        public int number1;
        public IdNumber(int number1)
        {
            this.number1 = number1;
        }
        public override string ToString()
        {
            return number1.ToString();
        }
        public override bool Equals(object obj) 
        {
            if (obj is IdNumber n)
            
                return this.number1 == n.number1;
            return false;
            
        }
        
    }
    public class BankCard : IInit, IComparable, IComparer, ICloneable
    {
        protected Random rnd = new Random();
        protected int number;
        protected string name;
        protected DateTime term;
        public IdNumber id;
        static string[] Names = { "Иван", "Ольга", "Мария", "Михаил", "Антон", "Елизавета", "Ольга", "Вера", "Артем", "Андрей" };

        public int Number
        {
            get => number;
            set
            {
                if (value < 0)
                    number = 0;
                else
                    number = value;
            }
        }
        public string Name
        {
            get => name;
            set
            {
                name = value;
            }

        }
        public DateTime Term { get; set; } 
        
        public BankCard()
        {
            Number = 0;
            Name = "No name";
            Term = DateTime.MaxValue;
            id = new IdNumber(1);
        }
        public BankCard(int number, string name, DateTime term, int number1)
        {
            Number = number;
            Name = name;
            Term = term;
            id = new IdNumber(number1);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is BankCard b)
                return this.Number == b.Number && this.Name == b.Name && this.Term == b.Term;
            return false;
        }
        public override string ToString()
        {
            return $"{id} - Номер: {Number}, Имя: {Name}, Срок карты: {Term}";
        }
        public virtual void Init()
        {
            Console.WriteLine("Введите id:");
            try
            {
                id.number1 = int.Parse(Console.ReadLine());
            }
            catch
            {
                id.number1 = 0;
            }
            Console.WriteLine("Введите номер банковской карты:");
            try
            {
                Number = int.Parse(Console.ReadLine());
            }
            catch
            {
                Number = 999999999;
            }
            Console.WriteLine("Введите Имя:");
            Name = Console.ReadLine();
            Console.WriteLine("Введите срок действия карты в месяцах");
           
            try
            {
                Term = DateTime.Parse(Console.ReadLine());
            }
            catch
            {
                Term = DateTime.MaxValue;
            }

        }
        public virtual void RandomInit()
        {
            Number = rnd.Next(99999999, 1000000000);
            Name = Names[rnd.Next(Names.Length)];
           
            
            Term = new DateTime(DateTime.Today.Ticks + 25920000 * rnd.Next(-24, 25));
            id.number1 = rnd.Next(1, 100);
            
        }
        
        public virtual void Show()
        {
            Console.WriteLine($"BankCard: Номер = {Number}, имя = {Name}, срок действия = {Term}");
        }
        public void Print()
        {
            Console.WriteLine($"BankCard: Номер = {Number}, имя = {Name}, срок действия = {Term}");
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return -1;
            BankCard card = obj as BankCard;
            return String.Compare(this.Name, card.Name);
            
        }

        public int Compare(object obj1, object obj2)
        {
            BankCard b1 = (BankCard)obj1;
            BankCard b2 = (BankCard)obj2;
            if (b1.Number < b2.Number) return -1;
            else
                if (b1.Number == b2.Number) return 0;
            else
                return 1;
        }

        public object Clone()
        {
            return new BankCard(Number, Name, Term, id.number1);
        }
        public object ShallowCopy()
        {
            return this.MemberwiseClone();
        }
    }
}


