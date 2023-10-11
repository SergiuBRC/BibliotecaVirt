using Microsoft.VisualStudio.TestTools.UnitTesting;
using BibliotecaVirt.Classess;


namespace Biblioteca.UnitTests
{
    [TestClass]
    public class BibliotecaTests
    {
        [TestMethod]
        public void AdaugaCarteBiblioteca()
        {
            var biblioteca = new BibliotecaVirt.Classess.Biblioteca();

            biblioteca.AdaugaCarteBiblioteca(1, "Carte 1", "123-123-132", 11, 5);

            var listaCartiBiblioteca = biblioteca.CartiDisponbilie();

            Assert.AreEqual(1, listaCartiBiblioteca.Count);
            Assert.AreEqual("Carte 1", listaCartiBiblioteca[0].Nume);
            Assert.AreEqual("123-123-132", listaCartiBiblioteca[0].ISBN);
            Assert.AreEqual(11, listaCartiBiblioteca[0].PretInchiriere);
            Assert.AreEqual(5, listaCartiBiblioteca[0].NumarExmeplare);
        }
    }
}
