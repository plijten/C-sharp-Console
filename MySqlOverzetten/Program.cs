using MySql.Data;
using MySql.Data.MySqlClient;
using MySqlOverzetten;
using System.Text.Json;

// MySQL Connectie opzetten
MySqlConnection conn = new MySqlConnection();

conn.ConnectionString = "Server=127.0.0.1;Database=csharp_novice;User ID=root";
conn.Open();

// Lees de Json file in
string jsonString = (new StreamReader("users.json")).ReadToEnd();

// Gaan er vanuit dat de Json niet leeg is!
List<User> users = JsonSerializer.Deserialize<List<User>>(jsonString);

// Tabel verwijderen
(new MySqlCommand("drop table if exists Users", conn)).ExecuteNonQuery();

// Tabel opnieuw aanmaken. 
(new MySqlCommand(@"create table Users (
            Name VARCHAR(255),
            Gender VARCHAR(255),
            Age int,
            FavColor VARCHAR(255)
        )", conn)).ExecuteNonQuery();

// We hebben nu een lege tabel 
// we gaan de gebruikers inlezen voor de lijst te doorlopen
foreach(User user in users)
{
    //Query om de gebruiker toe te voegen aan de tabel. 
    //met executeNonQuery wordt deze query ook uitgevoerd op de database.
    new MySqlCommand(@$"insert into Users values (
                '{user.Name}',
                '{user.Gender}',
                '{user.Age}',
                '{user.FavColor}'
            )", conn).ExecuteNonQuery();
}

Console.WriteLine($"Geslaagd! {users.Count} gebruikers toegevoegd.");



