using System;
class HelloWorld {
    static void Main() {
        int[] myArray = new int[5];
        FunctionsOfArray arrayClass = new FunctionsOfArray();
        arrayClass.FillArray(myArray);
        arrayClass.PrintArray(myArray);
        arrayClass.MaxAndMinElemet(myArray);
    }
}

public class FunctionsOfArray
{
    public void FillArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = i;
        }
    }

    public void PrintArray(int[] array)
    {
        foreach (var number in array)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();
    }

    public void MaxAndMinElemet(int[] array)
    {
        int maxElement = array[0], minElement = array[0];
        int maxIndex, minIndex;
        for (int i = 1; i < array.Length; i++)
        {
            maxElement = array[i] > maxElement ? array[i] : maxElement;
            minElement = array[i] < minElement ? array[i] : minElement;
        }

        Console.Write("max:" +  maxElement);
        Console.Write("min:" +  minElement);

    }
    
}
