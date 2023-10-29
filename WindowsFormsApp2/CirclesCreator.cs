using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    internal class CirclesCreator
    {
        private int _startCirclesCount = 8;
        private List<Circle> _circles = new List<Circle>();
        private Random _random;

        public void CreateStartCircles(CellsHolder cellsHolder)
        {
            _random = new Random();

            for (int i = 0; i < _startCirclesCount; i++)
            {
                var circle = new Circle("blue", 1, false);

                // куда засунуть

                circle.Move(_random.Next(0, 100), _random.Next(0, 100)); // собсна засунуть
                _circles.Add(circle); // записать что где лежит
            }
        }

        public List<Circle> GetCircles()
        {
            List<Circle> list = new List<Circle>();
            list = _circles;
            return list;
        }

        private bool ValidateCell(int index)
        {
            // проверить на валидность ячейки
        }
    }
}
