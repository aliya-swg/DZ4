using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
        }
        // Задание 1. Вывести на экран массив из 20 случайных чисел. Ввести два числа из этого массива которые нужно поменять местами.Вывести на экран получившийся массив.
        static void Task1()
        {
            // Создаем массив из 20 случайных чисел
            Random random = new Random();
            int[] array = new int[20];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(1, 101); // Генерируем числа от 1 до 100
            }

            // Выводим исходный массив
            Console.WriteLine("Исходный массив:");
            PrintArray(array);

            // Вводим индексы элементов для обмена
            int index1, index2;
            Console.Write("Введите индекс первого элемента (от 0 до 19): ");
            while (!int.TryParse(Console.ReadLine(), out index1) || index1 < 0 || index1 >= array.Length)
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число от 0 до 19.");
                Console.Write("Введите индекс первого элемента (от 0 до 19): ");
            }

            Console.Write("Введите индекс второго элемента (от 0 до 19): ");
            while (!int.TryParse(Console.ReadLine(), out index2) || index2 < 0 || index2 >= array.Length)
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число от 0 до 19.");
                Console.Write("Введите индекс второго элемента (от 0 до 19): ");
            }

            // Меняем местами элементы
            Swap(array, index1, index2);

            // Выводим измененный массив
            Console.WriteLine("\nИзмененный массив:");
            PrintArray(array);
        }

        // Метод для обмена элементов массива
        static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        // Метод для вывода массива на экран
        static void PrintArray(int[] arr)
        {
            foreach (int num in arr)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
        // Задание 2. Написать метод, где в качества аргумента будет передан массив (ключевое слово params). Вывести сумму элементов массива(вернуть). Вывести(ref) произведение массива.Вывести(out) среднее арифметическое в массиве.
        public static int Sum(params int[] numbers)
        {
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }
            return sum;
        }

        public static void Product(ref int product, params int[] numbers)
        {
            product = 1;
            foreach (int number in numbers)
            {
                product *= number;
            }
        }

        public static void Average(out double average, params int[] numbers)
        {
            average = 0;
            if (numbers.Length > 0)
            {
                average = Sum(numbers) / (double)numbers.Length;
            }
        }
        static void Task2()
        {
            // Вычисляем сумму
            int sum = Sum(1, 2, 3, 4, 5);
            Console.WriteLine($"Сумма массива: {sum}"); // Вывод: 15

            // Вычисляем произведение
            int product = 1;
            Product(ref product, 2, 4, 6, 8);
            Console.WriteLine($"Произведение массива: {product}"); // Вывод: 384

            // Вычисляем среднее арифметическое
            double average;
            Average(out average, 3, 6, 9, 12);
            Console.WriteLine($"Среднее арифметическое массива: {average}"); // Вывод: 7.5
        }
    }
}
