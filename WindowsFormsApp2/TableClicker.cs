using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    internal class TableClicker
    {
        private Dictionary<Label, Circle> _labelsCircles = new Dictionary<Label, Circle>();

        private List<Label> _labels;
        private CellsHolder _cellsHolder;
        private Dictionary<int, Circle> _circles;
        private Form _form;

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
            Label label = (Label)sender;
            Circle circle2 = null;

            foreach (var item in _labelsCircles)
            {
                if (item.Key == label)
                {
                    circle2 = item.Value;
                }
            }

            Console.WriteLine($"Index: {circle2.GetIndex()}");
            Console.WriteLine($"level: {circle2.GetLevel()}");
            Console.WriteLine($"color: {circle2.GetColor()}");
        }

        private void AddLabels()
        {
            foreach (var item in _cellsHolder.GetCircles())
            {
                _labels.Add(item.GetLabel());
                _labelsCircles.Add(item.GetLabel(), item);
            }
        }
    }
}
