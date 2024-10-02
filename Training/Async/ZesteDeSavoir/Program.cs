using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace test_cookie
{
    class Program
    {
        static void Main(string[] args)
        {
            faitDesCookies();
            Console.In.ReadLine();
        }

        static async Task faitDesCookies() // indique que la méthode va faire quelque chose d'asynchrone
        {
            Queue<Ingredient> liste = Ingredient.GetRecette();
            while (liste.Count > 0)
            {
                Ingredient ingredient = liste.Dequeue();
                ingredient.Take();
                ingredient.UnPackage();
                ingredient.MesureQuantity();
                Console.Out.WriteLine("ajouté");
                Console.Out.WriteLine("On mélange");
            }
            Console.Out.WriteLine("On forme les cookies et on les met au four");
            // attend pendant 5 secondes mais ne truste pas les ressources
            await Task.Factory.StartNew(() =>
            {
                Console.Out.WriteLine("On met le minuteur.");
                System.Threading.Thread.Sleep(5000);
                Console.Out.WriteLine("DRIIIIIIIIIIIIIIIIING");
            });
            Console.Out.WriteLine("Sortir les cookies du four");
        }
    }
}