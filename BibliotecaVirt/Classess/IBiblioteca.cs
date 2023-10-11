using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaVirt.Classess
{
    public  interface IBiblioteca
    {
        void AdaugaCarteBiblioteca(int id, string nume, string isbn, decimal pretinchiriere, int numarexemplare);
        List<Carte> CartiDisponbilie();
        List<Imprumut> EvidentaCartiImprumutate();
        string NumarExemplareDisponibileCarte(string isbn);
        string ImprumutaCartea(string isbn, DateTime dataImprumut);
        string RestituieCartea(string isbn, DateTime dataRestituire);
    }
}
