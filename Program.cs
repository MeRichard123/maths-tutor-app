namespace MathsTutor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to your personal Maths Tutor \n");
            MathsApp app = new MathsApp();

            Console.WriteLine("Would you like to?: ");
            Console.WriteLine("1) Test Code");
            Console.WriteLine("2) Play Game");
            string? gameOption = Console.ReadLine();
            if(gameOption is not null)
            {
                if(gameOption == "1")
                {
                    Testing testing = new Testing();
                    testing.RunTests();
                }
                else
                {
                    app.Play();
                }
            }




            Console.WriteLine("\nGood Bye User!");

        }
    }
}