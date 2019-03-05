using System;
using System.Collections;

public class LinkedList
{
    public class Node
    {
        public int data;

        public Node right;

        public Node down;

        public int col;

        public int row;
    }

    private static Node head;

    private static int m = 3;

    private static int n = 3;

    private static Node construct(int[][] arr, int i, int j, int m, int n)
    {
        if (i > n - 1 || j > m - 1)
        {
            return null;
        }
        Node temp = new Node();
        temp.data = arr[i][j];
        temp.col = i;
        temp.row = j;
        temp.right = construct(arr, i, j + 1, m, n);
        temp.down = construct(arr, i + 1, j, m, n);
        return temp;
    }

    private static void MatrixCode(int[][] matrix)
    {
        for (int i = 0; i < matrix.Length; i++)
        {
            matrix[i] = new int[matrix.Length];
        }
        head = construct(matrix, 0, 0, matrix.Length, matrix.Length);
    }

    private static int[][] decode()
    {
        int[][] matrix = new int[m][];
        for (int i = 0; i < matrix.Length; i++)
        {
            matrix[i] = new int[matrix.Length];
        }
        return matrix;
    }

    private static void insert(int i, int j, int value)
    {
        for (Node Dp = head; Dp != null; Dp = Dp.down)
        {
            for (Node Rp = Dp; Rp != null; Rp = Rp.right)
            {
                if (Rp.col == i && Rp.row == j)
                {
                    Rp.data = value;
                }
            }
        }
    }

    private static void delete(int i, int j)
    {
        insert(i, j, 0);
    }

    private static ArrayList minList()
    {
        ArrayList minArr = new ArrayList();
        for (int j = 0; j < m; j++)
        {
            int minValue = int.MaxValue;
            for (int i = 0; i < m; i++)
            {
                int value = Read(i, j);
                minValue = Math.Min(minValue, value);
                Console.WriteLine("значение для строки:" + j + "x" + i + "=" + value + " min=" + minValue);
            }
            minArr.Add(minValue);
            Console.WriteLine("Минимальное значение для столбца:" + j + "=" + minValue);
        }
        return minArr;
    }

    private static int sumDiag()
    {
        int sum = 0;
        for (int i = 0; i < m; i++)
        {
            sum += Read(i, i);
        }
        return sum;
    }

    private static void transp()
    {
        for (int j = 0; j < n; j++)
        {
            for (int i = j + 1; i < m; i++)
            {
                int val3 = Read(j, i);
                int val2 = Read(i, j);
                insert(i, j, val3);
                insert(j, i, val2);
                Console.WriteLine("-----Транспонирование-----");
                display(head);
            }
        }
    }

    private static void sumCols(ref int j1, int j2)
    {
        int sum = 0;
        for (int k = 0; k < m; k++)
        {
            sum += Read(k, j1);
        }
        for (int i = 0; i < m; i++)
        {
            sum += Read(i, j2);
        }
        j1 = sum;
    }

    private static int Read(int i, int j)
    {
        for (Node Dp = head; Dp != null; Dp = Dp.down)
        {
            for (Node Rp = Dp; Rp != null; Rp = Rp.right)
            {
                if (Rp.col == i && Rp.row == j)
                {
                    return Rp.data;
                }
            }
        }
        return -1;
    }

    private static void display(Node head)
    {
        for (Node Dp = head; Dp != null; Dp = Dp.down)
        {
            for (Node Rp = Dp; Rp != null; Rp = Rp.right)
            {
                Console.Write(Rp.data + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("-----------------");
    }

    public static void Main()
    {
        int[][] arr = new int[m][];
        MatrixCode(arr);
        insert(0, 0, 2);
        insert(0, 1, 3);
        insert(0, 2, 5);
        insert(1, 0, 1);
        insert(1, 1, 2);
        insert(1, 2, 4);
        insert(2, 0, 1);
        insert(2, 1, 4);
        insert(2, 2, 3);
        display(head);
        delete(0, 1);
        display(head);
        minList();
        display(head);
        Console.WriteLine("Сумма по главной диагонали:" + sumDiag());
        int sum = 0;
        sumCols(ref sum, 2);
        Console.WriteLine("Сумма столбцов:" + sum);
        transp();
        display(head);
        decode();
        Console.ReadKey();
    }
}