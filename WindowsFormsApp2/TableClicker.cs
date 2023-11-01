using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    internal class TableClicker
    {
        private Dictionary<Label, Circle> _labelsCircles;
        private List<Label> _labels;
        private CellsHolder _cellsHolder;

        public TableClicker(CellsHolder cellsHolder)
        {
            _labelsCircles = new Dictionary<Label, Circle>();
            _labels = new List<Label>();
            _cellsHolder = cellsHolder;
            AddLabels();

            foreach (Label label in _labels)
            {
                label.MouseClick += new MouseEventHandler(MouseClick);
            }
        }

        private void MouseClick(object sender, MouseEventArgs e)
        {
            Label label = (Label)sender;
            Circle circle = null;

            foreach (var item in _labelsCircles)
            {
                if (item.Key == label)
                {
                    circle = item.Value;
                }
            }

            Console.WriteLine($"Index: {circle.GetIndex()}");
            Console.WriteLine($"level: {circle.GetLevel()}");
            Console.WriteLine($"color: {circle.GetColor()}");
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
