using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VektorBerechnungen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vektor v1 = new Vektor();//change vetktor 1 here
            Vektor v2 = new Vektor(2, 2, 2);//change vetktor 2 here
            float test = Vektor.Distanz(v1, v2);//change method here

            Console.WriteLine(test);
            Console.ReadKey(true);
        }
    }
    internal class Vektor
    {
        private float x;
        private float y;
        private float z;

        public Vektor()
        {
            this.x = 0.0f;
            this.y = 0.0f;
            this.z = 0.0f;
        }
        public Vektor(float _x, float _y, float _z)
        {
            this.x = _x;
            this.y = _y;
            this.z = _z;
        }

        public static Vektor operator +(Vektor _v1, Vektor _v2)
        {
            return new Vektor(_v1.x + _v2.x, _v1.y + _v2.y, _v1.z + _v2.z);
        }
        public static Vektor operator -(Vektor _v1, Vektor _v2)
        {
            return new Vektor(_v1.x - _v2.x, _v1.y - _v2.y, _v1.z - _v2.z);
        }
        public static Vektor operator *(Vektor _v1, float _skalar)
        {
            return new Vektor(_v1.x * _skalar, _v1.y * _skalar, _v1.z * _skalar);
        }
        public static float Distanz(Vektor _v1, Vektor _v2)
        {
            return (float)Math.Pow(((_v1.x - _v2.x) * (_v1.x - _v2.x)) + ((_v1.y - _v2.y) * (_v1.y - _v2.y)) + ((_v1.z - _v2.z) * (_v1.z - _v2.z)), 0.5);
        }
        public static float VektorLaenge(Vektor _v1)
        {
            return (float)Math.Pow((_v1.x * _v1.x) + (_v1.y * _v1.y) + (_v1.z * _v1.z), 0.5);
        }
        public static float VektorQuadratLaenge(Vektor _v1)
        {
            return (_v1.x * _v1.x) + (_v1.y * _v1.y) + (_v1.z * _v1.z);
        }
    }
}
