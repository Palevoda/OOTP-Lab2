using System;
using System.Text;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.Serialization.Formatters;
using System.Collections.Generic;

namespace Лабораторная_работа_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Exercise1();
            Exercise2();
            Exercise3();
            Exercise4();
            int[] Array = {1,2,3,4,5,6,7,8,9 };
            String str = "Sanyok";
            var FuncResult = MyFirstFunction(Array, str);

            Console.WriteLine("Результат первой функции: " + FuncResult);

            Console.WriteLine("Результат функции check: " + Exercise6_checked());
            Console.WriteLine("Результат функции uncheck: " + Exercise6_unchecked());
            
        }


        static void Exercise1()
        {
            //1.а
            Console.WriteLine("Hello World!");
            bool i1 = false;
            byte i2 = 255;
            sbyte i3 = -12;
            short i4 = 256;
            ushort i5 = 666;
            int i6 = 999;
            uint i7 = 0x123456;
            long i8 = 1000;
            ulong i9 = 0xABCDEF;
            float f1 = 12.1F;
            double d1 = 123.456;
            decimal d2 = 321.65431234M;

            char ch1 = 'A';
            char ch2 = '\x5A';
            char ch3 = '\u0420';

            string s1 = "Hello World!";

            object o1 = 1;
            object o2 = 1.25;
            object o3 = "hello world;";

            Console.Write("Булевая переменная:\t" + i1 + "\nЦелочисленные переменные:\t" + i2 + "\t" + i3 + "\t" + i4 + "\t" + i5 + "\t" + i6 + "\t" + i7 + "\t" + i8 + "\t" + i9 + "\n");
            Console.WriteLine("Числа с плавающей точкой:\t" + f1 + "\t" + d1 + "\t" + d2);
            Console.WriteLine("Символьный тип данных:\t" + ch1 + "\t" + ch2 + "\t" + ch3);
            Console.WriteLine("Переменная типа string:\t" + s1);
            Console.WriteLine("Переменная типа object:\t" + o1 + "\t" + o2 + "\t" + o3);

            //1.б
            Console.WriteLine("Приведение типов");


            Console.WriteLine(i6 + "\t" + d1 + "\t" + i2 + "\t" + d1 + "\t" + ch1 + "\t" + o2 + "\t" + f1 + "\t" + d2 + "\t" + i5 + "\t" + i7);
            //Явное преобразование
            i6 = (int)f1;
            d1 = (double)i2;
            i2 = (byte)d1;
            d1 = Convert.ToDouble(i1);
            i7 = Convert.ToUInt16(ch1);

            //Неявное преобразование
            o2 = ch1;
            f1 = i4;
            d2 = i5;
            i5 = ch1;
            i7 = i5;

            Console.WriteLine(i6 + "\t" + d1 + "\t" + i2 + "\t" + d1 + "\t" + ch1 + "\t" + o2 + "\t" + f1 + "\t" + d2 + "\t" + i5 + "\t" + i7);

            //1c

            // int sh1 = 12;
            //  object ob1 = sh1; //упаковка
            //    double fl2 = (double)ob1; //Распаковка

            //1d 
            var v1 = ch1;
            var sv1 = s1;
            var v2 = 18.123;

            //1e

            System.Nullable<double> nul1 = null;
            //1f
            // var v3 = 15;
            // v3 = s1;  

        }

        static void Exercise2()
        {
            string str1 = "Hello";
            string str2 = " world!";
            string str3 = "Aliaksandr Palevoda";
            string fullstr = "Aliaksandr Palevoda, Hello!";

            Console.WriteLine("Демонстрация сцепления: " + String.Concat(str1, str2));

            Console.WriteLine("Выделение подстроки: " + str3.Substring(11));

            string[] words = fullstr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                Console.Write("\t" + word);
            }
            Console.Write("\n");

            Console.WriteLine("Вставка подстроки в заданную позицию: " + str1.Insert(5, str2));

            Console.WriteLine("Удаление подстроки: " + str2.Remove(6, 1));

            string strSource = "changed";
            char[] destination = { 'T', 'h', 'e', ' ', 'i', 'n', 'i', 't', 'i', 'a', 'l', ' ',
                'a', 'r', 'r', 'a', 'y' };
            Console.WriteLine(destination);

            strSource.CopyTo(0, destination, 4, strSource.Length);

            char[] fullstr_char = fullstr.ToCharArray();
            str2.CopyTo(0, fullstr_char, fullstr_char.Length - 7, str2.Length);
            Console.WriteLine(fullstr_char);

            // Задание №2c

            string freeStr = "";
            string nullStr = null;
            string dopStr = "qwer";

            Console.Write(String.IsNullOrEmpty(freeStr) + "\n");
            Console.Write(String.IsNullOrEmpty(nullStr) + "\n");
            Console.Write(String.IsNullOrEmpty(dopStr) + "\n");

            dopStr = dopStr.Remove(0, dopStr.Length);
            Console.Write(String.IsNullOrEmpty(dopStr) + "\n");

            // Задание №2d
            StringBuilder myString = new StringBuilder("ALiaksandr Palevoda");
            myString.Append(" [[");
            myString.Insert(myString.Length, "Ivanovich]");
            myString.Remove(20, 1);
            Console.Write(myString + "\n");
        }

        static void Exercise3()
        {
            //3a
            int[,] Array = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            for (int i = 0; i < Array.Length / 3; i++)
            {
                for (int j = 0; j < Array.Length / 3; j++)
                {
                    Console.Write(Array[i, j] + "\t");
                }
                Console.Write("\n");
            }

            //3b
            /*
            String[] StrArray = new String[] {"String1", "String2", "String3", "String4", "String5" };
            Console.Write("Длинна массива StrArray: " +  StrArray.Length + "\nИсходный массив:");
            foreach (String element in StrArray)
            {
                Console.Write(element + "\t");
            }
            Console.Write("\nВыберите номер элемента, позицию которого нужно поменять: ");
            int position = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nВыберите новое значение: ");
            StrArray[position - 1] = Console.ReadLine();            
            Console.Write("\nНовый массив:");
            foreach (String element in StrArray)
            {
                Console.Write(element + "\t");
            }*/
            //
            //  3c
            /*
            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[2];
            jaggedArray[1] = new int[3];
            jaggedArray[2] = new int[4];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write("\nВведите значение для элемента в строке " + Convert.ToInt32(i+1) + " столбце " + Convert.ToInt32(j + 1) + " ");
                    jaggedArray[i][j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            foreach (int[] line in jaggedArray)
            {
                Console.Write("\n");
                foreach (int element in line)
                { 
                    Console.Write(element + "\t");
                }
            }

    */
            //3d
            String[] StrArray1 = new String[] { "String1", "String2", "String3", "String4", "String5" };
            var VariablrArray = StrArray1;
            foreach (var element in VariablrArray)
            {
                Console.Write(element + "\t");
            }
        }

        static void Exercise4()
        {
            ValueTuple<int, string, char, string, ulong> AboutAlex = (19, "Aliaksandr", 'm', "Palevoda", 15112001);
            (int age, string name, char sex, string sorname, ulong dateofbirth) AboutAlex2 = (19, "Aliaksandr", 'm', "Palevoda", 15112001);
            Console.WriteLine("\n\n"+$" {AboutAlex}\n");

            Console.WriteLine("\n\n" + $" {AboutAlex2.name + "  " + AboutAlex2.sorname + " " + AboutAlex2.age + " years old"} \n");

            var AboutAlex3 = AboutAlex2;
            Console.WriteLine("\n\n" + $" {AboutAlex3}\n");

            var AboutAlex4 = ("Aliaksandr", "Palevoda", 19);
            Console.WriteLine("\n\n" + $" {AboutAlex4}\n");


            var check = EqualityComparer<ValueTuple<int, string, char, string, ulong>>.Default;
            if (check.Equals(AboutAlex2, AboutAlex3))
            {
                Console.WriteLine("Первый кортеж равен второму");
            }
            else
            {
                Console.WriteLine("Первый кортеж не равен второму");
            }

        }

        static Tuple<int, int, int, char> MyFirstFunction(int[] IntArr, String str)
        {
            int maxVal = 0; 
            int minVal = IntArr[0];
            int sum = 0;

            foreach (int element in IntArr)
            {
                if (element > maxVal) maxVal = element;
                if (element < minVal) minVal = element;
                sum += element;
            }

            char firstLetter = str[0];
            


            return new Tuple<int, int, int, char> (minVal, maxVal, sum, firstLetter);
        }

        static int Exercise6_checked()
        {
            int plus = 2;
            checked
            {
                int a = 2147483647;
                return a+plus;
            }
        }

        static int Exercise6_unchecked()
        {
            unchecked
            {
                int a = 2147483647;
                // return a + plus;
                return a;
            }
        }

    }
}
