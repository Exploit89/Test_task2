using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    internal class TableClicker
    {
        private List<Label> _labels;
        private CellsHolder _cellsHolder;
        private Dictionary<int, Circle> _circles;
        private List<int> _distances;
        private Form _form;
        private int _formXoffset = 30;
        private int _formYoffset = 50;

        public TableClicker(CellsHolder cellsHolder, Form form)
        {
            _form = form;
            _labels = new List<Label>();
            _cellsHolder = cellsHolder;
            _circles = new Dictionary<int, Circle>();
            AddLabels();

            foreach (Label label in _labels)
            {
                label.MouseClick += new MouseEventHandler(MouseClick);
            }
        }

        private void MouseClick(object sender, MouseEventArgs e)
        {
            Point offset = new Point(_form.DesktopLocation.X, _form.DesktopLocation.Y);
            Point point = Control.MousePosition;
            int x = point.X - offset.X - _formXoffset;
            int y = point.Y - offset.Y - _formYoffset;
            Point newPoint = new Point(x, y);

            Circle circle = GetCircle(newPoint);
            //проверка
            Console.WriteLine($"Index: {circle.GetIndex()}");
            Console.WriteLine($"level: {circle.GetLevel()}");
            Console.WriteLine($"color: {circle.GetColor()}");
        }

        private Circle GetCircle(Point click)
        {
            int index;
            _distances = new List<int>();

            foreach (var item in _cellsHolder.GetCircles())
            {
                int distance = SearchNearestValue(click, item.GetPoint());
                Console.WriteLine("distance is " + distance);

                if (_circles.ContainsKey(distance))
                {
                    Console.WriteLine("We already have that key");
                    _distances.Clear();
                    return _circles[distance];
                }
                else
                {
                    _circles.Add(distance, item);
                    _distances.Add(distance);
                }
            }
            index = FindMinDistance();

            foreach (var number in _circles)
            {
                if (number.Key == index)
                {
                    _distances.Clear();
                    _circles.Clear();
                    return number.Value;
                }
            }
            return null;
        }

        private int SearchNearestValue(Point from, Point to)
        {
            return Math.Abs(from.X - to.X) + Math.Abs(from.Y - to.Y);
        }

        private int FindMinDistance()
        {
            if (_distances.Count == 0)
            {
                throw new Exception("Array is empty");
            }
            int min = int.MaxValue;

            foreach (var item in _distances)
            {
                if (item < min)
                    min = item;
            }
            Console.WriteLine("minimal distance is " + min);
            return min;
        }

        private void AddLabels()
        {
            foreach (var item in _cellsHolder.GetCircles())
            {
                _labels.Add(item.GetLabel());
            }
        }
    }
}
