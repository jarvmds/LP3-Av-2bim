using Avaliacao3Bimlp3.Models;
using Avaliacao3Bimlp3.Database;
using Microsoft.Data.Sqlite;
using Dapper;
using Avaliacao3BimLp3.Database;

namespace Avaliacao3Bimlp3.Repositories;

class studentRepository
{
    private DatabaseConfig databaseConfig;  
    public studentRepository(DatabaseConfig databaseConfig) => this.databaseConfig = databaseConfig;

    // Insere um estudante na tabela
    public Student Save(Student student)
    {
        using var connection = new SqliteConnection(databaseConfig.ConnectionString);
        connection.Open();
        
        connection.Execute("INSERT INTO Students VALUES(@Id, @Name, @Price, @Active)",student);

        return student;
    }

    // Deleta um estudante na tabela
    public void Delete(int id)
    {
        using var connection = new SqliteConnection(databaseConfig.ConnectionString);
        connection.Open();

        connection.Execute("DELETE FROM Student WHERE id = @Id", new { Id = id });
    }

    // Marca um estudante como formado
    public void MarkAsFormed(int id) 
    {

    }


    // Retorna todos os estudantes
    public List<Student> GetAll()
    {
        using var connection = new SqliteConnection(databaseConfig.ConnectionString);
        connection.Open();
        
        var student = connection.Query<Student>("SELECT * FROM Student").ToList();
        
        return student;
    }

    // Retorna todos os estudantes formados
    // public List<Student> GetAllFormed() 
    //{

    //}

    public bool existsAnyStudent()
    {
        using var connection = new SqliteConnection(databaseConfig.ConnectionString);
        connection.Open();

        return Convert.ToBoolean(connection.ExecuteScalar("SELECT count(*) FROM Student"));
    }

        public bool existsById(int id)
    {
        using var connection = new SqliteConnection(databaseConfig.ConnectionString);
        connection.Open();

        return Convert.ToBoolean(connection.ExecuteScalar("SELECT count(id) FROM Students WHERE id = @id;", new {id = id}));
    }
}