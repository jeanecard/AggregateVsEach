using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    internal class Program
    {
        // TOIDO : Add for avec le cache de la List et faire un benchmarkDotnet
        static void Main(string[] args)
        {
            var commande = new List<Item>()
            {
                new Item()
                {
                    QuantiteBannanes = 2,
                    QuantiteFraises= 4,
                    QuantiteSaucisses= 5
                },
                new Item()
                {
                    QuantiteBannanes = 2,
                    QuantiteFraises= 4,
                    QuantiteSaucisses= 5
                },
                new Item()
                {
                    QuantiteBannanes = 2,
                    QuantiteFraises= 4,
                    QuantiteSaucisses= 5
                }
            };
            //On parcours en une fois cette liste et on fait 3 calcul différents pour chaque élements
            //Via Aggregate
            CalculFactureAggregate(commande);
            //Via Foreach
            CalculFactureForEach(commande);
            //Attendu Bannane 6, Fraises 12 et saucisse 30 .. eh oui, les saucisses comptent double
            Console.ReadKey();
            commande.Clear();
            //On parcours en une fois cette liste et les algorithmes doivent être sans erreur.
            //Via Aggregate
            CalculFactureAggregate(commande);
            //Via Foreach
            CalculFactureForEach(commande);
            //Attendu Bannane 0, Fraises 0 et saucisse 0
            Console.ReadKey();

        }

        private static void CalculFactureAggregate(List<Item> commande)
        {
            var seed = new Facture();
            var factureFinale = commande.Aggregate(seed, (facture, item) =>
            {
                facture.MontantDeBannanes += item.QuantiteBannanes;
                facture.MontantDeFraises += item.QuantiteFraises;
                facture.MontantDeSaucisses += item.QuantiteSaucisses * 2; //les saucisses comptent double.
                return facture;
            });

            Console.WriteLine($"Item Final Aggregate : Banannes {factureFinale.MontantDeBannanes}" +
                $", Fraises {factureFinale.MontantDeFraises}" +
                $", Saucisse {factureFinale.MontantDeSaucisses}");
        }
        private static void CalculFactureForEach(List<Item> commande)
        {
            var facture = new Facture();
            foreach(var item in commande)
            {
                facture.MontantDeBannanes += item.QuantiteBannanes;
                facture.MontantDeFraises += item.QuantiteFraises;
                facture.MontantDeSaucisses += item.QuantiteSaucisses * 2; //les saucisses comptent double.
            }

            Console.WriteLine($"Item Final Foreach : Banannes {facture.MontantDeBannanes}" +
                $", Fraises {facture.MontantDeFraises}" +
                $", Saucisse {facture.MontantDeSaucisses}");
        }
    }
}
