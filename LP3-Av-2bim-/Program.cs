using Avaliacao3Bimlp3.Database;
using Avaliacao3Bimlp3.Repositories;
using Avaliacao3Bimlp3.Models;

var modelName = args[0];
var modelAction = args[1];

var databaseConfig = new DatabaseConfig(); 
new DatabaseSetup(databaseConfig);

if(modelName == "Student")
{
    var studentRepository = new StudentRepository(databaseConfig);
    if(modelAction == "List")
    {
        if(studentRepository.existsAnyStudent())
        {
            Console.WriteLine("Lista de estudantes cadastrados:");
            foreach (var student in studentRepository.GetAll())
            {
                Console.WriteLine("Lista de estudantes e suas informações: {0},{1},{2},{3}", student.Registration, student.Name, student.City, student.Former);
            } 
        }
        else 
        {
            Console.WriteLine("Nenhum estudante cadastrado");
        }
    }

     if(modelAction == "New")
    {
        var registration = Convert.ToInt32(args[2]);
        var name = args[3];
        var city = args[4];
        var former = Convert.ToBoolean(args[5]);

        if(studentRepository.existsById(registration))
        {
            Console.WriteLine($"estudante {registration} já existe!");
        }
        else 
        {
            var student = new Student(registration, name, city, former);
            var result = studentRepository.Save(student);
            Console.WriteLine("{0}, {1}, {2}, {3}", student.Registration, student.Name, student.City, student.Former);
        }
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
}