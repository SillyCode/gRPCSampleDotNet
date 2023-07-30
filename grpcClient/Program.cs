using Grpc.Net.Client;
using GrpcEmployee;

//var birthdate = new DateTime(1984, 04, 13);
//birthdate = DateTime.SpecifyKind(birthdate, DateTimeKind.Utc);

/*
For testing reading/wrting compiled protobuf
Employee employee = new()
{
    FirstName = "Absalom",
    LastName = "Smith",
    BirthDate = Timestamp.FromDateTime(birthdate),
    MaritalStatus = Employee.Types.MaritalStatus.Married,
};
employee.PreviousEmployers.Add("IBM");
employee.PreviousEmployers.Add("INTEL");

employee.Relatives.Add("Brother", "Morty");
employee.Relatives.Add("Sister", "Summer");


using var channel = GrpcChannel.ForAddress("https://localhost:7042");


//For internal testing of protobuf
using (var output = File.Create("emp.dat"))
{
    employee.WriteTo(output);
}

Employee employeeFromFile;
using (var input = File.OpenRead("emp.dat"))
{
    employeeFromFile = Employee.Parser.ParseFrom(input);
}

EmployeeId employeeId = new EmployeeId() { Id = 1 };

var client = new EmployeeService.EmployeeServiceClient(channel);
var reply = client.GetEmployee(employeeId);

Console.WriteLine("GRPC Client");
*/

EmployeeId employeeId1 = new EmployeeId() { Message = "1" };
EmployeeId employeeId2 = new EmployeeId() { Message = "2" };
EmployeeId employeeId3 = new EmployeeId() { Message = "18" };

Console.WriteLine("GRPC Client");
using var channel = GrpcChannel.ForAddress("http://localhost:5109");
var client = new Employee.EmployeeClient(channel);
var reply = client.GetEmployeeById(employeeId1);

Console.WriteLine("Received employee Data");
Console.WriteLine(reply.FirstName);
Console.WriteLine("\n");

reply = client.GetEmployeeById(employeeId2);

Console.WriteLine("Received employee Data");
Console.WriteLine(reply.FirstName);
Console.WriteLine("\n");

reply = client.GetEmployeeById(employeeId3);
if (reply != null)
{
    Console.WriteLine("Received employee Data");
    Console.WriteLine(reply.FirstName);
    Console.WriteLine("\n");
} else
{
    Console.WriteLine("Received employee Data");
}