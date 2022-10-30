using System;

namespace hw4_2_
{
    class Program
    {
		static bool CheckNumber(string s) //Функция для проверки строки на содержание символов(для преобразования в число)
		{
			foreach (char item in s) //Цикл для поочередного обращения к элементам строки
			{
				if (item != ',')
				{
					if (char.IsDigit(item) == false) // IsDigit функция определяет относится ли символ к категории чисел
					{
						return true;
					}
				}
			}
			return false;
		}
		static void Rand_array(int[,] array, int n)
        {
			Random rnd = new Random();
			
			for (int y = 0; y < n; y++)
            {
				for (int x = 0; x < n; x++)
                {
					array[x, y] = rnd.Next(-10, 10);
                }
            }
        }
		static void Print_array(int[,] array, int n)
        {
			for (int y = 0; y < n; y++)
			{
				for (int x = 0; x < n; x++)
				{
					Console.Write(array[x, y] + "\t");
				}
				Console.Write("\n");
			}
		}
		static int Count_zero(int[,] array, int n)
        {
			int count = 0;
			for (int x = 0; x < n; x++)
            {
				for (int y = 0; y < n; y++)
                {
					if (array[x, y] == 0)
                    {
						count++;
						break;
                    }
                }
            }
			return count;
        }
		static int Number_string(int[,] array, int n)
        {
			int max = 0;
			int indx = 0 ;
			for (int y = 0; y < n; y++)
            {
				int temp_max = 0;
				for (int x = 0; x < n - 1; x++)
                {
					if (array[x, y] == array[x + 1, y])
                    {
						temp_max++;
                    }
                }
				if (temp_max >= max)
                {
					max = temp_max;
					indx = y;
                }
            }
			return indx + 1;
        }
		static void Main(string[] args)
        {
			Console.Write("Введите колличество столбцов матрицы: ");
			string s = Console.ReadLine();
			while (CheckNumber(s))
			{
				Console.Write("\nОшибка. Введите число: ");
				s = Console.ReadLine();
			}
			int n = int.Parse(s);
			int[,] array2 = new int[n, n];

			Rand_array(array2, n);

			Console.WriteLine("Матрица: ");
			Print_array(array2, n);
			Console.Write("\n");

			Console.WriteLine($"Количество столбцов, содержащих хотя бы один нулевой элемент :{Count_zero(array2, n)}\n");
			Console.WriteLine($"Номер строки, в которой находится самая длинная серия одинаковых элементов :{Number_string(array2, n)}\n\n");

        }
    }
}
