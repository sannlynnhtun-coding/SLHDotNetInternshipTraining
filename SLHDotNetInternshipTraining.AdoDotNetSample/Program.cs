// See https://aka.ms/new-console-template for more information
using Microsoft.Data.SqlClient;
using SLHDotNetInternshipTraining.AdoDotNetSample;
using System.Data;

Console.WriteLine("Hello, World!");

AdoDotNetSample sample = new AdoDotNetSample();
sample.Read();
sample.Edit();
sample.Create();
sample.Update();
sample.Delete();

Console.ReadLine();

// ADO.NET 
// Dapper
// EFCore
// Model First
// Code First
// Database First