namespace Avaliacao3Bimlp3.Models;

class Student
{
    public string Registration { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public bool Former { get; set; }

    public Student(int registration, string name) {}

    public Student(string registration, string name, string city, bool former) 
    {
        Registration = registration;
        Name = name;
        City = city;
        Former = former;
    }
}

class CountStudentGroupByAttribute
{
    public string AttributeName { get; set; }
    public int StudentNumber { get; set; }
    
    public CountStudentGroupByAttribute() {}

    public CountStudentGroupByAttribute(string attributeName, int studentNumber) {
        AttributeName = attributeName;
        StudentNumber = studentNumber;
        }
}
