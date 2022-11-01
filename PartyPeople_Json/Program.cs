using PartyPeople_Json;
using System.Text.Json;

var json = File.ReadAllText("./people.json");

List<Person> people = JsonSerializer.Deserialize<List<Person>>(json);


foreach (var person in people)
{
    Console.WriteLine(person.Introduction());
}

