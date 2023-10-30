using System.Collections.Generic;
using System.Linq;

namespace WindowsFormsApp2
{
    internal class CellsHolder
    {
        private Table _table;
        private List<int> _freecells;

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

        private void FillFreeCells()
        {
            foreach (var item in _table.GetAllCoordinates())
            {
                _freecells.Add(item.Key);
            }
        }
    }
}
