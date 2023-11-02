using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{
    internal class CircleMover
    {
        private CellsHolder _cellsHolder;
        private Dictionary<Label, Circle> _labelsCircles;
        private List<Label> _labels;

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

        private void MouseDown(object sender, MouseEventArgs e)
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
            Console.WriteLine($"Взяли:");
            Console.WriteLine($"Index: {circle.GetIndex()}");
            Console.WriteLine($"level: {circle.GetLevel()}");
            Console.WriteLine($"color: {circle.GetColor()}");

            object data = circle.GetLevel() + circle.GetColor();

            label.DoDragDrop(data, DragDropEffects.Move);

            //SetTakenEmpty(label);
            //circle.SetEmptyCircle();
        }

        private void DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
                e.Effect = DragDropEffects.None;
        }

        private void DragDrop(object sender, DragEventArgs e)
        {
            Label label = (Label)sender;
            Console.WriteLine("Data: " + e.Data.GetData(DataFormats.Text).ToString());

            // надо как-то сюда передать того, кого берем.
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

        private void SetTakenEmpty(Label label)
        {
            foreach (var item in _labelsCircles)
            {
                if (item.Key == label)
                {
                    item.Value.SetEmptyCircle();

                    foreach (var circle in _cellsHolder.GetCircles())
                    {
                        if (circle == item.Value)
                        {
                            item.Value.SetNewParameters("transparent", 0);
                        }
                    }
                }
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
                if (item.Key == taker && ValidateMerge(taker))
                {
                    if (item.Value.GetColor() == color && item.Value.GetLevel() == level)
                    {
                        level++;
                        item.Value.SetNewParameters(color, level);
                        taker.Text = level.ToString();
                        item.Value.GetLabel().Text = level.ToString();
                        RefreshCellsHolder(item.Value, color, level);
                    }
                    else if (item.Value.GetColor() == "transparent" && item.Value.GetLevel() == 0)
                    {
                        item.Value.SetNewParameters(color, level);
                        taker.Text = level.ToString();
                        item.Value.GetLabel().Text = level.ToString();
                        RefreshCellsHolder(item.Value, color, level);
                    }
                }
            }
        }


        ////////////////////////////////////////
        private bool ValidateMerge(Label label)
        {
            //foreach (var item in _labelsCircles)
            //{
            //    if (item.Value.GetLabel() == label)
            //    {
            //        return false;
            //    }
            //}
            return true;
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
