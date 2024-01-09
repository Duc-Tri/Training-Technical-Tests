using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://tutorials.eu/50-interview-questions-for-your-csharp-interview/

namespace Training3_50questions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Q08();
        }

        public class ClassQ08
        {

            // Membre de classe statique
            public static int Compteur { get; set; }

            // Constructeur statique
            static ClassQ08()
            {
                Compteur = 0;
                Console.WriteLine("Le constructeur statique a été appelé.");
                // n'est appelé que si l'on utilise une propriété, ou constructeur de la classe
            }

            public ClassQ08()
            {
                Compteur++;
            }
        }

        static void Q08()
        {
            // Accès à la classe et à son membre statique
            Console.WriteLine("Compteur avant l'instance : " + ClassQ08.Compteur);

            // Création d'instances de la classe
            ClassQ08 instance1 = new ClassQ08();
            ClassQ08 instance2 = new ClassQ08();

            // Accès au membre statique après les instances
            Console.WriteLine("Compteur après les instances : " + ClassQ08.Compteur);
        }

    }
}
