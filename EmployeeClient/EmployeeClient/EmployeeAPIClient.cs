using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIClient
{
    internal class EmployeeAPIClient
    {
        static Uri uri = new Uri("http://localhost:5119");

        public static async Task CallGetAllEmployees()
        {
            //58345
            using (var client = new HttpClient()) 
            {
                client.BaseAddress = uri;
                HttpResponseMessage response = await client.GetAsync("GetAllEmployee");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode) 
                {
                    string x = await response.Content.ReadAsStringAsync();
                    await Console.Out.WriteAsync(x);
                }
            }
        }
        public static async Task CallGetAllEmployeesJson() 
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                List<EmpViewModel> employees = new List<EmpViewModel>();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("GetAllEmployee");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string x = await response.Content.ReadAsStringAsync();
                    employees = JsonConvert.DeserializeObject<List<EmpViewModel>>(x);
                    foreach (EmpViewModel emp in employees)
                    {
                        await Console.Out.WriteLineAsync($"{emp.EmpId},{emp.FirstName},{emp.LastName},{emp.Title},{emp.City},{emp.HireDate},{emp.BirthDate},{emp.ReportsTo}");
                    }
                }
            }
        }
    }   
}
