using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_cookie
{
    class Ingredient
    {
        public string Name { get; set; }
        public string Action { get; set; }
        public int Quantity { get; set; }
        public void Take()
        {
            Console.Out.WriteLine("J'ai pris " + Name);
        }

        public void UnPackage()
        {
            Console.Out.WriteLine(Action);
        }

        public void MesureQuantity()
        {
            Console.Out.WriteLine(Quantity);
        }

        public static Queue<Ingredient> GetRecette()
        {
            Queue<Ingredient> liste = new Queue<Ingredient>();
            liste.Enqueue(new Ingredient
            {
                Name = "farine",
                Quantity = 500,
                Action = "Rien de spécial"

            });
            liste.Enqueue(new Ingredient
            {
                Name = "chocolat pâtissier",
                Quantity = 500,
                Action = "Faire des morceaux"

            });
            liste.Enqueue(new Ingredient
            {
                Name = "beurre",
                Quantity = 250,
                Action = "Faire fondre"

            });
            liste.Enqueue(new Ingredient
            {
                Name = "Cassonade",
                Quantity = 200,
                Action = "Enlever les gros morceaux"

            });
            liste.Enqueue(new Ingredient
            {
                Name = "oeufs",
                Quantity = 2,
                Action = "Casser"

            });
            liste.Enqueue(new Ingredient
            {
                Name = "sucre vanillé",
                Quantity = 2,
                Action = "Rien de spécial"

            });
            liste.Enqueue(new Ingredient
            {
                Name = "sel",
                Quantity = 1,
                Action = "Prendre une pincée"

            });
            liste.Enqueue(new Ingredient
            {
                Name = "levure",
                Quantity = 1,
                Action = "Vider le sacher"

            });
            return liste;
        }
    }
}
