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
        string registration = args[2];

        if (studentRepository.StudentExists(registration) == false)
        {
            Console.WriteLine("Estudante " + registration + " não encontrado");
        }
        else
        {
            studentRepository.MarkAsFormed(registration);
            Console.WriteLine("Estudante " + registration + " definido como formado");
        }
    }

    if(modelAction == "Delete")
    {
        var registration = Convert.ToInt32(args[2]);
        
        if(studentRepository.StudentExists(registration) == false)
        {
            Console.WriteLine($" O estudante {registration} não encontrado!");
        }
        else 
        {
            studentRepository.Delete(registration);
            Console.WriteLine("Estudante " + registration + " removido com sucesso");
        }
    }

    if (modelAction == "ListByCity")
    {
        string city = args[2];

        if (studentRepository.GetAllStudentByCity(city).Any())
        {
            Console.WriteLine("Nenhum estudante cadastrado");
        }
        else
        {
            foreach (var student in studentRepository.GetAllStudentByCity(city))
            {
                string situation = (student.Former) ? "formado" : "não formado";
                Console.WriteLine("{0}, {1}, {2}, {3}", student.Registration, student.Name, student.City, situation);
            }
        }
    }

    if (modelAction == "ListFormed")
    {
        if (studentRepository.CountByCities().Any())
        {
            Console.WriteLine("Nenhum estudante cadastrado");
        }
        else
        {
            foreach (var student in studentRepository.GetAllFormed())
            {
                string situation = (student.Former) ? "formado" : "não formado";
                Console.WriteLine("{0}, {1}, {2}", student.Name, student.City, situation);
            }
        }
    }

    if (modelAction == "ListByCities")
    {
        var cities = args;
        cities = cities.Where((source, index) => index != 0 && index != 1).ToArray();

        if (studentRepository.GetAllByCities(cities).Any())
        {
            Console.WriteLine("Nenhum estudante cadastrado");
        }
        else
        {
            foreach (var student in studentRepository.GetAllByCities(cities))
            {
                string situation = (student.Former) ? "formado" : "não formado";
                Console.WriteLine("{0}, {1}, {2}, {3}", student.Registration, student.Name, student.City, situation);
            }
        }
    }

    if (modelAction == "Report")
    {
        string modelType = args[2];

        if (modelType == "CountByCities")
        {
            if (studentRepository.CountByCities().Any())
            {
                Console.WriteLine("Nenhum estudante cadastrado");
            }
            else
            {
                foreach (var city in studentRepository.CountByCities())
                {

                    Console.WriteLine("{0}, {1}", city.AttributeName, city.StudentNumber);
                }
            }
        }

    if (modelType == "CountByFormed") 
    {
        if (studentRepository.CountByFormed().Any())
            {
                Console.WriteLine("Nenhum estudante cadastrado");
            }
            else
            {
                foreach (var former in studentRepository.CountByFormed())
                {
                    string situation = (former.AttributeName == "0") ? "Formados" : "Não formados";
                    Console.WriteLine("{0}, {1}", situation, former.StudentNumber);
                }
            }
        }        
    }
}