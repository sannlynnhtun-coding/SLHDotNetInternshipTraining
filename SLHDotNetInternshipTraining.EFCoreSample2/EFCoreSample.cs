using Newtonsoft.Json;
using SLHDotNetInternshipTraining.EFCoreSample2.Database.AppDbContextModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLHDotNetInternshipTraining.EFCoreSample2;

public class EFCoreSample
{
    private readonly AppDbContext _db;

    public EFCoreSample()
    {
        _db = new AppDbContext();
    }

    public void Read()
    {
        List<TblStudent> lst = _db.TblStudents.ToList();
        foreach (TblStudent s in lst)
        {
            Console.WriteLine(s.FatherName);
        }
    }

    public void Edit()
    {
        var student = _db.TblStudents.FirstOrDefault(s => s.StudentId == 1);
        if (student is null)
        {
            Console.WriteLine("No data found.");
            return;
        }

        Console.WriteLine(JsonConvert.SerializeObject(student));
        Console.WriteLine(JsonConvert.SerializeObject(student, Formatting.Indented));
    }

    public void Create()
    {
        TblStudent item = new TblStudent
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

        _db.TblStudents.Add(item);
        int result = _db.SaveChanges();
        Console.WriteLine(result > 0 ? "Saving Successful." : "Saving Failed.");
    }

    public void Update()
    {
        var student = _db.TblStudents.FirstOrDefault(s => s.StudentId == 1);
        if (student is null)
        {
            Console.WriteLine("No data found.");
            return;
        }

        student.FatherName = "U Lin Lin";
        int result = _db.SaveChanges();
        Console.WriteLine(result > 0 ? "Updating Successful." : "Updating Failed.");
    }

    public void Delete()
    {
        var student = _db.TblStudents.FirstOrDefault(s => s.StudentId == 1);
        if (student is null)
        {
            Console.WriteLine("No data found.");
            return;
        }

        student.IsDelete = true;

        //_db.Students.Remove(student);

        int result = _db.SaveChanges();
        Console.WriteLine(result > 0 ? "Deleting Successful." : "Deleting Failed.");
    }
}
