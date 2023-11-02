using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    internal class CircleGenerator
    {
        private List<Circle> _circles;
        private CellsHolder _cellsHolder;
        private Dictionary<Label, Circle> _labelsCircles;
        private List<Label> _labels;
        private int _generationLevel = 4;
        private int _randomNumber = 100;
        private int _lowerPossibility = 20;
        string _lowerColor;
        string _upperColor;

        public CircleGenerator(CellsHolder cellsHolder)
        {
            _cellsHolder = cellsHolder;
            AddCircles();

            _labelsCircles = new Dictionary<Label, Circle>();
            _labels = new List<Label>();
            AddLabels();

            foreach (Label label in _labels)
            {
                label.MouseDoubleClick += new MouseEventHandler(MouseDoubleClick);
            }
        }

        public void MouseDoubleClick(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            Circle clickedCircle = null;

            foreach (var item in _labelsCircles)
            {
                if (item.Key == label)
                {
                    clickedCircle = item.Value;
                }
            }

            TryCreateCircle(clickedCircle);
        }

        private void TryCreateCircle(Circle clickedCircle)
        {
            Random random = new Random();
            List<Circle> freeCells = new List<Circle>();

            if (clickedCircle.GetLevel() == _generationLevel)
            {
                int newColorIndex = random.Next(0, _randomNumber);
                string newColor = GetRandomSettings(clickedCircle.GetColor())[newColorIndex];
                Console.WriteLine("new color is " + newColor);

                foreach (var item in _cellsHolder.GetCircles())
                {
                    if (item.GetColor() == "transparent")
                    {
                        freeCells.Add(item);
                    }
                }

                int index = freeCells[random.Next(0, freeCells.Count)].GetIndex();

                foreach (var item in _cellsHolder.GetCircles())
                {
                    if (item.GetIndex() == index)
                    {
                        item.SetNewParameters(newColor, 1);
                    }
                }
            }
        }

        private Dictionary<int, string> GetRandomSettings(string clickedColor)
        {
            Dictionary<int, string> newColors = new Dictionary<int, string>();
            SetRandomColors(clickedColor);

            for (int i = 0; i < _randomNumber; i++)
            {
                if (i < _lowerPossibility)
                    newColors.Add(i, _lowerColor);
                else
                    newColors.Add(i, _upperColor);
            }
            return newColors;
        }

        private void SetRandomColors(string clickedColor)
        {
            switch (clickedColor)
            {
                case "blue":
                    _lowerColor = "red";
                    _upperColor = "green";
                    break;
                case "green":
                    _lowerColor = "blue";
                    _upperColor = "red";
                    break;
                case "red":
                    _lowerColor = "green";
                    _upperColor = "blue";
                    break;
                default:
                    break;
            }
        }

        private void AddCircles()
        {
            foreach (var item in _cellsHolder.GetCircles())
            {
                if (item.GetLevel() == _generationLevel)
                {
                    _circles.Add(item);
                }
            }
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
