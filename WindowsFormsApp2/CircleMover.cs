using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    internal class CircleMover
    {
        private CellsHolder _cellsHolder;
        private Dictionary<Label, Circle> _labelsCircles;
        private List<Label> _labels;
        private Circle _currentCircle;
        private Circle _takerCircle;
        private Image _currentImage;
        private Point _currentPoint;

        public CircleMover(CellsHolder cellsholder)
        {
            _cellsHolder = cellsholder;
            _labelsCircles = new Dictionary<Label, Circle>();
            _labels = new List<Label>();
            AddLabels();

            foreach (Label label in _labels)
            {
                label.MouseDown += new MouseEventHandler(MouseDown);
                label.DragEnter += new DragEventHandler(DragEnter);
                label.DragDrop += new DragEventHandler(DragDrop);
            }
        }

        public Circle GetCurrentCircle()
        {
            return _currentCircle;
        }

        public Image GetCurrentImage()
        {
            return _currentImage;
        }

        public Point GetCurrentPoint()
        {
            return _currentPoint;
        }

        public Circle GetTakerCircle()
        {
            return _takerCircle;
        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            Console.WriteLine("mouse down");
            Label label = (Label)sender;
            Circle takenCircle = null;

            if (label.Text != "4")
            {
                foreach (var item in _labelsCircles)
                {
                    if (item.Key == label)
                    {
                        takenCircle = item.Value;
                        _currentCircle = takenCircle;
                        _currentImage = takenCircle.GetImage();
                        _currentPoint = new Point(takenCircle.GetPosition()[0], takenCircle.GetPosition()[1]);
                    }
                }
                Console.WriteLine($"Взяли:");
                Console.WriteLine($"Index: {takenCircle.GetIndex()}");
                Console.WriteLine($"level: {takenCircle.GetLevel()}");
                Console.WriteLine($"color: {takenCircle.GetColor()}");
                object data = takenCircle.GetLevel() + takenCircle.GetColor();

                foreach (var item in _cellsHolder.GetCircles())
                {
                    if (item.GetIndex() == takenCircle.GetIndex())
                    item.SetEmptyCircle();
                    takenCircle.SetEmptyCircle();
                }
                label.DoDragDrop(data, DragDropEffects.Move);
            }
        }

        private void DragEnter(object sender, DragEventArgs e)
        {
            Console.WriteLine("drag enter");
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
                e.Effect = DragDropEffects.None;
        }

        private void DragDrop(object sender, DragEventArgs e)
        {
            Console.WriteLine("drag drop");
            Label label = (Label)sender;

            foreach (var item in _labelsCircles)
            {
                if (item.Key == label)
                    _takerCircle = item.Value;
            }

            Console.WriteLine("Data: " + e.Data.GetData(DataFormats.Text).ToString());
            TryMerge(e.Data.GetData(DataFormats.Text).ToString(), label);
        }

        private void AddLabels()
        {
            foreach (var item in _cellsHolder.GetCircles())
            {
                _labels.Add(item.GetLabel());
                _labelsCircles.Add(item.GetLabel(), item);
            }
        }

        private void TryMerge(string data, Label taker)
        {
            string newData = data;
            int level = int.Parse(newData[0].ToString());
            string color = "";

            for (int i = 1; i < newData.Length; i++)
            {
                color += newData[i];
            }

            foreach (var item in _labelsCircles)
            {
                if (item.Key == taker)
                {
                    if (item.Value.GetColor() == color && item.Value.GetLevel() == level)
                    {
                        if (item.Value.GetColor() != "transparent" && item.Value.GetLevel() != 0)
                        {
                            Console.WriteLine("right merge");
                            level++;
                            item.Value.TrySetGeneration(level);
                            item.Value.SetNewParameters(color, level);
                            taker.Text = level.ToString();
                            item.Value.GetLabel().Text = level.ToString();
                            RefreshCellsHolder(item.Value, color, level);
                        }
                    }
                    else if (item.Value.GetColor() == "transparent" && item.Value.GetLevel() == 0)
                    {
                        Console.WriteLine("move merge");
                        item.Value.SetNewParameters(color, level);
                        taker.Text = level.ToString();
                        item.Value.GetLabel().Text = level.ToString();
                        RefreshCellsHolder(item.Value, color, level);
                    }
                    else
                    {
                        Console.WriteLine("swap merge");
                        _currentCircle.SetNewParameters(_takerCircle.GetColor(), _takerCircle.GetLevel());
                        RefreshCellsHolder(_currentCircle, _takerCircle.GetColor(), _takerCircle.GetLevel());
                        _takerCircle.SetNewParameters(color, level);
                        RefreshCellsHolder(_takerCircle, color, level);
                    }
                }
            }
        }

        private void RefreshCellsHolder(Circle circle, string color, int level)
        {
            foreach (var item in _cellsHolder.GetCircles())
            {
                if (circle == item)
                {
                    item.SetNewParameters(color, level);
                }
            }
        }
    }
}
