using Avaliacao3Bimlp3.Database;
using Avaliacao3Bimlp3.Repositories;
using Avaliacao3Bimlp3.Models;
using Microsoft.Data.Sqlite;

var modelName = args[0];
var modelAction = args[1];

var databaseConfig = new DatabaseConfig(); 
new DatabaseSetup(databaseConfig);

if(modelName == "Student")
{

    if(modelAction == "List")
    {
        if(studentRepository.CountByFormed().Any())
        {
            Console.WriteLine("There are no registered students");
        }
        else
        {
            foreach (var student in studentRepository.GetAll())
            {
                string situation = (student.Former) ? "formed" : "not formed";
                Console.WriteLine("{0},{1},{2},{3}", student.Registration, student.Name, student.City, situation);
            } 
        }
    }

     if(modelAction == "New")
    {
        var registration = Convert.ToInt32(args[2]);
        var name = args[3];
        var city = args[4];

        if(studentRepository.StudentExists(registration) == true)
        {
            Console.WriteLine("Estudante com id" + registration + "já existe!");
        }
        else 
        {
            var student = new Student(registration, name, city, false);
            studentRepository.Save(student);
            Console.WriteLine("O estudante" + name + "foi cadastrado com sucesso!");
        }
    }

    if (modelAction == "MarkAsFormed")
    {

    }

    if(modelAction == "Delete")
    {
        var id = Convert.ToInt32(args[2]);
        
        if(studentRepository.existsById(id))
        {
            studentRepository.Delete(id);
            Console.WriteLine($" O estudante {id} foi deletado");
        }
        else 
        {
            Console.WriteLine($"Estudante {id} não encontrado!");
        }
    }

    if (modelAction == "ListByCity")
    {

    }

    if (modelAction == "ListFormed")
    {

    }

    if (modelAction == "ListByCities")
    {

    }

    if (modelAction == "Report")
    {

    }

    if (modelType == "CountByFormed") 
    {
        
    }
}