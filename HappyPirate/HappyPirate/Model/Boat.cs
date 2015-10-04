using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyPirate.model
{
    class Boat
    {
        private string _type;
        private int _width;
        private int _length;

        public string Type { get; set; }
        public int Width { get; set; }
        public int Length{ get; set; }

        public Boat(string type, int width, int length)
        {
            Type = type;
            Width = width;
            Length = length;
        }

        public void ShowBoatImage()
        {
            Console.WriteLine("     .  o ..                  ");
            Console.WriteLine("     o . o o.o                ");
            Console.WriteLine("          ...oo               ");
            Console.WriteLine("            __[]__            ");
            Console.WriteLine("         __|_o_o_o\\__         ");
            Console.WriteLine("         \''''''''''/         ");
            Console.WriteLine("          \\. ..  . /          ");
            Console.WriteLine("     ^^^^^^^^^^^^^^^^^^^^ ");
        }

    }
}
