using Linq.Models;
using Linq.Services;

var people = new List<Person>
{
     new Person {FirstName = "Luis", Age = 28}
};

var inputService = new InputServices(people);
var queryServices = new QueryServices(people);


inputService.InputData();
queryServices.OrderQuery();