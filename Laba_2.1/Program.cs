List<int> numList = new List<int>{1, 10, 20};
List<int> sortList = new List<int>{};

foreach (int testNum in numList)
{
    if (testNum < 19 && testNum >= 1)
    {
        sortList.Add(testNum);
        Console.WriteLine(testNum + " ");
    }
}