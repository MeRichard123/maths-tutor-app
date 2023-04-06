namespace MathsTutor
{
    internal class Tutorial
    {
        public List<string> TutorialSteps = new List<string>()
        {
            "Hello Fellow Maths Enthusiasts!",
            "Welcome to your maths tutor! ",
            "- You will be presented with a menu on each round",
            "- It it your choice whether you decide on 3 cards of if you are feeling up for the challenge 5 cards.",
            "- For each one calcualte the correct answer and enter it in the box.",
            "- If you pick 5 remember BODMAS",
            "GOOD LUCK!! \n",
        };
        public void StartTutorial()
        {
            foreach (string step in TutorialSteps)
            {
                Console.WriteLine(step + "\n");
                Thread.Sleep(2500);
            }
        }
    }
}
