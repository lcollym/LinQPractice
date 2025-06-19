using Linq.Models;

public class QueryServices
{
        //Inyection Dependency
    private List<Person> _people;

    public QueryServices(List<Person> people)
    {
        _people = people;
    }

    public void OrderQuery()
    {
        var queryResultInOrder = _people
            .OrderBy(p => p.Id)
            .ThenByDescending(p => p.FirstName);

        foreach (var item in queryResultInOrder)
        {
            Console.WriteLine($"{item.Id}, {item.FirstName}, {item.Age}");
        }
    }
}
