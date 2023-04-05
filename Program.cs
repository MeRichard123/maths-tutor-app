using MathsTutor.Packs;

namespace MathsTutor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to your personal Maths Tutor \n");
            MathsApp app = new MathsApp();

            app.Play();

            Console.WriteLine("Good Bye User!");

        }
    }
}