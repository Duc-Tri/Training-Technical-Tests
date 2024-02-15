using System;
using System.Collections.Generic;
using System.Linq;

namespace SGTest
{

    internal class DistributeurAutomatique
    {
        private List<Recette> recettes;

        public List<Recette> Recettes { get { return recettes; } }

        private void InitRecettes()
        {
            recettes = new List<Recette>();

        }

        public DistributeurAutomatique()
        {
            // On pourrait imaginer une initialisation externe,  pour des recettes spécifiques à chaque distributeur




        }

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

            // Sélectionner une boisson

            while (true)
            {
                AfficherBoissons();

                Console.Write($"Choississez une boisson (entre 1 et {DataManager.ToutesRecettes.Count}): ");
                string read = Console.ReadLine();
                int choix;
                if (int.TryParse(read, out choix) && choix >= 1 && choix <= DataManager.ToutesRecettes.Count)
                {
                    Console.WriteLine(" CHOIX: " + DataManager.PrixFinalBoisson(DataManager.ToutesRecettes.ElementAt(choix - 1).Key));

                }
                else
                {
                    Console.WriteLine("Choix invalide");
                }
            }


        }

    }
}
