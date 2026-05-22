// See https://aka.ms/new-console-template for more information
using SLHDotNetInternshipTraining.EFCoreSample;

Console.WriteLine("Hello, World!");

EFCoreSample sample = new EFCoreSample();
sample.Read();
sample.Edit();

Console.ReadLine();