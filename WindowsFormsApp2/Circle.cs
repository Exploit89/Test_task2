using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Properties;

namespace WindowsFormsApp2
{
    internal class Circle
    {
        private int _positionX;
        private int _positionY;
        private int _index;
        private string _color;
        private Image _image;
        private int _level;
        private bool _generation;
        private System.Windows.Forms.Label _label;

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

        public void SetIndex(int index, int[] coordinates)
        {
            _index = index;
            SetLabel(coordinates); // переделать на лвл
        }

        public int[] GetPosition()
        {
            int[] result = new int[2];
            result[0] = _positionX;
            result[1] = _positionY;
            return result;
        }

        public System.Windows.Forms.Label GetLabel()
        {
            return _label;
        }

        public Image GetImage()
        {
            return _image;
        }

        private void SetLabel(int[] coordinates)
        {
            _label = new System.Windows.Forms.Label();
            _label.Name = "level";
            _label.Size = new Size(44, 44);
            _label.Width = 45;
            _label.Height = 45;
            _label.BringToFront();
            _label.TextAlign = ContentAlignment.MiddleCenter;
            _label.BackColor = Color.Transparent;
            _label.Location = new Point(coordinates[0], coordinates[1]);
            _label.Font = new Font("Tobota", 16, FontStyle.Bold);
            _label.ForeColor = Color.Yellow;

            // для проверки
            _label.Text = _index.ToString();
        }
    }
}
