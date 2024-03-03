using ClassLibrary10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace лаба10
{
    public class GeoCoordinates : IInit
    {
        private double latitude;
        private double longitude;
        protected Random rnd2 = new Random();

        public double Latitude //для задания ограничений широты
        {
            get { return latitude; }

            set
            {
                if ((value >= -90) && (value <= 90))
                {

                    latitude = value;
                }
            }
        }

        public double Longitude //для задания ограничений долготы
        {
            get { return longitude; }
            set
            {
                if ((value >= -180) && (value <= 180))
                {

                    longitude = value;
                }
            }

        }
        private static int count = 0;
        public GeoCoordinates()
        {
            latitude = 0;
            longitude = 0;
            count++;
        }

        public GeoCoordinates(double latitude, double longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            count++;
        }
        public override bool Equals(object obj)
        {
            GeoCoordinates geo = obj as GeoCoordinates;
            if (geo != null)
                return this.Latitude == geo.Latitude && this.Longitude == geo.Longitude;
            else
                return false;
        }
        public override string ToString()
        {
            return $"Широта: {Latitude}, Долгота: {Longitude}";
        }
        public virtual void Init()
        {
            Console.WriteLine("Введите широту:");
            try
            {
                Latitude = Double.Parse(Console.ReadLine());
            }
            catch
            {
                Latitude = 0;
            }
           
            Console.WriteLine("Введите долготу:");

            try
            {
                Longitude = Double.Parse(Console.ReadLine());
            }
            catch
            {
                Longitude = 0;
            }

        }
        public virtual void RandomInit()
        {
            Latitude = rnd2.Next(-90, 91);
            Longitude = rnd2.Next(-180, 180);
        }
        public virtual void Show()
        {
            Console.WriteLine($"Широта = {Latitude}, Долгота = {Longitude}");
        }

    }
}
