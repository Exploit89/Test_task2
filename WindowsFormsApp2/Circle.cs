using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp2.Properties;

namespace WindowsFormsApp2
{
    internal class Circle
    {
        private int _positionX;
        private int _positionY;
        private int _index;
        private int _radius;
        private string _color;
        private Image _image;
        private int _level;
        private bool _generation;

        public Circle(string color, int level, bool generation)
        {
            _color = color;
            ChooseColor(color);
            _level = level;
            _generation = generation;
        }

        private void ChooseColor(string color)
        {
            switch (color)
            {
                case "blue":
                    _image = MyResources.BlueCircle;
                    break;
                case "red":
                    _image = MyResources.RedCircle;
                    break;
                case "green":
                    _image = MyResources.GreenCircle;
                    break;
                default:
                    _image = MyResources.BlueCircle;
                    break;
            }
        }

        public void Move(int x, int y)
        {
            _positionX = x;
            _positionY = y;
        }

        public int GetIndex()
        {
            return _index;
        }

        public int[] GetPosition()
        {
            int[] result = new int[2];
            result[0] = _positionX;
            result[1] = _positionY;
            return result;
        }
    }
}
