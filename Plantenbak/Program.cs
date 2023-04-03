using Periode_5_1;
using Plantenbak;


Dice steen1 = new Dice();
Dice steen2 = new Dice();


steen1.Gooi();
steen2.Gooi();
Console.WriteLine($"Steen 1: {steen1.Ogen} en Steen 2: {steen2.Ogen}");
steen1.blocked = true;
steen1.Gooi();
steen2.Gooi();
Console.WriteLine($"Steen 1: {steen1.Ogen} en Steen 2: {steen2.Ogen}");
steen1.Gooi();
steen2.Gooi();
Console.WriteLine($"Steen 1: {steen1.Ogen} en Steen 2: {steen2.Ogen}");
