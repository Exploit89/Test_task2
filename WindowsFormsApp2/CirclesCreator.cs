using System;
using System.Collections.Generic;

namespace WindowsFormsApp2
{
    internal class CirclesCreator
    {
        private int _cellsCount = 64;
        private int _startCirclesCount = 8;
        private List<Circle> _circles = new List<Circle>();
        private List<Circle> _emptyCircles = new List<Circle>();
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
                circle.GetLabel().AllowDrop = true;
                _circles.Add(circle);
                cellsHolder.AddCircle(circle);
            }
            CreateEmptyCircles(cellsHolder);

            // проверка
            foreach (var item in _circles)
            {
                Console.WriteLine(item.GetIndex());
            }
        }

        public List<Circle> GetCircles()
        {
            return _circles;
        }

        public List<Circle> GetEmptyCircles()
        {
            return _emptyCircles;
        }

        public void SetAllFree(CellsHolder cellsHolder)
        {
            foreach (var item in _circles)
            {
                item.SetNewParameters("transparent", 0);
                item.SetEmptyCircle();
            }

            foreach (var item in _emptyCircles)
            {
                item.SetNewParameters("transparent", 0);
                item.SetEmptyCircle();
            }

            _random = new Random();

            for (int i = 0; i < _startCirclesCount; i++)
            {
                _circles[i].SetNewParameters("blue", 1, false);
                int cellKey = GetFreeCell(cellsHolder);
                int[] cellCoordinates = cellsHolder.GetFreeCoordinates(cellKey);
                cellsHolder.RemoveFreeCell(cellKey);
                _circles[i].Move(cellCoordinates[0], cellCoordinates[1]);
                _circles[i].SetIndex(cellKey, cellCoordinates);
                _circles[i].GetLabel().AllowDrop = true;
                _circles.Add(_circles[i]);
                cellsHolder.AddCircle(_circles[i]);
            }

            int emptyCirclescCount = _cellsCount - _startCirclesCount;

            for (int i = 0; i < emptyCirclescCount; i++)
            {
                _circles[i].SetNewParameters("transparent", 0, false);
                int cellKey = GetFreeCell(cellsHolder);
                int[] cellCoordinates = cellsHolder.GetFreeCoordinates(cellKey);
                cellsHolder.RemoveFreeCell(cellKey);
                _circles[i].Move(cellCoordinates[0], cellCoordinates[1]);
                _circles[i].SetIndex(cellKey, cellCoordinates);
                _circles[i].GetLabel().AllowDrop = true;
                _emptyCircles.Add(_circles[i]);
                cellsHolder.AddCircle(_circles[i]);
                _circles[i].SetEmptyCircle();
            }
        }

        private int GetFreeCell(CellsHolder cellsHolder)
        {
            int cellIndex = _random.Next(0, cellsHolder.GetFreeCells().Count);
            int freeCellIndex = cellsHolder.GetFreeCells()[cellIndex];
            return freeCellIndex;
        }

        private void CreateEmptyCircles(CellsHolder cellsHolder)
        {
            _random = new Random();
            int emptyCirclescCount = _cellsCount - _startCirclesCount;

            for (int i = 0; i < emptyCirclescCount; i++)
            {
                var circle = new Circle("transparent", 0, false);
                int cellKey = GetFreeCell(cellsHolder);
                int[] cellCoordinates = cellsHolder.GetFreeCoordinates(cellKey);
                cellsHolder.RemoveFreeCell(cellKey);
                circle.Move(cellCoordinates[0], cellCoordinates[1]);
                circle.SetIndex(cellKey, cellCoordinates);
                circle.GetLabel().AllowDrop = true;
                _emptyCircles.Add(circle);
                cellsHolder.AddCircle(circle);
                circle.SetEmptyCircle();
            }
        }
    }
}
