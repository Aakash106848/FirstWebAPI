using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace WebAPIClient
{
    internal class EmployeeAPIClient
    {
        static Uri uri = new Uri("http://localhost:5119/");

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
        public static async Task AddNewEmployee() 
        {
            using (var client = new HttpClient()) 
            {
                client.BaseAddress = uri;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applicatino/json"));
                EmpViewModel emp = new EmpViewModel()
                {   EmpId = 10,
                    FirstName = "Dead",
                    LastName = "Lock",
                    City = "Moscow",
                    BirthDate = new DateTime(1998, 01, 02),
                    HireDate = new DateTime(2023, 04, 02),
                    Title = "Manager",
                    ReportsTo = 2
                };
                var myContent = JsonConvert.SerializeObject(emp);
                var buffer = Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = await client.PostAsync("AddEmployee", byteContent);
                response.EnsureSuccessStatusCode();
                if(response.IsSuccessStatusCode) 
                {
                    await Console.Out.WriteLineAsync(response.StatusCode.ToString());
                }
            }
        }
        public static async Task ModifyEmployee(int id) 
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applicatino/json"));
                EmpViewModel emp = new EmpViewModel()
                {
                    EmpId = 16,
                    FirstName = "Alive",
                    LastName = "Lock",
                    City = "Moscow",
                    BirthDate = new DateTime(1991, 01, 02),
                    HireDate = new DateTime(2023, 04, 02),
                    Title = "ExpeditionManager",
                    ReportsTo = 15
                };
                var myContent = JsonConvert.SerializeObject(emp);
                var buffer = Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = await client.PutAsync("ModifyEmployee", byteContent);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    await Console.Out.WriteLineAsync(response.StatusCode.ToString());
                }
            }
        }
        public static async Task DeleteEmployee(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applicatino/json"));
                HttpResponseMessage response = await client.DeleteAsync($"DeleteEmployee?id={id}");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    await Console.Out.WriteLineAsync(response.StatusCode.ToString());
                }
            }
        }
    }   
}
