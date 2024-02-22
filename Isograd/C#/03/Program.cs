using System;
using System.IO;

namespace IsogradC_03
{
    public class Question
    {
        public void MyMethod(Action actionDelegate, out int value)
        {
            try
            {
                actionDelegate();
                value = 0;
            }
            //-----------------------------------------------------------------
            catch (FileNotFoundException e)
            {
                value = 1;
                throw e;
                throw; // met à jour la propriété StackTrace de e.
            }
            catch (Exception)
            {
                value = 2;
                throw; // conserve la trace de pile d’origine de l’exception, qui est stockée dans la propriété Exception.StackTrace
            }
            //-----------------------------------------------------------------

        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int val = -1;

            Action fileNotFoundAction = () =>
            {
                FileStream fs = File.OpenRead("_non_existing_file_");
            };

            Action otherException = () =>
            {
                int b = 0;
                int a = 1 / b;
            };

            Action noProblem = () => { };

            try
            {
                (new Question()).MyMethod(otherException, out val);
            }
            catch
            {
            }
            finally
            {
                Console.WriteLine("val = " + val);
            }

        }

    }

}
