

// See https://aka.ms/new-console-template for more information
using test;

Console.WriteLine("Hello, World!");

var Vlad = new GameAccount("vlad", 1000, 0);
var Ilysha = new GameAccount("ilysha", 1000, 0);
var Alex = new GameAccount("alex", 1000, 0);

Vlad.WinGame(Ilysha, 25);
Vlad.LoseGame(Ilysha, 50);

Ilysha.WinGame(Vlad, 200);

Alex.WinGame(Ilysha, 100);

Alex.LoseGame(Vlad, 150);

Ilysha.LoseGame(Alex, 26);

Vlad.GetStats();

Alex.GetStats();

Stat.GetStats();
