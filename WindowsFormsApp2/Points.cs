using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    internal class Points
    {
        private QuestClicker _questClicker;
        private Label _label;
        private int _points = 0;

        public Points(QuestClicker questClicker)
        {
            CreateLabel();
            _questClicker = questClicker;
            _questClicker.QuestCompleted += AddPoints;
        }

        public void AddPoints(Circle circle)
        {
            _points += GetPoints(circle);
            _label.Text = _points.ToString();
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
            _label.Name = "points";
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

        private int GetPoints(Circle circle)
        {
            switch (circle.GetLevel())
            {
                case 1:
                    return 1;
                case 2:
                    return 3;
                case 3:
                    return 9;
                case 4:
                    return 27;
                default:
                    return 0;
            }
        }
    }
}
