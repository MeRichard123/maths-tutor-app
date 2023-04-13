namespace MathsTutor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // main entry point 
            Console.WriteLine("Welcome to your personal Maths Tutor \n");
            MathsApp app = new MathsApp();

            // let the user pick of they are playing or tesing.
            Console.WriteLine("Would you like to?: ");
            Console.WriteLine("1) Test Code");
            Console.WriteLine("2) Play Game");
            string? gameOption = Console.ReadLine();
            // either run play or test
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