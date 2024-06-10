

using Plotly.NET;

Random random = new Random();

int Sort(int size)
{
    int temp = 0;
    for (int i = 0; i < 5; i++)
    {
        temp += BogoSort(CreateRandomList(size), size);
    }
    Console.WriteLine(Convert.ToInt32((float)temp / 5));
    return Convert.ToInt32((float) temp / 5); //returns average of 5 attempts
}

List<int> CreateRandomList(int size)
{
    List<int> list = new List<int>();
    for (int i = 0; i < size; i++)
    {
        list.Add(random.Next(0, size));
    }
    return list;
}

bool IsSorted(List<int> list, int size)
{
    for (int i = 0; i < size - 1; i++)
    {
        if (list[i] > list[i + 1])
        {
            return false;
        }
    }
    return true;
}

List<int> Shuffle(List<int> list, int size)
{
    for (int i = 0; i < size; i++)
    {
        int tempNum = list[i];
        int randomNum = random.Next(0, size - 1);
        list[i] = list[randomNum];
        list[randomNum] = tempNum;
    }
    return list;
}

int BogoSort(List<int> list, int size)
{
    int timesRan = 0;
    while (!IsSorted(list, size))
    {
        timesRan += 1;
        Shuffle(list, size);
    }
    Console.WriteLine($"Did it in {timesRan} tries!");
    return timesRan;
}

List<int> resultList = new List<int>();

for(int i = 1; i < 13; i++)
{
    resultList.Add(Sort(i));
}

Plotly.NET.CSharp.Chart.Point<int, int, string>(
    x: resultList,
    y: Enumerable.Range(1, 13).ToList()
)
.WithTraceInfo("Bogo sort", ShowLegend: true)
.Show();

