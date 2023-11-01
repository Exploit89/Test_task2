using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    internal class QuestClicker
    {
        private Dictionary<Label, Circle> _labelsCircles;
        private List<Label> _labels;
        private QuestCreator _questCreator;

        public QuestClicker(QuestCreator questCreator)
        {
            _labelsCircles = new Dictionary<Label, Circle>();
            _labels = new List<Label>();
            _questCreator = questCreator;
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

            //////////////////////////////////////////////////////
            _questCreator.RemoveCircle(circle);

            Console.WriteLine($"Index: {circle.GetIndex()}");
            Console.WriteLine($"level: {circle.GetLevel()}");
            Console.WriteLine($"color: {circle.GetColor()}");
        }

        private void AddLabels()
        {
            foreach (var item in _questCreator.GetCircles())
            {
                _labels.Add(item.GetLabel());
                _labelsCircles.Add(item.GetLabel(), item);
            }
        }
    }
}
