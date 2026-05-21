using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLHDotNetInternshipTraining.DapperSample
{
    public class DapperSample
    {
        private readonly SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "SLHDotNetInternshipTraining",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };

        public void Read()
        {
            string query = @"SELECT [StudentId]
      ,[StudentNo]
      ,[StudentName]
      ,[FatherName]
      ,[Address]
      ,[DateOfBirth]
      ,[IsDelete]
      ,[CreatedDateTime]
      ,[CreatedBy]
      ,[ModifiedDateTime]
      ,[ModifiedBy]
  FROM [dbo].[Tbl_Student] Where IsDelete = 0";

            using IDbConnection db = new SqlConnection(builder.ConnectionString);
            db.Open();
            var lst = db.Query<Student>(query).ToList();
            foreach (var item in lst)
            {
                Console.WriteLine(item.StudentNo);
                Console.WriteLine(item.StudentName);
            }
        }

        public void Edit()
        {
            string query = @"SELECT [StudentId]
      ,[StudentNo]
      ,[StudentName]
      ,[FatherName]
      ,[Address]
      ,[DateOfBirth]
      ,[IsDelete]
      ,[CreatedDateTime]
      ,[CreatedBy]
      ,[ModifiedDateTime]
      ,[ModifiedBy]
  FROM [dbo].[Tbl_Student] Where StudentId = @StudentId AND IsDelete = 0";

            using IDbConnection db = new SqlConnection(builder.ConnectionString);
            db.Open();
            var item = db.Query<Student>(query, new Student { StudentId = 1 })
                .FirstOrDefault();

            if (item is null)
            {
                Console.WriteLine("No record found");
            }
            else
            {
                Console.WriteLine(item.StudentNo);
                Console.WriteLine(item.StudentName);
            }
        }

        public void Create()
        {
            string query = @"
INSERT INTO [dbo].[Tbl_Student]
(
    [StudentNo],
    [StudentName],
    [FatherName],
    [Address],
    [DateOfBirth],
    [IsDelete],
    [CreatedDateTime],
    [CreatedBy]
)
VALUES
(
    @StudentNo,
    @StudentName,
    @FatherName,
    @Address,
    @DateOfBirth,
    @IsDelete,
    @CreatedDateTime,
    @CreatedBy
)";

            Student item = new Student
            {
                StudentNo = "STU016",
                StudentName = "New Student",
                FatherName = "U New Father",
                Address = "Yangon, Myanmar",
                DateOfBirth = new DateTime(2002, 5, 21),
                IsDelete = false,
                CreatedDateTime = DateTime.Now,
                CreatedBy = "admin"
            };

            using IDbConnection db = new SqlConnection(builder.ConnectionString);
            db.Open();

            int result = db.Execute(query, item);

            Console.WriteLine(result > 0 ? "Create successful." : "Create failed.");
        }

        public void Update()
        {
            string query = @"
UPDATE [dbo].[Tbl_Student]
SET
    [StudentNo] = @StudentNo,
    [StudentName] = @StudentName,
    [FatherName] = @FatherName,
    [Address] = @Address,
    [DateOfBirth] = @DateOfBirth,
    [ModifiedDateTime] = @ModifiedDateTime,
    [ModifiedBy] = @ModifiedBy
WHERE [StudentId] = @StudentId
AND [IsDelete] = 0";

            Student item = new Student
            {
                StudentId = 1,
                StudentNo = "STU001",
                StudentName = "Aung Aung Updated",
                FatherName = "U Hla Myint",
                Address = "Yangon Updated Address",
                DateOfBirth = new DateTime(2001, 1, 15),
                ModifiedDateTime = DateTime.Now,
                ModifiedBy = "admin"
            };

            using IDbConnection db = new SqlConnection(builder.ConnectionString);
            db.Open();

            int result = db.Execute(query, item);

            Console.WriteLine(result > 0 ? "Update successful." : "Update failed.");
        }

        public void Delete()
        {
            string query = @"
UPDATE [dbo].[Tbl_Student]
SET
    [IsDelete] = @IsDelete,
    [ModifiedDateTime] = @ModifiedDateTime,
    [ModifiedBy] = @ModifiedBy
WHERE [StudentId] = @StudentId
AND [IsDelete] = 0";

            Student item = new Student
            {
                StudentId = 1,
                IsDelete = true,
                ModifiedDateTime = DateTime.Now,
                ModifiedBy = "admin"
            };

            using IDbConnection db = new SqlConnection(builder.ConnectionString);
            db.Open();

            int result = db.Execute(query, item);

            Console.WriteLine(result > 0 ? "Delete successful." : "Delete failed.");
        }
    }
}
