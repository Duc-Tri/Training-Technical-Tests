using System;
using System.Collections.Generic;

// https://tutorials.eu/50-interview-questions-for-your-csharp-interview/

/*

1. What is a class?
2. What are the main concepts of object-oriented programming?
3. Explain Encapsulation
4. What is abstraction?
5. What is polymorphism?
6. What is Inheritance in C#?
7. What is an object?
8. What is a constructor, and what are its different types?
9. What is a destructor in C#?
10. Is C# code managed or unmanaged code?
11. What are value types and reference types?
12. What are namespaces, and is that compulsory?
13. Explain types of comments in c# with examples.
14. What is an interface? Give an example.
15. How to implement multiple interfaces with the same method name in the same class?
16. What is the virtual method, and how is it different from the abstract method?
17. What is method overloading and method overriding?
18. What is the static keyword?
19. Can we use “this” with the static class?
20. What is the difference between constants and read-only?
21. What is the difference between string and string builder in C#?
22. Explain the “continue” and “break” statement.
23. What are boxing and unboxing?
24. What is a sealed class?
25. What is a partial class?
26. What is enum?
27. What is dependency injection, and how can it be achieved?
28. The “using” statement.
29. What are the access modifiers? Explain each type.
30. What are delegates?
31. What are the different types of delegates?
32. What is an array? Explain Single and multi-dimensional arrays.
33. What is the difference between the System.Array.CopyTo() and System.Array.Clone() ?
34. What is the difference between array and arraylist?
35. What is a jagged array in C#?
36. What is the difference between struct and class?
37. What is the difference between throw and throw ex?
38. Explain the difference between finally and finalize block?
39. Explain var and dynamic.
40. What are Anonymous types in C#?
41. What is multithreading, and what are its different states?
42. How is exception handling done in C#?
43. What are the custom exceptions?
44. What is LINQ in C#?
45. What is serialization?
46. What are generics in c#?
47. What is reflection?
48. How to use nullable types?
49. Which is the parent class of all classes which we create in C#?
50. Explain code compilation in C#.

*/

namespace Training3_50questions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Q08();
            Q33();
        }

        private static void Q33()
        {
            int[] marks = new int[3] { 25, 34, 89 };
            int[] marksCopy = new int[4];
            int[] marksClone = (int[])marks.Clone();
            marks.CopyTo(marksCopy, 1);

            Console.WriteLine("marks = " + string.Join(" * ", marks));
            Console.WriteLine("marksCopy = " + string.Join(" * ", marksCopy));
            Console.WriteLine("marksClone = " + string.Join(" * ", marksClone));
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

        public class ClassQ20
        {
            const int Compteur = 0;
            readonly List<int> li = new List<int>();
            readonly int NumId; // initialisé pas le constructeur (par défaut s'il y en a pas)
        }

        public abstract class ClassQ15
        {
            public virtual void MethodVirtual()
            {
                // doit avoir un corps
            }

            public abstract void MethodAbstract(); // seulement dans une classe abstraite
        }

        public class ClassQ15Child : ClassQ15
        {
            public override void MethodAbstract()
            {
                // implémentation obligatoire !
                Console.WriteLine("Override de la méthode abstraite.");
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