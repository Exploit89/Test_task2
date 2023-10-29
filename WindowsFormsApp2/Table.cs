using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    internal class Table
    {
        private int _sideSize = 8;
        private int[] _size = new int[64];
        private int _cellSize = 44;
        private int _startCoordinateX = 5;
        private int _startCoordinateY = 5;
        private Dictionary<int, int[]> _coordinates = new Dictionary<int, int[]>();
        private Dictionary<int, Circle> _circles = new Dictionary<int, Circle>();

        public Table()
        {
            int[] coordinates;
            int indexCount = 0;

            for (int i = 0; i < _sideSize; i++)
            {
                for (int j = 0; j < _sideSize; j++)
                {
                    coordinates = new int[] { (_startCoordinateX + _cellSize * i), (_startCoordinateY + _cellSize * j) };
                    Console.WriteLine(i + " " + coordinates[0] + " " + coordinates[1]);
                    AddCoordinates(indexCount, coordinates);
                    indexCount++;
                }
            }

            foreach (var item in _coordinates)
            {
                Console.WriteLine($"Key={item.Key}, X={item.Value[0]}, Y={item.Value[1]}" );
            }
        }

        public void AddCoordinates(int index, int[] coordinates)
        {
            _coordinates.Add(index, coordinates);
        }

        public void AddCircle(Circle circle)
        {
            _circles.Add(circle.GetIndex(), circle);
        }
    }
}
