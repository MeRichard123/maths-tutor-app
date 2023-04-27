namespace MathsTutor
{
    internal static class Tutorial
    {
        public static List<string> TutorialSteps = new List<string>()
        {
            "Hello Fellow Maths Enthusiasts!",
            "Welcome to your maths tutor! ",
            "- You will be presented with a menu on each round",
            "- It is your choice whether you decide on 3 cards or if you are feeling up for the challenge 5 cards.",
            "- For each one calcualte the correct answer and enter it in the box.",
            "- If you pick 5 remember BODMAS",
            "GOOD LUCK!! \n",
        };
        public static void StartTutorial()
        {
            // iterate over the steps array and print it to console. 
            foreach (string step in TutorialSteps)
            {
                Console.WriteLine(step + "\n");
                // wait 2.5 seconds before the next step.
                Thread.Sleep(2500);
            }
        }
    }
}
