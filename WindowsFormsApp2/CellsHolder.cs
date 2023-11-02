using System;
using System.Collections.Generic;
using System.Linq;

namespace WindowsFormsApp2
{
    internal class CellsHolder
    {
        private Table _table;
        private List<int> _freecells;
        private List<Circle> _circles = new List<Circle>();

        public CellsHolder(Table table)
        {
            _table = table;
            _freecells = new List<int>();
            FillFreeCells();
        }

        public List<int> GetFreeCells()
        {
            List<int> freecells = new List<int>();

            foreach (var item in _freecells)
            {
                freecells.Add(item);
            }
            return freecells;
        }

        public void RemoveFreeCell(int cell)
        {
            _freecells.Remove(cell);
        }

        public int[] GetFreeCoordinates(int key)
        {
            return _table.GetAllCoordinates().Values.ElementAt(key);
        }

        public void AddCircle(Circle circle)
        {
            _circles.Add(circle);
        }

        public List<Circle> GetCircles()
        {
            List<Circle> list = new List<Circle>();
            list = _circles;
            return list;
        }

        public void RemoveCircle(Circle circle)
        {
            List<Circle> circles = new List<Circle>();
            Random random = new Random();

            foreach (var item in _circles)
            {
                string questColor = item.GetColor();
                int questLevel = item.GetLevel();
                string color = circle.GetColor();
                int level = circle.GetLevel();

                if (questColor == color && questLevel == level)
                    circles.Add(circle);
            }
            int randomNumber = random.Next(0, circles.Count);
            int index = circles[randomNumber].GetIndex();

            foreach (var item in _circles)
            {
                if (item.GetIndex() == index)
                    item.SetEmptyCircle();
            }
            circles.Clear();
        }

        public void ClearFreeCells()
        {
            _freecells.Clear();
        }

        private void FillFreeCells()
        {
            foreach (var item in _table.GetAllCoordinates())
            {
                _freecells.Add(item.Key);
            }
        }
    }
}
