using System;
using System.Collections.Generic;

class Node<T>
{
    public T Value { get; set; }
    public Node<T> Prev { get; set; }
}

class Stack<T> where T : IComparable<T>
{
    private List<T> values = new List<T>();
    private int maxSize;

    public Stack(int maxSize)
    {
        this.maxSize = maxSize;
    }

    public void Push(T value)
    {
        values.Add(value); // додає елемент у верхню частину стеку       
    }

    public T Peek()
    {
        return values[values.Count - 1]; // верхній елемент стеку       
    }

    public int Count
    {
        get { return values.Count; } // кількість елементів у стеці
    }

    public T Pop()
    {
        T verhItem = values[values.Count - 1]; // зберігаю верхній елемент
        values.RemoveAt(values.Count - 1); // видаляю верхній елемент
        return verhItem; // видалений елемент      
    }

    public static T FindMax(T a, T b, T c)
    {
        if (a.CompareTo(b) >= 0 && a.CompareTo(c) >= 0) return a;
        else if (b.CompareTo(a) >= 0 && b.CompareTo(c) >= 0) return b;
        else return c;

    }

    public static T FindMin(T a, T b, T c)
    {
        if (a.CompareTo(b) <= 0 && a.CompareTo(c) <= 0)
            return a;
        else if (b.CompareTo(a) <= 0 && b.CompareTo(c) <= 0)
            return b;
        else
            return c;
    }

    public static T CalcSum(T[] arr)
    {
        dynamic sum = default(T);
        foreach (T i in arr)
            sum += i;
        return sum;
    }
}

class Queue<T>
{
    private System.Collections.Generic.Queue<T> _queue = new System.Collections.Generic.Queue<T>();
    //private Queue<T> _queue = new Queue<T>(); - повертає переповнення помилку Process is terminated due to StackOverflowException 
    public void Enqueue(T item)
    {
        _queue.Enqueue(item); // додає новий елемент в кінець черги
    }
    public T Dequeue()
    {
        return _queue.Dequeue(); // видаляє і повертає перший елемент
    }
    public T Peek()
    {
        return _queue.Peek(); // перший елемент з черги не видаяємо
    }
    public int Count
    {
        get { return _queue.Count; } // скількі елементів у черзі
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"//1 шукаємо максимум");
        Console.WriteLine($"Максимум(5, 10, 3): {Stack<int>.FindMax(5, 10, 3)}");
        Console.WriteLine($"Максимум(15.6, 20.3, 7.8): {Stack<double>.FindMax(15.6, 20.3, 7.8)} \n");

        Console.WriteLine($"//2 пошук мiнiмума");
        Console.WriteLine($"Мiнiмум(5, 10, 3): {Stack<int>.FindMin(5, 10, 3)}");
        Console.WriteLine($"Мiнiмум(15.6, 20.3, 7.8): {Stack<double>.FindMin(15.6, 20.3, 7.8)}\n");

        Console.WriteLine($"//3 сумма (1, 2, 3, 4, 5) та (1.5, 2.5, 3.5, 4.5, 5.5)");
        int[] intArr = { 1, 2, 3, 4, 5 };
        double[] dArr = { 1.5, 2.5, 3.5, 4.5, 5.5 };

        Console.WriteLine($"Сума цiлих чисел: {Stack<int>.CalcSum(intArr)}");
        Console.WriteLine($"Сума double чисел: {Stack<double>.CalcSum(dArr)}\n");

        Console.WriteLine($"//4 стек з обмеженою максимальною кiлькiстю 10 елементiв (1, 2, 3)");
        Stack<int> intStack = new Stack<int>(10);
        intStack.Push(1);
        intStack.Push(2);
        intStack.Push(3);
        Console.WriteLine($"Перший елемент: {intStack.Peek()}, Кiлькiсть елементiв: {intStack.Count}");

        int видаленийЕлемент = intStack.Pop();
        Console.WriteLine($"Видалений елемент: {видаленийЕлемент}, перший елемент пiсля видалення: {intStack.Peek()}, кiлькiсть елементiв пiсля видалення: {intStack.Count}\n");

        Console.WriteLine($"//5 черга");

        Queue<string> sQueue = new Queue<string>();

        sQueue.Enqueue("First");
        sQueue.Enqueue("Second");
        sQueue.Enqueue("Third");
        Console.WriteLine($"Перший елемент: {sQueue.Peek()}, кiлькiсть елементiв: {sQueue.Count}\n");
    }
}
