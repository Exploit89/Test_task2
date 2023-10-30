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
                int cellKey = GetFreeCell(cellsHolder);
                int[] cellCoordinates = cellsHolder.GetFreeCoordinates(cellKey);
                cellsHolder.RemoveFreeCell(cellKey);
                circle.Move(cellCoordinates[0], cellCoordinates[1]);
                circle.SetIndex(cellKey, cellCoordinates);
                _circles.Add(circle);
            }

            // проверка
            foreach (var item in _circles)
            {
                Console.WriteLine(item.GetIndex());
            }
        }

        public List<Circle> GetCircles()
        {
            List<Circle> list = new List<Circle>();
            list = _circles;
            return list;
        }

        private int GetFreeCell(CellsHolder cellsHolder)
        {
            int cellIndex = _random.Next(0, cellsHolder.GetFreeCells().Count);
            int freeCellIndex = cellsHolder.GetFreeCells()[cellIndex];
            return freeCellIndex;
        }
    }
}
