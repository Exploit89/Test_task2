using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    internal class Points
    {
        private Label _label;
        private int _points = 0;

        public Points()
        {
            CreateLabel();
        }

        public void AddPoints(int points)
        {
            _points+= points;
        }

        public void ClearPoints()
        {
            _points = 0;
        }

        public Label GetLabel()
        {
            return _label;
        }

        private void CreateLabel()
        {
            _label = new Label();
            _label.Name = "quest";
            _label.Size = new Size(100, 44);
            _label.Width = 120;
            _label.Height = 45;
            _label.BringToFront();
            _label.TextAlign = ContentAlignment.MiddleLeft;
            _label.BackColor = Color.Transparent;
            _label.Location = new Point(30, 30);
            _label.Font = new Font("Tobota", 14, FontStyle.Bold);
            _label.ForeColor = Color.Black;
            _label.Text = "Points:" + " " + _points.ToString();
        }
    }
}
