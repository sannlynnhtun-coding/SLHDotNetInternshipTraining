// See https://aka.ms/new-console-template for more information
using SLHDotNetInternshipTraining.DapperSample;

Console.WriteLine("Hello, World!");

DapperSample sample = new DapperSample();   
sample.Read();
sample.Edit();
sample.Create();    
sample.Update();
sample.Delete();

Console.ReadLine();