using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaVirt.Classess
{
  public class BibliotecaUI
    {
        private IBiblioteca _biblioteca;

        public BibliotecaUI(IBiblioteca biblioteca)
        {
              _biblioteca = biblioteca;
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Meniu:");
                Console.WriteLine("1. Adauga carte");
                Console.WriteLine("2. Afiseaza toate cartile");
                Console.WriteLine("3. Numar exemplare disponibile");
                Console.WriteLine("4. Imprumuta carte");
                Console.WriteLine("5. Restituie carte");
                Console.WriteLine("6. Evidenta carti imprumutate");
                Console.WriteLine("0. Iesi");

                string optiune = Console.ReadLine();

                switch (optiune)
                {
                    case "1":
                        AdaugaCarteBiblioteca();
                        break;
                    case "2":
                        CartiDisponbilie();
                        break;
                    case "3":
                        NumarExemplareDisponibileCarte();
                        break;
                    case "4":
                        ImprumutaCartea();
                        break;
                    case "5":
                        RestituieCartea();
                        break;
                    case "6":
                        CartiImprumutate();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Optiune invalida.");
                        break;
                }
            }
        }


        private void AdaugaCarteBiblioteca()
        {
            Console.WriteLine("Introduceti id-ul cărtii:");
            string id = Console.ReadLine();

            Console.WriteLine("Introduceti numele cartii:");
            string nume = Console.ReadLine();

            Console.WriteLine("Introduceti ISBN-ul cartii:");
            string isbn = Console.ReadLine();

            Console.WriteLine("Introduceti pretul de inchiriere:");
            if (!decimal.TryParse(Console.ReadLine(), out decimal pretInchiriere))
            {
                Console.WriteLine("Pretul introdus nu este valid.");
                return;
            }

            Console.WriteLine("Introduceti numarul de exemplare disponibile:");
            if (!int.TryParse(Console.ReadLine(), out int numarExemplare))
            {
                Console.WriteLine("Numarul introdus nu este valid.");
                return;
            }



            _biblioteca.AdaugaCarteBiblioteca(Convert.ToInt32(id), nume, isbn, pretInchiriere, numarExemplare);
            Console.WriteLine("Cartea a fost adaugata cu succes in biblioteca.");
        }

        public void CartiDisponbilie()
        {
            List<Carte> carti = _biblioteca.CartiDisponbilie();

            Console.WriteLine("Carti disponibile in biblioteca:");
            foreach (var carte in carti)
            {
                Console.WriteLine($"Nume: {carte.Nume}, ISBN: {carte.ISBN}, Pret: {carte.PretInchiriere}, Exemplare disponibile: {carte.NumarExmeplare}");
            }
        }

        public void CartiImprumutate()
        {
            List<Imprumut> cartiImprumutate = _biblioteca.EvidentaCartiImprumutate();

            Console.WriteLine("Lista Carti imprumutate:");
            foreach (var carte in cartiImprumutate)
            {
                Console.WriteLine($"Nume: {carte.CarteImprumutata.Nume}, ISBN: {carte.CarteImprumutata.ISBN}, Pret: {carte.CarteImprumutata.PretInchiriere}, Data Restituire: {carte.DataScadenta}");
            }
        }

        private void NumarExemplareDisponibileCarte()
        {
            Console.WriteLine("Introduceti ISBN-ul cartii:");
            string isbn = Console.ReadLine();

            string numarExemplare = _biblioteca.NumarExemplareDisponibileCarte(isbn);
            Console.WriteLine($"{numarExemplare}");
        }

        private void ImprumutaCartea()
        {
           

            Console.WriteLine("Introduceti ISBN-ul cartii pentru imprumut:");
            string isbn = Console.ReadLine();

            Console.WriteLine("Introduceti data imprumutului (YYYY-MM-DD):");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime dataImprumut))
            {
                Console.WriteLine("Data introdusa nu este valida.");
                return;
            }

            var result = _biblioteca.ImprumutaCartea(isbn, dataImprumut);
           
            Console.WriteLine($"{result}");
            
        }

        private void RestituieCartea()
        {
            Console.WriteLine("Introduceti ISBN-ul cartii pe care doriti sa o restituiti:");
            string isbn = Console.ReadLine();

            Console.WriteLine("Introduceti data restituirii (YYYY-MM-DD):");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime dataRestituire))
            {
                Console.WriteLine("Data introdusa nu este valida.");
                return;
            }

            var result = _biblioteca.RestituieCartea(isbn, dataRestituire);
            Console.WriteLine($"{result}");
            
        }
    }


}
