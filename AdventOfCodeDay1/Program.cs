
using System.Net.Security;
using System.Reflection;
using System.Text;

public class adventOfCodeDay1
{
    public static HashSet<int> LeftList = [];
    public static HashSet<int> RightList = [];
    
    public static void Main(string[] args)
    {
        var test = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        
        FileStream fs = new FileStream(Path.Combine(test, "opdracht"), FileMode.Open);

        using (StreamReader sr = new StreamReader(fs))
        {
            while (!sr.EndOfStream)
            {
                string? line = sr.ReadLine();
                
                List<string> values = line?.Split(' ').Select(x => x.Trim()).Where(x => x.Length > 0).ToList();
                LeftList.Add(int.Parse(values[0]));
                RightList.Add(int.Parse(values[1]));
                values.Clear();
                
            }
        }
        
        int sum = 0;
        
        //first Exercise
        //LeftList.Sort();
        //RightList.Sort();

        // int i = 0;
        // foreach (int LeftItem in LeftList)
        // {
        //     sum = sum + Math.Abs(LeftItem - RightList[i]);
        //     i++;
        // }
        
        
        foreach (int leftListItem in LeftList)
        {
            int count = RightList.Where(x => x.Equals(leftListItem)).Count();
            sum = sum + (leftListItem * count);
        }
        
        Console.WriteLine(sum.ToString() + " is your answer");
    }
}