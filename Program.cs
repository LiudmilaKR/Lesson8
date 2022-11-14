/*Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2

Console.WriteLine("Введите количество строк: ");
int rows = int.Parse(Console.ReadLine()!);
Console.WriteLine("Введите количество столбцов: ");
int colums = int.Parse(Console.ReadLine()!);

int[,] matrix = GetMatrix(rows, colums, 0, 9);
PrintMatrix(matrix);
Console.WriteLine();
SortMatrix(matrix);
PrintMatrix(matrix);

void SortMatrix (int[,] matr)
{
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            int max = j;
            for (int k = j + 1; k < matr.GetLength(1); k++)
            {
                if (matr[i, k] > matr[i, max]) max = k;
            }
            int temp = matr[i, j];
            matr[i, j] = matr[i, max];
            matr[i, max] = temp;
        }
    }
}

int[,] GetMatrix(int m, int n, int minValue, int maxValue)
{
    int [,] result = new int[m, n];

    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            result[i, j] = new Random().Next(minValue, maxValue + 1);
        }
    }
    return result;
}

void PrintMatrix(int[,] Matr)
{
    for (int i = 0; i < Matr.GetLength(0); i++)
    {
        for (int j = 0; j < Matr.GetLength(1); j++)
        {
            Console.Write($"{Matr[i, j]} ");
        }
        Console.WriteLine();
    }
}
*/
/*
Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

Console.WriteLine("Введите количество строк: ");
int rows = int.Parse(Console.ReadLine()!);
Console.WriteLine("Введите количество столбцов: ");
int colums = int.Parse(Console.ReadLine()!);

int[,] matrix = GetMatrix(rows, colums, 0, 9);
PrintMatrix(matrix);
Console.WriteLine($"Наименьшая сумма равна {MatrixMinRows(matrix)} в строке с индексом {MatrixMinRowsIndex(matrix)}");

int MatrixMinRows (int[,] matr)
{
    int min = 0;
    int sum = 0;
    for (int j = 0; j < matr.GetLength(1); j++)
    {
        min = min + matr[0, j];
    }
    for (int i = 1; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            sum = sum + matr[i, j];
        }
        if (sum < min) min = sum;
        sum = 0;
    }
    return min;
}

int MatrixMinRowsIndex (int[,] matr)
{
    int min = 0;
    int sum = 0;
    int minIndex = 0;
    for (int j = 0; j < matr.GetLength(1); j++)
    {
        min = min + matr[0, j];
    }
    for (int i = 1; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            sum = sum + matr[i, j];
        }
        if (sum < min)
        {
            min = sum;
            minIndex = i;
        }
        sum = 0;
    }
    return minIndex;
}

int[,] GetMatrix(int m, int n, int minValue, int maxValue)
{
    int [,] result = new int[m, n];

    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            result[i, j] = new Random().Next(minValue, maxValue + 1);
        }
    }
    return result;
}

void PrintMatrix(int[,] Matr)
{
    for (int i = 0; i < Matr.GetLength(0); i++)
    {
        for (int j = 0; j < Matr.GetLength(1); j++)
        {
            Console.Write($"{Matr[i, j]} ");
        }
        Console.WriteLine();
    }
}
*/
/*
Задача 58: Задайте две квадратные матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 1
произведение сопряженных матриц a(l,m) и b(m,n) это - матрица c(l,n), где
c(i,j) = сумма для r от 1 до m (a(i,r)*b(r,j))

Console.Write("Введите размерность квадратных матриц: ");
int rows1 = int.Parse(Console.ReadLine()!);
int colums1 = rows1;
int rows2 = colums1;
int colums2 = rows2;

int[,] matrix1 = GetMatrix(rows1, colums1, 0, 9);
PrintMatrix(matrix1);

Console.WriteLine();

int[,] matrix2 = GetMatrix(rows2, colums2, 0, 9);
PrintMatrix(matrix2);

Console.WriteLine();
MultMatrix(matrix1, matrix2);

void MultMatrix(int[,] matr1, int[,] matr2)
{
    if(matr1.GetLength(1) == matr2.GetLength(0))
    {
        int[,] resMatr = new int[matr1.GetLength(0), matr2.GetLength(1)];
        for (int i = 0; i < matr1.GetLength(0); i++)
        {
            for (int j = 0; j < matr2.GetLength(1); j++)
            {
                for (int k = 0; k < matr1.GetLength(1); k++)
                {
                resMatr[i, j] += matr1[i, k] * matr2[k, j];
                }
            }
        }
        PrintMatrix(resMatr);
    }
    else
    {
        Console.WriteLine("Матрицы не сопряжены, их произведение невозможно");
    }
}

int[,] GetMatrix(int m, int n, int minValue, int maxValue)
{
    int [,] result = new int[m, n];

    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            result[i, j] = new Random().Next(minValue, maxValue + 1);
        }
    }
    return result;
}

void PrintMatrix(int[,] Matr)
{
    for (int i = 0; i < Matr.GetLength(0); i++)
    {
        for (int j = 0; j < Matr.GetLength(1); j++)
        {
            Console.Write($"{Matr[i, j]} ");
        }
        Console.WriteLine();
    }
}
*/
/*
Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.
Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)

int[,,] matrix = GetMatrix(2, 2, 2, 11, 100);
PrintMatrix(matrix);

int[,,] GetMatrix(int m, int n, int l, int minValue, int maxValue)
{
    int[,,] result = new int[m, n, l];
    int[] collection = GetArray(m * n * l, minValue, maxValue);
        
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            for (int k = 0; k < l; k++)
            {
                result[i, j, k] = collection[4 * i + 2 * j + k];
            }
        }
    }
    return result;
}

void PrintMatrix(int[,,] matr)
{
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            
            for (int k = 0; k < matr.GetLength(2); k++)
            {
                Console.Write($"{matr[i, j, k]}({i},{j},{k})  ");
            }
            Console.WriteLine();
        }
    }
}

// Проверка уникальности цифр в одномерном массиве

int[] GetArray(int size, int minValue, int maxValue)
{
    int[] arr = new int[size];
    for (int i = 0; i < size; i++)
    {
        int num = new Random().Next(minValue, maxValue);
        if (arr.Contains(num)) i--;
        else arr[i] = num;
    }
    return arr;
}
*/
/*
Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07

int[,] matrix = GetMatrix(17, 15);
PrintMatrix(matrix);

int[,] GetMatrix(int m, int n)
{
    int[,] result = new int[m, n];
    int count = 0;
    int y;
    if (m % 2 == 0) y = m / 2;
    else y = m / 2 + 1;
    
    for (int x = 0; x < y; x++)
    {
        for (int j = x; j < n - x; j++)
        {
            int a = x;
            if (result[a, j] == 0)
            {
                count++;
                result[a, j] = count;
            }
            else break;
        }
        for (int i = 1 + x; i < m - x; i++)
        {
            int b = n - 1 - x;
            if (result[i, b] == 0)
            {
                count++;
                result[i, b] = count;
            }
            else break;
        }
        for (int j = n - 2 - x; j > x - 1; j--)
        {
            int c = m - 1 - x;
            if (result[c, j] == 0)
            {
                count++;
                result[c, j] = count;
            }
            else break;
        }
        for (int i = m - 2 - x; i > x; i--)
        {
            int d = x;
            if (result[i, d] == 0)
            {
                count++;
                result[i, d] = count;
            }
            else break;
        }
    }
    return result;
}

void PrintMatrix(int[,] matr)
{
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            Console.Write($"{matr[i, j]:D3} ");
        }
        Console.WriteLine();
    }
}
*/
/*
Отсортировать нечетные столбцы(смотрите по индексам) массива по возрастанию.
Вывести массив изначальный и массив с отсортированными нечетными столбцами
*/
Console.Write("Введите количество строк: ");
int rows = int.Parse(Console.ReadLine()!);
Console.Write("Введите количество столбцов: ");
int colums = int.Parse(Console.ReadLine()!);

int[,] matrix = GetMatrix(rows, colums, 0, 9);
PrintMatrix(matrix);
Console.WriteLine();
SortColMatrix(matrix);
PrintMatrix(matrix);

void SortColMatrix (int[,] matr)
{
    for (int j = 1; j < matr.GetLength(1); j+=2)
    {
        for (int i = 0; i < matr.GetLength(0); i++)
        {
            int min = i;
            for (int k = i + 1; k < matr.GetLength(0); k++)
            {
                if (matr[k, j] < matr[min, j]) min = k;
            }
            int temp = matr[i, j];
            matr[i, j] = matr[min, j];
            matr[min, j] = temp;
        }
    }
}

int[,] GetMatrix(int m, int n, int minValue, int maxValue)
{
    int [,] result = new int[m, n];

    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            result[i, j] = new Random().Next(minValue, maxValue + 1);
        }
    }
    return result;
}

void PrintMatrix(int[,] Matr)
{
    for (int i = 0; i < Matr.GetLength(0); i++)
    {
        for (int j = 0; j < Matr.GetLength(1); j++)
        {
            Console.Write($"{Matr[i, j]} ");
        }
        Console.WriteLine();
    }
}