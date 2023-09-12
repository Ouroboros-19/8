using System.Diagnostics;
class Program
{
    static void Main()
    {
        Random r = new Random();
        int a = 10000;
        int[] array = new int[a];
        int[] arrayD = new int[a];
        int b, k = 0;
        for (int i = 0; i < a; i++)
        {
            arrayD[i] = r.Next(-9, 10);
            array[i] = arrayD[i];
        }
        Stopwatch sw = new Stopwatch();
        sw.Start();
        while (k == 0)
        {
            for (int i = 0; i < a - 1; i++)
                if (array[i] > array[i + 1])
                {
                    b = array[i + 1];
                    array[i + 1] = array[i];
                    array[i] = b;
                }
            for (int i = 0; i < a - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    k = 0;
                    break;
                }
                k = 1;
            }
        }
        sw.Stop();
        Console.WriteLine("Сортировка пузырьком:     {0}", sw.Elapsed);
        for (int i = 0; i < a; i++)
            array[i] = arrayD[i];
        Stopwatch per = new Stopwatch();
        per.Start();
        int j, x;
        k = 0;
        while (k == 0)
        {
            for (int i = 1; i < a; i++)
            {
                x = array[i];
                j = i;
                while (j > 0 && array[j - 1] > x)
                {
                    b = array[j];
                    array[j] = array[j - 1];
                    array[i - 1] = b;
                    j--;
                }
                array[j] = x;
            }
            for (int i = 0; i < a - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    k = 0;
                    break;
                }
                k = 1;
            }
        }
        per.Stop();
        Console.WriteLine("Сортировка перестановкой: {0}", per.Elapsed);
        Stopwatch arS = new Stopwatch();
        arS.Start();
        Array.Sort(arrayD);
        arS.Stop();
        Console.WriteLine("Сортировка Array.Sort():  {0}", arS.Elapsed);
        Console.WriteLine();
        Console.WriteLine("");
        Console.WriteLine("Повтор?( enter - да; люб. др. клавиша - нет )");
        string povtor = Convert.ToString(Console.ReadLine());
        if (povtor == "")
            Main();
    }
}