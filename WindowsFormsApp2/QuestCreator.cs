using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private List<Circle> _circles;
        private Random _random;
        private List<int[]> _circleCoordinates = new List<int[]>() { new int[] { 280, 50} , new int[] { 330, 50 } };
        private int _questCount = 2;

        public QuestCreator()
        {
            _circles = new List<Circle>();
            CreateQuest();
        }

        public void CreateQuest()
        {
            _random = new Random();
            int index = 0;

            for (int i = 0; i < _questCount; i++)
            {
                var colorIndex = _random.Next(0,2);
                var circleLevel = _random.Next(1,5);
                var color = typeof(Colors).GetEnumName(colorIndex);
                var circle = new Circle(color, circleLevel, false);
                circle.Move(_circleCoordinates[index][0], _circleCoordinates[index][1]);
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

        public void RemoveCircle(int index)
        {
            _circles.RemoveAt(index);
        }
    }
}
