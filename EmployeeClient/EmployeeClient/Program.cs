using WebAPIClient;

Console.WriteLine("API Client");
EmployeeAPIClient.DeleteEmployee(16).Wait(16);

Console.ReadLine();
