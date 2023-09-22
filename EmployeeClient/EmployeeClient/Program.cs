// See https://aka.ms/new-console-template for more information
using WebAPIClient;

Console.WriteLine("API Client");
EmployeeAPIClient.CallGetAllEmployeesJson().Wait();
//Task.WaitAll(EmployeeAPIClient.CallGetAllEmployees());

Console.ReadLine();
