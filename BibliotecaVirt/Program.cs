using BibliotecaVirt.Classess;
using System;

public class Program
{
    static void Main(string[] args)
    {
        Biblioteca biblioteca = new Biblioteca();
        BibliotecaUI bibliotecaUI = new BibliotecaUI(biblioteca);

        Console.WriteLine("Bine ati venit in biblioteca!\nVa rugam sa alegeti o optiune!!!");
        bibliotecaUI.Run();
       
    }
}