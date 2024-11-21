using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ4._1
{
    internal class Program
    {
        static void Main(string[] args)
        //Тумаков - Лабораторная 5 глава
        {
            Task1();
            Task2();
            Task3();
            Task4();
            DZ1();
            DZ2();
        }
        // Упражнение 5.1 Написать метод, возвращающий наибольшее из двух чисел. Входные параметры метода – два целых числа.Протестировать метод.
        public static int GetMax(int a, int b)
        {
            return a > b ? a : b; // Используем тернарный оператор для краткости
        }
        static void Task1()
        {
            // Тестирование метода
            Console.WriteLine($"Максимум из 10 и 5: {GetMax(10, 5)}");  // Ожидаемый результат: 10
            Console.WriteLine($"Максимум из -3 и -7: {GetMax(-3, -7)}"); // Ожидаемый результат: -3
            Console.WriteLine($"Максимум из 0 и 0: {GetMax(0, 0)}");   // Ожидаемый результат: 0
            Console.WriteLine($"Максимум из 1000 и -200: {GetMax(1000, -200)}"); // Ожидаемый результат: 1000
            Console.WriteLine($"Максимум из int.MaxValue и 1: {GetMax(int.MaxValue, 1)}"); // Ожидаемый результат: int.MaxValue
            Console.WriteLine($"Максимум из int.MinValue и -1: {GetMax(int.MinValue, -1)}"); // Ожидаемый результат: -1
        }
        // Упражнение 5.2 Написать метод, который меняет местами значения двух передаваемых параметров.Параметры передавать по ссылке.Протестировать метод.
        public static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        static void Task2()
        {
            int x = 10;
            int y = 5;

            Console.WriteLine($"Исходные значения: x = {x}, y = {y}");

            Swap(ref x, ref y); // Передаем параметры по ссылке с помощью ref

            Console.WriteLine($"Значения после обмена: x = {x}, y = {y}"); // x и y изменились


            //Дополнительное тестирование
            x = -5;
            y = 0;
            Console.WriteLine($"Исходные значения: x = {x}, y = {y}");
            Swap(ref x, ref y);
            Console.WriteLine($"Значения после обмена: x = {x}, y = {y}");


            x = int.MaxValue;
            y = int.MinValue;
            Console.WriteLine($"Исходные значения: x = {x}, y = {y}");
            Swap(ref x, ref y);
            Console.WriteLine($"Значения после обмена: x = {x}, y = {y}");

        }
        // Упражнение 5.3 Написать метод вычисления факториала числа, результат вычислений передавать в выходном параметре.Если метод отработал успешно, то вернуть значение true; если в процессе вычисления возникло переполнение, то вернуть значение false. Для отслеживания переполнения значения использовать блок checked
        public static bool CalculateFactorial(int n, out long factorial)
        {
            factorial = 1;

            if (n < 0)
            {
                throw new ArgumentException("Факториал определен только для неотрицательных чисел.");
            }

            try
            {
                checked
                {
                    for (int i = 1; i <= n; i++)
                    {
                        factorial *= i;
                    }
                }
                return true;
            }
            catch (OverflowException)
            {
                return false; // Переполнение произошло
            }
        }
        static void Task3()
        {
            int num = 20; //Попробуйте разные значения, например, 20, 25, 30

            long fact;
            bool success = CalculateFactorial(num, out fact);

            if (success)
            {
                Console.WriteLine($"Факториал {num} равен {fact}");
            }
            else
            {
                Console.WriteLine($"Переполнение при вычислении факториала {num}");
            }


            //Пример с отрицательным числом:
            try
            {
                bool success2 = CalculateFactorial(-5, out fact);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        // Упражнение 5.4 Написать рекурсивный метод вычисления факториала числа
        public static long CalculateFactorialRecursive(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("Факториал определен только для неотрицательных чисел.");
            }
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * CalculateFactorialRecursive(n - 1);
            }
        }
        static void Task4()
        {
            try
            {
                Console.WriteLine($"Факториал 5: {CalculateFactorialRecursive(5)}");  // Вывод: 120
                Console.WriteLine($"Факториал 0: {CalculateFactorialRecursive(0)}");  // Вывод: 1
                Console.WriteLine($"Факториал 10: {CalculateFactorialRecursive(10)}"); // Вывод: 3628800

                // Этот вызов вызовет переполнение стека (StackOverflowException) для больших чисел
                //Console.WriteLine($"Факториал 25: {CalculateFactorialRecursive(25)}"); 
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            catch (StackOverflowException ex)
            {
                Console.WriteLine($"Ошибка: Переполнение стека.  Рекурсивный вызов слишком глубок. {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла неизвестная ошибка: {ex.Message}");
            }

        }
        // Домашнее задание 5.1 Написать метод, который вычисляет НОД двух натуральных чисел (алгоритм Евклида). Написать метод с тем же именем, который вычисляет НОД трех натуральных чисел.
        public static int GCD(int a, int b)
        {
            if (a == 0) return b;
            if (b == 0) return a;
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public static int GCD(int a, int b, int c)
        {
            return GCD(GCD(a, b), c); // Используем метод для двух чисел рекурсивно
        }
        static void DZ1()
        {
            Console.WriteLine($"НОД(12, 18) = {GCD(12, 18)}"); // Вывод: 6
            Console.WriteLine($"НОД(48, 18) = {GCD(48, 18)}"); // Вывод: 6
            Console.WriteLine($"НОД(12, 18, 24) = {GCD(12, 18, 24)}"); // Вывод: 6
            Console.WriteLine($"НОД(24, 36, 72) = {GCD(24, 36, 72)}"); // Вывод: 12

            //Обработка ошибок (необязательно, но желательно)
            try
            {
                Console.WriteLine($"НОД(0, 10) = {GCD(0, 10)}"); // Вывод 10
                Console.WriteLine($"НОД(10,0) = {GCD(10, 0)}"); // Вывод 10
                Console.WriteLine($"НОД(0,0) = {GCD(0, 0)}"); // Вывод 0
                Console.WriteLine($"НОД(12, 18, 0) = {GCD(12, 18, 0)}"); // Вывод 6
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        // Домашнее задание 5.2 Написать рекурсивный метод, вычисляющий значение n-го числа ряда Фибоначчи.Ряд Фибоначчи – последовательность натуральных чисел 1, 1, 2, 3, 5, 8, 13... Для таких чисел верно соотношение Fk = Fk - 1 + Fk - 2.
        public static long FibonacciRecursive(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("Индекс числа Фибоначчи не может быть отрицательным.");
            }
            if (n <= 1)
            {
                return n; // Базовый случай: F0 = 0, F1 = 1
            }
            else
            {
                return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
            }
        }
        static void DZ2()
        {
            try
            {
                Console.WriteLine($"Число Фибоначчи с индексом 0: {FibonacciRecursive(0)}"); // 0
                Console.WriteLine($"Число Фибоначчи с индексом 1: {FibonacciRecursive(1)}"); // 1
                Console.WriteLine($"Число Фибоначчи с индексом 2: {FibonacciRecursive(2)}"); // 1
                Console.WriteLine($"Число Фибоначчи с индексом 10: {FibonacciRecursive(10)}"); // 55
                                                                                               //Console.WriteLine($"Число Фибоначчи с индексом 50: {FibonacciRecursive(50)}"); // Переполнение стека (StackOverflowException) для больших значений n
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            catch (StackOverflowException ex)
            {
                Console.WriteLine($"Ошибка: Переполнение стека. Рекурсивный вызов слишком глубок. {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла неизвестная ошибка: {ex.Message}");
            }
        }



    }
}
