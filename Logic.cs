using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EighthQueens
{
    partial class Map
    {
        private struct PossiblePositions
        {
            public List<int> X;
            public List<int> Y;
        }

        private void ClearPossiblePosiitons(PossiblePositions[] position, int n)
        {
            while (position[n].X.Count != 0)
            {
                position[n].X.RemoveAt(0);
                position[n].Y.RemoveAt(0);
            }
        }

        private void SetPossiblePositions(PossiblePositions[] position, int n, ref int countPosiblePositions)
        {
            // Get all possible positions in which the queen can be placed.
            for (int i = 0; i < cellsNumber; i++)
            {
                for (int j = 0; j < cellsNumber; j++)
                {
                    if (field[i, j] == ' ')
                    {
                        position[n].X.Add(i);
                        position[n].Y.Add(j);
                        countPosiblePositions++;
                    }
                }
            }
        }

        private void PlaceAgain(PossiblePositions[] position, ref int n, ref int countPosiblePositions, ref int countRecursionRuns, int[] positionIndex)
        {
            FieldSetUp();
            for (int i = 0; i <= n - 2; i++)
            {
                PlaceQueen(position[i].X[positionIndex[i]], position[i].Y[positionIndex[i]]);
            }

            if (positionIndex[n - 1] < position[n - 1].X.Count - 1) // If the queen has more than 1 possible position.
            {
                positionIndex[n - 1]++;
                countRecursionRuns = 0;
            }
            else
            {
                positionIndex[n - 1] = 0;
                countRecursionRuns++;
            }

            PlaceQueen(position[n - 1].X[positionIndex[n - 1]], position[n - 1].Y[positionIndex[n - 1]]);
            ClearPossiblePosiitons(position, n);
            SetPossiblePositions(position, n, ref countPosiblePositions);

            if (countRecursionRuns != 0)
            {
                n--;
                PlaceAgain(position, ref n, ref countPosiblePositions, ref countRecursionRuns, positionIndex);
            }
        }

        public void CheckSells(int x, int y)
        {
            PossiblePositions[] position = new PossiblePositions[8];
            position[0].X = new List<int>();
            position[0].Y = new List<int>();
            position[0].X.Add(x);
            position[0].Y.Add(y);

            int[] positionIndex = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
            int n = 1, countRecursionRuns = 0;
            while (n < 8)
            {
                position[n].X = new List<int>();
                position[n].Y = new List<int>();
                int countPosiblePositions = 0;

                ClearPossiblePosiitons(position, n);
                SetPossiblePositions(position, n, ref countPosiblePositions);

                if (countPosiblePositions > 0)
                {
                    PlaceQueen(position[n].X[0], position[n].Y[0]);
                    n++;
                }
                else
                {
                    PlaceAgain(position, ref n, ref countPosiblePositions, ref countRecursionRuns, positionIndex);
                }
            }
        }
    }
}