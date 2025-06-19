

using Linq.Models;

public class InputServices
{
    //Inyection Dependency

    private List<Person> _people;
    public InputServices(List<Person> people)
    {
        _people = people;
    }
    public void InputData()
    {
        Console.Write("Add Name: ");
        string? name = Console.ReadLine();

        Console.Write("Add Age: ");
        int age = int.Parse(Console.ReadLine());

        var newPerson = new Person
        {
            Id = _people.Count + 1,
            FirstName = name,
            Age = age

        };
        Console.WriteLine($"New Argumen Added {newPerson.Id}, {newPerson.FirstName}");

        _people.Add(newPerson);
    }

}
