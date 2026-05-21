using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLHDotNetInternshipTraining.DapperSample
{
    public class Student
    {
        public int StudentId { get; set; }

        public string StudentNo { get; set; } = null!;

        public string StudentName { get; set; } = null!;

        public string FatherName { get; set; } = null!;

        public string Address { get; set; } = null!;

        public DateTime DateOfBirth { get; set; }

        public bool IsDelete { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime? ModifiedDateTime { get; set; }

        public string? ModifiedBy { get; set; }
    }
}
