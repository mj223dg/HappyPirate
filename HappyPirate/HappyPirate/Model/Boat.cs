using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyPirate.model
{
    class Boat
    {
        //private string _type;
        //private int _width;
        //private int _length;

        public string Type { get; set; }
        public int Width { get; set; }
        public int Length{ get; set; }
        public string OwnerId { get; set; }

        public Boat(string type, int width, int length)
        {
            Type = type;
            Width = width;
            Length = length;
        }
        public Boat(string ownerId, string type, int width, int length)
        {
            OwnerId = ownerId;
            Type = type;
            Width = width;
            Length = length;
        }
    }
}
