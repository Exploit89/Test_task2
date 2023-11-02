using System;
using System.Collections.Generic;
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
                label.MouseUp += new MouseEventHandler(MouseUp);
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
            //label.DoDragDrop(label, DragDropEffects.Copy | DragDropEffects.Move);

            //Circle data = null;

            //foreach (var item in _labelsCircles)
            //{
            //    if (item.Key == label)
            //    {
            //        data = item.Value;
            //    }
            //}
            //label.DoDragDrop(label.Text, DragDropEffects.Copy | DragDropEffects.Move);
            label.DoDragDrop(label.Text, DragDropEffects.Move);

            SetTakenEmpty(label);
            label.Text = string.Empty;
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

        private void MouseUp(object sender, MouseEventArgs e)
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
            Console.WriteLine($"Положили:");
            Console.WriteLine($"Index: {circle.GetIndex()}");
            Console.WriteLine($"level: {circle.GetLevel()}");
            Console.WriteLine($"color: {circle.GetColor()}");
        }

        private void DragDrop(object sender, DragEventArgs e)
        {
            Label label = (Label)sender;
            label.Text = e.Data.GetData(DataFormats.Text).ToString();
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
                }
            }
        }

        private void TryMerge(string data, Label label)
        {
            foreach (var item in _labelsCircles)
            {
                if (item.Key == label)
                {
                    // test
                    item.Value.SetNewParameters("blue", 1);
                }
            }
        }
    }
}
