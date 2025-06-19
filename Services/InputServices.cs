

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
        Console.Write("Select opt 1 for add person or 2 for exit loop: ");
        string opt = Console.ReadLine();
        if (opt == "1")
        {

            while (true)
            {
                Console.Write("Add Name: ");
                string? name = Console.ReadLine();

                Console.Write("Add Age: ");
                int age = int.Parse(Console.ReadLine());

                var newPerson = new Person
                {

                    FirstName = name,
                    Age = age

                };
                Console.WriteLine($"New Argumen Added {newPerson.Id}, {newPerson.FirstName}");

                _people.Add(newPerson);
                if (opt == "2")
                {
                    break;
                }
            }




        }




    }

}
