using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary10;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices.WindowsRuntime;

namespace лаба10
{
    internal class Program
    {
        static void PrintArray2(IInit[] array2)
        {
            foreach (var item in array2)
            {
                Console.WriteLine(item);
            }
        }
        static void Main(string[] args) 
        {
            Random rnd7 = new Random();
            BankCard[] array = new BankCard[10]; 

            for (int i = 0; i < 3; i++)
            {
                BankCard card = new BankCard();
                card.RandomInit();
                var milliseconds = 300;
                Thread.Sleep(milliseconds);
                array[i] = card;
                
            }
            for (int i = 3;i < 4;i++)
            {
                DebitCard s = new DebitCard();
                s.RandomInit();
                var milliseconds = 300;
                Thread.Sleep(milliseconds);
                array[i] = s;
              
            }
            for (int i = 4; i < 8; i++)
            {
                CreditCard c = new CreditCard();
                c.RandomInit();
                var milliseconds = 300;
                Thread.Sleep(milliseconds);
                array[i] = c;

            }
            for (int i = 8; i < 10; i++)
            {
                YoungCard y = new YoungCard();
                y.RandomInit();
                var milliseconds = 300;
                Thread.Sleep(milliseconds);
                array[i] = y;

            }
            foreach (BankCard item in array)
            {
                //Console.WriteLine(item);
                item.Show();
            }
            Console.WriteLine("");
            Console.WriteLine("Не виртуальный:");
            foreach (BankCard item in array)
            {
                //Console.WriteLine(item);
                item.Print();
            }
            Console.WriteLine("Сортировка по имени:");
            Array.Sort(array);
            foreach (BankCard item in array)
            { Console.WriteLine(item); }
            Console.WriteLine("");

            Console.WriteLine("Поиск:");
            BankCard n = new BankCard();
            n.Init();
            array[2] = n;
            Array.Sort(array);
            foreach (BankCard item in array)
            { Console.WriteLine(item); }
            Console.WriteLine("");
            int position = Array.BinarySearch(array, n);
            if (position < 0)
                Console.WriteLine("net");
            else
                Console.WriteLine($"элемент {n} на {position+1} месте");
            
            
            Console.WriteLine("Сорировка по номеру:");
            Array.Sort (array, new BankCard());
            foreach (BankCard item in array) { Console.WriteLine(item); }
            Console.WriteLine("");
            
            Console.WriteLine("");
            Console.WriteLine("Общий баланс дебетовых карт:"); //считаем вместе с молодежными
            double sum = 0;
            double count = 0;
            foreach (BankCard item in array)
            {
                if (item is DebitCard t)
                {
                    sum += t.GetBalance();
                    count++;
                }
            }
            Console.WriteLine($"{sum} рублей");
           
            Console.WriteLine("");
            Console.WriteLine("Имена людей с истекшим сроком карты:");
            DateTime m = DateTime.UtcNow;
            foreach (BankCard item in array)
            {
                if (item is BankCard s)
                    if (s.Term <= DateTime.Today)
                        Console.WriteLine(item.Name);
            }
            //}
            Console.WriteLine("");
            Console.WriteLine("Средний лимит кредитных карт:");
            double sum1 = 0;
            double count1 = 0;
            
            foreach (BankCard item in array)
            {
                if (item is CreditCard l)
                {
                    sum1 += l.GetLimit();
                    count1++;
                }
            }
            Console.WriteLine(sum1/count1);

            int countBankCards = 0;
            int countDebitCards = 0;
            int countYoungCards = 0;
            int countCreditCards = 0;
            int countGeo = 0;
            Console.WriteLine("");
            Console.WriteLine("Массив из классов разных иерархий");
            IInit[] array2 = new IInit[30];
            for (int i = 0; i< array2.Length; i++)
            {
                int randomIndex = rnd7.Next(5);
                if (randomIndex == 0)
                {
                    array2[i] = new BankCard();
                    array2[i].RandomInit();
                    var milliseconds = 300;
                    Thread.Sleep(milliseconds);
                    countBankCards++;
                }
                else if (randomIndex == 1)
                {
                    array2[i] = new DebitCard();
                    array2[i].RandomInit();
                    var milliseconds = 300;
                    Thread.Sleep(milliseconds);
                    countDebitCards++;
                }
                else if (randomIndex == 2)
                {
                    array2[i] = new YoungCard();
                    array2[i].RandomInit();
                    var milliseconds = 300;
                    Thread.Sleep(milliseconds);
                    countYoungCards++;
                }
                else if(randomIndex == 3)
                {
                    array2[i] = new CreditCard();
                    array2[i].RandomInit();
                    var milliseconds = 300;
                    Thread.Sleep(milliseconds);
                    countCreditCards++;
                }
                else if( randomIndex == 4)
                {
                    array2[i] = new GeoCoordinates();
                    array2[i].RandomInit();
                    var milliseconds = 300;
                    Thread.Sleep(milliseconds);
                    countGeo++;
                }
            }

            foreach (var item in array2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("");
            Console.WriteLine($"Количество банковских карт:{countBankCards}");
            Console.WriteLine($"Количество дебетовых карт:{countDebitCards}");
            Console.WriteLine($"Количество молодежных карт:{countYoungCards}");
            Console.WriteLine($"Количество кредитных карт:{countCreditCards}");
            Console.WriteLine($"Количество координат:{countGeo}");
            Console.WriteLine("");
            BankCard a = new BankCard();
            a.RandomInit();
            Console.WriteLine(a);
            BankCard copy = (BankCard) a.ShallowCopy();
            Console.WriteLine(copy);
            BankCard clon = (BankCard) a.Clone();
            Console.WriteLine(clon);

            Console.WriteLine("После изменений:");
            copy.Name = "COPY" + "" + a.Name;
            copy.id.number1 = 100;
            clon.Name = "CLON" + "" + a.Name;
            clon.id.number1 = 200;
            Console.WriteLine(a);
            Console.WriteLine(copy);
            Console.WriteLine(clon);

            

            

        }
    }
}
