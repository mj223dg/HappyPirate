using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyPirate.model
{
    class Boat
    {
        private string _type;
        private double _width;
        private double _length;

        public string Type { get; set; }
        public double Width { get; set; }
        public double Length{ get; set; }

        public Boat(string type, double width, double length)
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
