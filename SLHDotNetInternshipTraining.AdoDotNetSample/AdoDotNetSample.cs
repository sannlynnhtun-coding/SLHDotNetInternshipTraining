using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLHDotNetInternshipTraining.AdoDotNetSample
{
    public class AdoDotNetSample
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
            //Console.WriteLine("This is connection string:");
            Console.Write("This is connection string: ");
            Console.WriteLine(builder.ConnectionString);

            SqlConnection connection = new SqlConnection(builder.ConnectionString);
            Console.WriteLine("Connection opening...");
            connection.Open();
            Console.WriteLine("Connection opened.");

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
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            Console.WriteLine("Connection closing...");
            connection.Close();
            Console.WriteLine("Connection closed.");

            List<Student> lst = new List<Student>();
            foreach (DataRow row in dt.Rows)
            {
                Student item = new Student()
                {
                    StudentId = Convert.ToInt32(row["StudentId"]),
                    StudentNo = row["StudentNo"].ToString()!,
                    StudentName = row["StudentName"].ToString()!,
                    FatherName = row["FatherName"].ToString()!,
                    Address = row["Address"].ToString()!,
                    DateOfBirth = Convert.ToDateTime(row["DateOfBirth"]),
                    IsDelete = Convert.ToBoolean(row["IsDelete"]),
                    CreatedDateTime = Convert.ToDateTime(row["CreatedDateTime"]),
                    CreatedBy = row["CreatedBy"].ToString()!,
                    ModifiedDateTime = row["ModifiedDateTime"] == DBNull.Value ? null : Convert.ToDateTime(row["ModifiedDateTime"]),
                    ModifiedBy = row["ModifiedBy"] == DBNull.Value ? null : row["ModifiedBy"].ToString()
                };
                lst.Add(item);

                Console.WriteLine(item.StudentName);
                Console.WriteLine(item.DateOfBirth.ToString("dd MMM yyyy"));
            }
        }

        public void Edit()
        {
            SqlConnection connection = new SqlConnection(builder.ConnectionString);
            connection.Open();

            int id = 1;
            string query = $@"SELECT [StudentId]
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
  FROM [dbo].[Tbl_Student] Where StudentId = @StudentId and IsDelete = 0";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@StudentId", id);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No record found.");
                return;
            }

            DataRow row = dt.Rows[0];

            Student item = new Student()
            {
                StudentId = Convert.ToInt32(row["StudentId"]),
                StudentNo = row["StudentNo"].ToString()!,
                StudentName = row["StudentName"].ToString()!,
                FatherName = row["FatherName"].ToString()!,
                Address = row["Address"].ToString()!,
                DateOfBirth = Convert.ToDateTime(row["DateOfBirth"]),
                IsDelete = Convert.ToBoolean(row["IsDelete"]),
                CreatedDateTime = Convert.ToDateTime(row["CreatedDateTime"]),
                CreatedBy = row["CreatedBy"].ToString()!,
                ModifiedDateTime = row["ModifiedDateTime"] == DBNull.Value ? null : Convert.ToDateTime(row["ModifiedDateTime"]),
                ModifiedBy = row["ModifiedBy"] == DBNull.Value ? null : row["ModifiedBy"].ToString()
            };

            Console.WriteLine(item.StudentName);
            Console.WriteLine(item.DateOfBirth.ToString("dd MMM yyyy"));
        }

        public void Create()
        {
            Student item = new Student()
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

            using SqlConnection connection = new SqlConnection(builder.ConnectionString);
            connection.Open();

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

            using SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@StudentNo", item.StudentNo);
            cmd.Parameters.AddWithValue("@StudentName", item.StudentName);
            cmd.Parameters.AddWithValue("@FatherName", item.FatherName);
            cmd.Parameters.AddWithValue("@Address", item.Address);
            cmd.Parameters.AddWithValue("@DateOfBirth", item.DateOfBirth);
            cmd.Parameters.AddWithValue("@IsDelete", item.IsDelete);
            cmd.Parameters.AddWithValue("@CreatedDateTime", item.CreatedDateTime);
            cmd.Parameters.AddWithValue("@CreatedBy", item.CreatedBy);

            int result = cmd.ExecuteNonQuery();

            Console.WriteLine(result > 0 ? "Create successful." : "Create failed.");
        }

        public void Update()
        {
            Student item = new Student()
            {
                StudentId = 1,
                StudentNo = "STU001",
                StudentName = "Aung Aung Updated",
                FatherName = "U Hla Myint",
                Address = "Yangon Updated Address",
                DateOfBirth = new DateTime(2001, 1, 15),
                IsDelete = false,
                ModifiedDateTime = DateTime.Now,
                ModifiedBy = "admin"
            };

            using SqlConnection connection = new SqlConnection(builder.ConnectionString);
            connection.Open();

            string query = @"
UPDATE [dbo].[Tbl_Student]
SET
    [StudentNo] = @StudentNo,
    [StudentName] = @StudentName,
    [FatherName] = @FatherName,
    [Address] = @Address,
    [DateOfBirth] = @DateOfBirth,
    [IsDelete] = @IsDelete,
    [ModifiedDateTime] = @ModifiedDateTime,
    [ModifiedBy] = @ModifiedBy
WHERE [StudentId] = @StudentId";

            using SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@StudentId", item.StudentId);
            cmd.Parameters.AddWithValue("@StudentNo", item.StudentNo);
            cmd.Parameters.AddWithValue("@StudentName", item.StudentName);
            cmd.Parameters.AddWithValue("@FatherName", item.FatherName);
            cmd.Parameters.AddWithValue("@Address", item.Address);
            cmd.Parameters.AddWithValue("@DateOfBirth", item.DateOfBirth);
            cmd.Parameters.AddWithValue("@IsDelete", item.IsDelete);
            cmd.Parameters.AddWithValue("@ModifiedDateTime", item.ModifiedDateTime);
            cmd.Parameters.AddWithValue("@ModifiedBy", item.ModifiedBy);

            int result = cmd.ExecuteNonQuery();

            Console.WriteLine(result > 0 ? "Update successful." : "Update failed.");
        }

        public void Delete()
        {
            int id = 1;

            using SqlConnection connection = new SqlConnection(builder.ConnectionString);
            connection.Open();

            string query = @"
UPDATE [dbo].[Tbl_Student]
SET
    [IsDelete] = @IsDelete,
    [ModifiedDateTime] = @ModifiedDateTime,
    [ModifiedBy] = @ModifiedBy
WHERE [StudentId] = @StudentId";

            using SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@StudentId", id);
            cmd.Parameters.AddWithValue("@IsDelete", true);
            cmd.Parameters.AddWithValue("@ModifiedDateTime", DateTime.Now);
            cmd.Parameters.AddWithValue("@ModifiedBy", "admin");

            int result = cmd.ExecuteNonQuery();

            Console.WriteLine(result > 0 ? "Delete successful." : "Delete failed.");
        }
    }
