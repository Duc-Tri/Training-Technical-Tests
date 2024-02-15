using System;
using System.Collections.Generic;
using System.Linq;

namespace SGTest
{
    internal class DistributeurAutomatique
    {
        private static void AfficherBoissons()
        {
            Console.WriteLine("----------------------------------------");

            int count = 1;
            foreach (var r in DataManager.ToutesRecettes)
            {
                Console.WriteLine((count++) + " BOISSON: " + DataManager.DetailsRecette(r.Key));
            }

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            while (true)
            {
                AfficherBoissons();

                Console.Write($"Choisissez une boisson (entre 1 et {DataManager.ToutesRecettes.Count}): ");
                string read = Console.ReadLine();
                int choix;
                if (int.TryParse(read, out choix) && choix >= 1 && choix <= DataManager.ToutesRecettes.Count)
                {
                    Console.WriteLine(" VOTRE CHOIX: " + DataManager.PrixFinalBoisson(DataManager.ToutesRecettes.ElementAt(choix - 1).Key));

                }
                else
                {
                    Console.WriteLine("Choix invalide");
                }
            }

        }

    }
}
