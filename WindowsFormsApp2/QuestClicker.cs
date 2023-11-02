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
        private CellsHolder _cellsHolder;

        public event Action<Circle> QuestCompleted;
        public event Action AddCompletedQuest;

        public QuestClicker(QuestCreator questCreator, CellsHolder cellsHolder)
        {
            _labelsCircles = new Dictionary<Label, Circle>();
            _labels = new List<Label>();
            _questCreator = questCreator;
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

            TryCompleteQuest(circle);

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

        private void TryCompleteQuest(Circle circle)
        {
            if (circle != null)
            {
                ValidateCircle(circle);
            }
        }

        private bool ValidateCircle(Circle circle)
        {
            foreach (var item in _cellsHolder.GetCircles())
            {
                string questColor = item.GetColor();
                int questLevel = item.GetLevel();
                string color = circle.GetColor();
                int level = circle.GetLevel();

                if (questColor == color && questLevel == level)
                {
                    QuestCompleted?.Invoke(circle);
                    AddCompletedQuest?.Invoke();
                    Console.WriteLine("quest action about completing");
                    _questCreator.RefreshQuest(circle);
                    _cellsHolder.RemoveCircle(item);
                    return true;
                }
            }
            return false;
        }
    }
}
