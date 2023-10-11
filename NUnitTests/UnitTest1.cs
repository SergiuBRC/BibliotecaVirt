using BibliotecaVirt.Classess;

namespace NUnitTests
{
    public class BibliotecaTest
    {
       

        [Test]
        public void Test_AdaugareCarte()
        {

            Biblioteca biblioteca = new Biblioteca();
            biblioteca.AdaugaCarteBiblioteca(1, "Carte 1", "ISBN-1", 12, 5);

            var listaCarti = biblioteca.CartiDisponbilie();

            Assert.That(listaCarti.Count, Is.EqualTo(1));
            Assert.That(listaCarti[0].Nume, Is.EqualTo("Carte 1"));
            Assert.That(listaCarti[0].ISBN, Is.EqualTo("ISBN-1"));
        }
    }
}