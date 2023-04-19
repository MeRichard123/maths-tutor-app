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
            Console.WriteLine("3) Display Statistics");
            string? gameOption = Console.ReadLine();
            // either run play or test
            if(gameOption is not null)
            {
                if(gameOption == "1")
                {
                    Testing testing = new Testing();
                    testing.RunTests();
                }
                else if (gameOption == "2")
                {
                    app.Play();
                }
                else if (gameOption == "3")
                {
                    Console.WriteLine("What name would you like to lookup?");
                    Console.WriteLine("Don't enter anything if you want to see the whole Stats Board");
                    string? name = Console.ReadLine();
                    try
                    {
                        app.ShowStats(name);
                    }catch
                    {
                        Console.WriteLine("Failed dispay stats. Something went wrong.");
                    }
                }
            }




            Console.WriteLine("\nGood Bye User!");

        }
    }
}