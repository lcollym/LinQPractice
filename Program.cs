using Linq.Models;


var people = new List<Person>
{
     new Person {Id = 1,FirstName = "Luis", Age = 28}
};

var inputService = new InputServices(people);
var queryServices = new QueryServices(people);


inputService.InputData();
queryServices.OrderQuery();