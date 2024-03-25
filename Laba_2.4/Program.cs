int[] array = new int[18];
int m = 7;
//FillArray
int count = -9;
for (int i = 0; i < array.Length; i++, count++)
{
    array[i] = count;
}

List<int> numList = new List<int>{};
foreach (int testNum in array)
{
    if (Math.Abs(testNum) > m)
    {
        numList.Add(testNum);
    }
}

Console.WriteLine("Число: " + m);
Console.WriteLine("1 масив: ");
foreach (int num in array)
{
    Console.Write(num + " ");
}

Console.WriteLine();
Console.WriteLine("2 масив");
foreach (int num in numList)
{
    Console.Write(num + " ");
}