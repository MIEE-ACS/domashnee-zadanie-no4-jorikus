using System;
using System.Collections.Generic;
using System.Linq;

namespace hw4
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

		static void Rand_array(int[] array, int n)
		{
			Random rnd = new Random();
			for (int i = 0; i < n; i++)
			{
				array[i] = rnd.Next(-10, 10);
			}
		}
		static void Print_array(int[] array, int n)
		{
			for (int i = 0; i < n; i++)
			{
				Console.Write($"{array[i]} ");
			}
		}

		static int Pr(int[] array, int n)
        {
			int pr = 1;
			for (int i = 1; i < n; i += 2)
			{
				pr *= array[i];
			}
			return pr;
		}
		static int Sum(int[] array, int n)
        {
			int sum = 0;
			int indx1 = -1;
			int indx2 = -1;

			for (int i = 0; i < n; i++)
            {
				if (array[i] == 0)
                {
					indx1 = i;
					break;
                }
            }
			for (int i = n - 1; i > 0; i--)
            {
				if (array[i] == 0)
                {
					indx2 = i;
					break;
                }
            }
			if (indx1 == -1 || indx2 == -1)
            {
				return 0;
            }

			for (int i = indx1; i < indx2; i++)
            {
				sum += array[i];
            }
			return sum;
        }
		static int[] Sort(int[] array, int n)
        {
			List<int> temp_list1 = new List<int>();
			List<int> temp_list2 = new List<int>();

			for (int i = 0; i < n; i++)
            {
				if (array[i] < 0)
                {
					temp_list2.Add(array[i]);
                }
                else
                {
					temp_list1.Add(array[i]);
                }
            }
			int[] temp_array1 = temp_list1.ToArray();
			int[] temp_array2 = temp_list2.ToArray();

			array = temp_array1.Concat(temp_array2).ToArray();
			return array;
		}
		static void Main(string[] args)
		{
			Console.Write("Введите колличество элементов массива: ");
			string s = Console.ReadLine();
			while (CheckNumber(s))
			{
				Console.Write("\nОшибка. Введите число: ");
				s = Console.ReadLine();
			}
			int n = int.Parse(s);
			Console.WriteLine("\n");

			int[] array1 = new int[n];

			Rand_array(array1, n);

			Console.Write("Массив: ");
			Print_array(array1, n);
			Console.WriteLine("\n");

			Console.WriteLine($"Произведение элементов массива с четными номерами: {Pr(array1, n)}");
			Console.WriteLine($"Сумма элементов массива, расположенных между первым и последним нулевыми элементами: {Sum(array1, n)}\n");

			array1 = Sort(array1, n);
			Console.Write("Отсортированный массив: ");
			Print_array(array1, n);
			Console.WriteLine("\n\n");
		}
	}
}
