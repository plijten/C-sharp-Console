using Library;
using MySql.Data.MySqlClient;
using System.Net.Http;
using System.Text.Json;

var client = new HttpClient();
// URL zonder de ID van de pokemon (Basis URL)
client.BaseAddress = new Uri($"https://pokeapi.co/api/v2/pokemon/");

MySqlConnection conn = new MySqlConnection();

conn.ConnectionString = "Server=127.0.0.1;Database=pokemon;User ID=root";
conn.Open();

(new MySqlCommand("drop table if exists Pokemon", conn)).ExecuteNonQuery();
(new MySqlCommand(@"create table Pokemon (
    id int,
    name VARCHAR(255),
    weight int,
    height int
)", conn)).ExecuteNonQuery();

for (int i = 1; i < 155; i++)
{
    // Haal pokemon op met Id 1
    var response = client.GetAsync(i.ToString()).Result;

    string json = response.Content.ReadAsStringAsync().Result;
    Pokemon pokemon = JsonSerializer.Deserialize<Pokemon>(json);


    Console.WriteLine(pokemon.name);

    new MySqlCommand(@$"insert into Pokemon values (
        '{pokemon.id}',
        '{pokemon.name}',
        '{pokemon.weight}',
        '{pokemon.height}'
    )", conn).ExecuteNonQuery();

}

Console.WriteLine("Alles ingelezen.");



/* andere optie wanneer je niet met een ID werkt.
 * var client = new HttpClient();
 * var response = client.GetAsync(new Uri("https://pokeapi.co/api/v2")).Result;
 * 
 * string json = response.Content.ReadAsStringAsync().Result;
 * 
 */