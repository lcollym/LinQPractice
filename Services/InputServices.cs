using System;
using System.Collections.Generic;
using Linq.Models;

namespace Linq.Services
{
    public class InputServices
    {
        // Dependency Injection

        private readonly List<Person> _people;

        public InputServices(List<Person> people)
        {
            _people = people ?? throw new ArgumentNullException(nameof(people));
        }

        public void InputData()
        {
            while (true)
            {
                Console.WriteLine("\nSelect option:");
                Console.WriteLine("1 - Add person");
                Console.WriteLine("2 - Delete person");
                Console.WriteLine("3 - View list");
                Console.WriteLine("4 - Exit");
                Console.Write("Enter your choice");

                string? opt = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(opt))
                {
                    Console.WriteLine("Invalid input. Please enter 1,2 or 3.");
                    continue;
                }

                if (opt == "4")
                {
                    Console.WriteLine("Exiting input mode.");
                    break;
                }
                else if (opt == "1")
                {
                    AddNewPerson();

                }

                else if (opt == "2")
                {
                    DeletePerson();

                }
                else if (opt == "3")
                {
                    ShowListPersons();

                }
                else
                {
                    Console.WriteLine("Invalid option. Please enter 1 or 2.");
                }
            }

        }

        private void AddNewPerson()
        {
            try
            {
                // Get name with validation
                string name;
                while (true)
                {
                    Console.Write("Enter name: ");
                    name = Console.ReadLine() ?? string.Empty;

                    if (!string.IsNullOrWhiteSpace(name))
                        break;

                    Console.WriteLine("Name cannot be empty. Please try again.");
                }

                // Get age with validation
                int age;
                while (true)
                {
                    Console.Write("Enter age: ");
                    string? ageInput = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(ageInput))
                    {
                        Console.WriteLine("Age cannot be empty. Please try again.");
                        continue;
                    }

                    if (int.TryParse(ageInput, out age) && age >= 0 && age <= 120)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid age. Please enter a number between 0 and 120.");
                    }
                }

                // Create person with a proper GUID
                var newPerson = new Person
                {
                    Id = Guid.NewGuid(),
                    FirstName = name,
                    Age = age
                };

                _people.Add(newPerson);
                Console.WriteLine($"New person added: ID={newPerson.Id}, Name={newPerson.FirstName}, Age={newPerson.Age}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding person: {ex.Message}");
            }
        }
        private void DeletePerson()
        {
            try
            {


                string? nameToDelete = Console.ReadLine();



                var personToDelete = _people.FirstOrDefault(p => p.FirstName == nameToDelete);





                _people.Remove(personToDelete);
                Console.WriteLine($"Delete person :{personToDelete}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding person: {ex.Message}");
            }
        }
        private void ShowListPersons()
        {
            try
            {
                var queryServices = new QueryServices(_people);
                Console.WriteLine($"List all persons");
                queryServices.OrderQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding person: {ex.Message}");
            }
        }

    }
}

