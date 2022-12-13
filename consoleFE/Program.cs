using System.Net;
using System.Text.Json;

namespace consoleFE;
class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, User!\nPlease enter a name, color, strength, and dexterity separated by a space");
        string[] newEmpReimbursement = Console.ReadLine().Split(" ", 4);

        Console.Write("You entered: ");
        foreach (string x in newEmpReimbursement)
        {
            Console.Write($"{x} - ");
        }
        Console.WriteLine();
        HttpClient http = new HttpClient();

        HttpResponseMessage pc = await http.GetAsync($"https://localhost:7007/api/EmpReimbursement/register/{newEmpReimbursement[0]}/{newEmpReimbursement[1]}/{newEmpReimbursement[2]}/{newEmpReimbursement[3]}");


        if (pc.IsSuccessStatusCode && pc.StatusCode == HttpStatusCode.Created)
        {
            String res = await pc.Content.ReadAsStringAsync();
            Console.WriteLine(res);
            EmpReimbursementClass1? pc11 = JsonSerializer.Deserialize<EmpReimbursementClass1>(res);
            Console.WriteLine($"{pc11.Name} is colored {pc11.Color}. They are {pc11.strength} points string and {pc11.dexterity} dexterous");
        }
        else
        {
            Console.WriteLine("The request fialed!!!");
        }










    }
}
