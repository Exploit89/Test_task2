using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    enum Colors
    {
        blue,
        green,
        red
    }

    internal class QuestCreator
    {
        private Label _label;
        private List<Circle> _circles;
        private Random _random;
        private List<int[]> _circleCoordinates = new List<int[]>() { new int[] { 275, 30} , new int[] { 325, 30 } };
        private int _questCount = 2;

        public QuestCreator()
        {
            _circles = new List<Circle>();
            CreateQuest();
            CreateLabel();
        }

        //public void CreateQuest()
        //{
        //    _random = new Random();
        //    int index = 0;

        //    for (int i = 0; i < _questCount; i++)
        //    {
        //        var colorIndex = _random.Next(0,3);
        //        var circleLevel = _random.Next(1,5);
        //        var color = typeof(Colors).GetEnumName(colorIndex);
        //        var circle = new Circle(color, circleLevel, false);
        //        circle.Move(_circleCoordinates[index][0], _circleCoordinates[index][1]);
        //        circle.SetIndex(index, _circleCoordinates[index]);
        //        index++;
        //        _circles.Add(circle);
        //    }
        //}

        public void CreateQuest()
        {
            _random = new Random();
            int index = 0;

            for (int i = 0; i < _questCount; i++)
            {
                var colorIndex = 0;
                var circleLevel = 1;
                var color = typeof(Colors).GetEnumName(colorIndex);
                var circle = new Circle(color, circleLevel, false);
                circle.Move(_circleCoordinates[index][0], _circleCoordinates[index][1]);
                circle.SetIndex(index, _circleCoordinates[index]);
                index++;
                _circles.Add(circle);
            }
        }

        public List<Circle> GetCircles()
        {
            List<Circle> list = new List<Circle>();
            list = _circles;
            return list;
        }

        public void RefreshQuest(Circle circle)
        {
            circle.SetEmptyCircle();
            AddNewQuest(circle);
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
            _label.Width = 80;
            _label.Height = 45;
            _label.BringToFront();
            _label.TextAlign = ContentAlignment.MiddleCenter;
            _label.BackColor = Color.Transparent;
            _label.Location = new Point(180, 30);
            _label.Font = new Font("Tobota", 14, FontStyle.Bold);
            _label.ForeColor = Color.Black;
            _label.Text = "Quest:";
        }

        private void AddNewQuest(Circle circle)
        {
            _random = new Random();
            var colorIndex = _random.Next(0, 3);
            var circleLevel = _random.Next(1, 5);
            var color = typeof(Colors).GetEnumName(colorIndex);
            circle.SetNewParameters(color, circleLevel);
            Console.WriteLine("New quest:");
            Console.WriteLine($"Index: {circle.GetIndex()}");
            Console.WriteLine($"level: {circle.GetLevel()}");
            Console.WriteLine($"color: {circle.GetColor()}\n");
        }
    }
}
