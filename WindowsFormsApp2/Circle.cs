using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    internal class Circle
    {
        private int _positionX;
        private int _positionY;
        private int _radius;
        private Color _color;
        private int _level;
        private bool _generation;

        Circle()
        {

        }

        public void Move(int x, int y)
        {
            _positionX = x;
            _positionY = y;
        }
    }
}
