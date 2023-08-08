using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcEmployee;

namespace GrpcService1.Services
{
    public class EmployeeService : Employee.EmployeeBase
    {
        private List<EmployeeResponse> employees;
        private readonly ILogger<EmployeeService> _logger;
        public EmployeeService(ILogger<EmployeeService> logger)
        {
            _logger = logger;
            GenerateEmployees();
        }

        public override Task<EmployeeResponse> GetEmployeeById(EmployeeId request, ServerCallContext context)
        {
            _logger.LogInformation("Received request to: GetEmployeeById");
            _logger.LogInformation("EmployeeById: " + request);

            EmployeeResponse employeeResponse = new EmployeeResponse();
            if (request != null) {
                employeeResponse = GetEmployee(request.Id);
            }
            return Task.FromResult(employeeResponse);
        }

        private EmployeeResponse GetEmployee(int id)
        {
            EmployeeResponse? employee = employees.FirstOrDefault(x => x.Id == id);
			if(employee == null) {
				return new EmployeeResponse();
			}
            return employee;
        }

        private void GenerateEmployees()
        {
            employees = new List<EmployeeResponse>();
            int counter = 5;
            for (int i = 1; i <= counter; i++)
            {
                var birthdate = new DateTime(1984, 04, 13);
                birthdate = DateTime.SpecifyKind(birthdate, DateTimeKind.Utc);

                var employeeResponse = new EmployeeResponse()
                {
                    Id = i,
                    FirstName = "Absalom" + i,
                    LastName = "Smith" + i,
                    BirthDate = Timestamp.FromDateTime(birthdate),
                    MaritalStatus = EmployeeResponse.Types.MaritalStatus.Married,
                };
                employeeResponse.PreviousEmployers.Add("IBM");
                employeeResponse.PreviousEmployers.Add("INTEL");
                employeeResponse.CurrentAddress = new Address()
                {
                    City = "Hiafa",
                    StreetName = "Herzel",
                    HouseNumber = 5,
                    ZipCode = "123455",
                };
                employees.Add(employeeResponse);
            }
        }
    }
}
