using BibliotecaVirt.Classess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class BibliotecaTests

    {
        [TestMethod]
        public void TestAdaugaCarteBiblioteca()
        {
            var biblioteca = new Biblioteca();

            
            biblioteca.AdaugaCarteBiblioteca(1, "Carte 1", "123-123-123", 13, 4);


            Assert.IsNotNull(biblioteca.CartiStock.FirstOrDefault(x => x.ISBN == "123-123-123"));
            Assert.AreEqual(1, biblioteca.CartiStock.Count);
            Assert.AreEqual(13, biblioteca.CartiStock.FirstOrDefault(x=> x.PretInchiriere == 13));


        }

        [TestMethod]
        public void TestCartiDisponibile()
        {
            var biblioteca = new Biblioteca();
            biblioteca.AdaugaCarteBiblioteca(1, "Carte 1", "123-123-123", 13, 4);

            //Testam sa nu fie o lista goala;
            Assert.IsTrue(biblioteca.CartiDisponbilie().Count > 0);
        }

        [TestMethod]
        public void TestImprumutaCartea()
        {
            var biblioteca = new Biblioteca();
            biblioteca.AdaugaCarteBiblioteca(1, "Carte 1", "123-123-123", 13, 4);

            var result = biblioteca.ImprumutaCartea("123-123-123", DateTime.Now);

            //TEst imprumuta cartea
            Assert.AreEqual("Carte imprumutata cu succes", result);
        }

        [TestMethod]
        public void TestRestituieCarteaLaTimp()
        {
            var biblioteca = new Biblioteca();
            biblioteca.AdaugaCarteBiblioteca(1, "Carte 1", "123-123-123", 13, 4);
            biblioteca.ImprumutaCartea("123-123-123", DateTime.Now);

            var result = biblioteca.RestituieCartea("123-123-123", DateTime.Now.AddDays(14));

            // Test returneaza cartea la timp
            Assert.AreEqual("Va multumim pentru colaborare", result);
        }

        [TestMethod]
        public void TestRestituieCarteaCuPenalitati()
        {
            var biblioteca = new Biblioteca();
            biblioteca.AdaugaCarteBiblioteca(1, "Carte 1", "123-123-123", 13, 4);
            biblioteca.ImprumutaCartea("123-123-123", DateTime.Now);

            var result = biblioteca.RestituieCartea("123-123-123", DateTime.Now.AddDays(21));

            //Test returneaza cartea mai tarziu de cat era prestabilit;
            Assert.IsTrue(result.Contains("A-ti intarziat cu returnarea cartii"));
        }
    }
}
