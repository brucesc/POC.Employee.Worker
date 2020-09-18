using System;

namespace POC.Employee.Worker.Models
{
    public class EmployeeCT
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime HiredDate { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public int OperationType { get; set; }

        public byte[] Start_LSN { get; set; }
    }
}
