using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB
{
    internal class Labyrinth
    {
        public Labyrinth()
        {
            breadCrumbs = new bool[labirynth1.GetLength(1), labirynth1.GetLength(0)];
        }
        private int[,] labirynth1 = new int[,]
                                        {
                                        {1, 1, 1, 1, 1, 1, 1 },
                                        {1, 0, 0, 0, 0, 0, 1 },
                                        {1, 0, 1, 1, 1, 0, 1 },
                                        {0, 0, 0, 0, 1, 0, 0 },
                                        {1, 1, 0, 0, 1, 1, 1 },
                                        {1, 1, 1, 0, 1, 1, 1 },
                                        {1, 1, 1, 0, 1, 1, 1 }
                                        };
        private bool[,] breadCrumbs; // Хлебные крошки, чтобы повторно не ходить по пройденному пути
        private Dictionary<int[], int> exits = new Dictionary<int[], int>();
        private void findExit(int x, int y)
        {
            if ((x >= 0 && x < labirynth1.GetLength(1)) && (y >= 0 && y < labirynth1.GetLength(0))){
                // если координата в этой точке не стена и мы тут ещё не были...
                if (labirynth1[x,y] == 0 && !breadCrumbs[x,y])
                {
                    breadCrumbs[x, y] = true; // оставляем хлебную крошку
                    // Идем вниз
                    findExit(x + 1, y);
                    // Идем вперед
                    findExit(x, y + 1);
                    // Идем вверх
                    findExit(x - 1, y);
                    // Идем назад
                    findExit(x, y - 1);
                }
            }
            else
            {
                // Нормализуем координаты, которые вылетели за диапазон
                if (x < 0)
                    x = 0;
                if (y < 0)
                    y = 0;
                if (x >= labirynth1.GetLength(1))
                    x = labirynth1.GetLength(1) - 1;
                if (y >= labirynth1.GetLength(0))
                    y = labirynth1.GetLength(0) - 1;
                // Добавляем в словарь найденные координаты
                if (exits.ContainsKey(new int[] { x, y, }))
                    exits[new int[] { x, y, }] += 1;
                else
                    exits.Add(new int[] { x, y, }, 1); // Если зашел с нескольких сторон в один выход, фиксируем это
            }
        }
        public void StartFind()
        {
            // точка входа
            findExit(3, 0);
        }
        public void ShowExits()
        {
            int i = 1;
            foreach (int[] x in exits.Keys) {
                Console.WriteLine("Выход №" + i++ + " с координатами x = " + x[0] + ", y = " + x[1]);
            }
        }

    }
}
