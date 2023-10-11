using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaVirt.Classess
{
    public class Biblioteca : IBiblioteca
    {
        /// <summary>
        /// Initializare Liste CartiDisp && CartiImprumut
        /// </summary>
        public List<Carte> CartiStock = new List<Carte>();
        public List<Imprumut> CartiImprumutate = new List<Imprumut>();

        /// <summary>
        /// Functie de adaugare a unei noi carti in biblioteca
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nume"></param>
        /// <param name="isbn"></param>
        /// <param name="pretinchiriere"></param>
        /// <param name="numarexemplare"></param>
        public void AdaugaCarteBiblioteca(int id, string nume, string isbn, decimal pretinchiriere, int numarexemplare)
        {
            ///Verific dupa ISBN daca mai exista cartea in stocul nostru;
            var carteaExista = CartiStock.FirstOrDefault(x => x.ISBN == isbn);

            ///Daca cartea nu exista, o adaugam in biblioteca noastra;

            if (carteaExista == null)
            {
                Carte carteNew = new Carte()
                {
                    Id = id,
                    Nume = nume,
                    ISBN = isbn,
                    PretInchiriere = pretinchiriere,
                    NumarExmeplare = numarexemplare
                };

                CartiStock.Add(carteNew);
            }

            ///Daca cartea existe deja in biblioteca noastra, incrementam numarul de exemplare;
            else
            {
                carteaExista.NumarExmeplare += 1;
            }

        }

        /// <summary>
        /// Returnez lista tuturor cartilor disponibilite in biblioteca;
        /// </summary>
        /// <returns></returns>
        public List<Carte> CartiDisponbilie()
        {
            return CartiStock;
        }


        public List<Imprumut> EvidentaCartiImprumutate()
        {
            return CartiImprumutate;
        }
        /// <summary>
        /// Verific numarul de exemplare pentru o anumita carte furnizand isbn-ul;
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns></returns>
        public string NumarExemplareDisponibileCarte(string isbn)
        {
            Carte carte = CartiStock.FirstOrDefault(x => x.ISBN == isbn);

            int numarExemplare = carte.NumarExmeplare;

            if (numarExemplare == 0)
            {
                return "Aceasta carte nu mai este disponibila!";
            }
            else
            {
                return " Aceasta carte este disponibila in: " + numarExemplare.ToString() + " exemplare ";
            }

        }

        /// <summary>
        /// Logica de imprumut al unei carti
        /// </summary>
        /// <param name="isbn"></param>
        /// <param name="dataImprumut"></param>
        /// <param name="dataScadenta"></param>
        /// <returns></returns>
        public string ImprumutaCartea(string isbn, DateTime dataImprumut)
        {
            ///Verific daca exista cartea si este pe stock;
            Carte carteStoc = CartiStock.FirstOrDefault(x => x.ISBN == isbn && x.NumarExmeplare > 0);

            ///Cartea este stoc 0 sau nu poate fi gasita
            if (carteStoc == null)
            {
                return "Cartea nu poate fi imprumutata!\n ISBN incorect sau stock 0 !\n Reveniti mai tarziu";
            }
            else
            {
                ///Creez un obiect de tip imprumut
                Imprumut imprumut = new Imprumut()
                {
                    
                    CarteImprumutata = carteStoc,
                    DataInceput = dataImprumut,
                    DataScadenta = DateTime.Today.AddDays(2 * 7), ///Adaug implicit 2 saptamani;

                };

                CartiImprumutate.Add(imprumut);

                ///Scad numarul de exemplare pentru cartea imprumutata;
                carteStoc.NumarExmeplare--;

                return "Carte imprumutata cu succes";
            }
        }

        public string RestituieCartea(string isbn, DateTime dataRestituire)
        {
            Imprumut imprumut = CartiImprumutate.FirstOrDefault(x => x.CarteImprumutata.ISBN == isbn);

            if (imprumut == null)
            {
                return "Cartea nu este imprumutata de la noi! ";
            }
            else if (imprumut.DataScadenta > dataRestituire)
            {
                imprumut.CarteImprumutata.NumarExmeplare++;

                CartiImprumutate.Remove(imprumut);

                return "Va multumim pentru colaborare";
            }
            else
            {
                var zilePenalizare = (dataRestituire - imprumut.DataScadenta).TotalDays;
                var costInchiriere = imprumut.CarteImprumutata.PretInchiriere;
                var costpenalizare = (costInchiriere * 0.01m) / (decimal)zilePenalizare;
                CartiImprumutate.Remove(imprumut);


                return "A-ti intarzaiat cu returnarea cartii si a-ti fost taxat cu: " + costpenalizare + " RON, pentru cele " + zilePenalizare + " zile de intazaiere";


            }
        }
    }
}
