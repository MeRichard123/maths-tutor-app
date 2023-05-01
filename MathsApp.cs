using MathsTutor.Packs;
using MathsTutor.Cards;
using System.Text;
using System.Diagnostics;

namespace MathsTutor
{
    internal class MathsApp: MathsParser
    {
        private CardPack cardPack;
        private int correctAnswers = 0;
        private int simpleQuestionsAsked = 0;
        private int complexQuestionsAsked = 0;
        private string statsFileName;

        public MathsApp()
        {
            // initialise pack and shuffle it
            this.cardPack = new CardPack();
            this.cardPack.Shuffle();
            // deal with stats file stuff
            try
            {
                this.statsFileName = this.FileHandler();
            }catch
            {
                Console.WriteLine("Failed to Get file path");
            }
        }

        private string FileHandler()
        {
            // REFERENCE: https://github.com/MeRichard123/Algorithms-Complexity-RoadTraffic-Analysis
            // taking some of this from my Alogorithms and Complexity assigment for parsing the file path
            string currentDir = Directory.GetCurrentDirectory();
            char fileSeparator = Path.DirectorySeparatorChar;
            // null checks 
            if (Directory.GetParent(currentDir) is not null && currentDir is not null)
            {
                if (Directory.GetParent(currentDir)?.Parent is not null)
                {
                    // get the current file path
                    string path = Directory.GetParent(currentDir).Parent.FullName;
                    // split and remove the \bin from the directory
                    List<string> formatPath = path.Split(fileSeparator).ToList<String>();
                    formatPath.RemoveAt(formatPath.Count - 1);
                    string fileName = String.Join(fileSeparator, formatPath) + $"{fileSeparator}Stats.txt";
                    try
                    {
                        // if we already have a file don't make a new one just return the name
                        if (File.Exists(fileName))
                        {
                            return fileName;
                        }
                            
                        // if we don't make one with the text "Statistics"
                        using (FileStream fs = File.Create(fileName))
                        {
                            Byte[] title = new UTF8Encoding(true).GetBytes("Statistics\n");
                            fs.Write(title, 0, title.Length);
                        }
                        return fileName;
                    }
                    catch (Exception ex) {
                        Console.WriteLine(ex.ToString());
                        throw;
                    }
                }
            }
            throw new UnreachableException();
        }
        
        /// <summary>
        ///     Create a stream writer to append to a file in order to 
        ///     be able to write the user score to the file. 
        /// </summary>
        /// <param name="score">
        ///     The score we are writing
        /// </param>
        private void WriteStatsToFile(string score, string name)
        {
            try
            {
                name = name.ToLower();
                if (name.Length >= 1)
                {

                    // create a FileStream so we can open in Append Mode
                    FileStream fs = new FileStream(this.statsFileName, FileMode.Append, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    // get current date ans store when the user got that score. 
                    string currentTime = DateTime.Now.ToString("G");
                    sw.WriteLine($"{name} - {currentTime} - {score}");
                    // discard the stream writer
                    sw.Close();
                } 
                // other wise just don't write the file.

            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        /// <summary>
        ///     Display the leaderboard for the user if one is entered 
        ///     and the whole leaderboard if there is none entered.
        /// </summary>
        /// <param name="name">
        ///     user name lookup 
        /// </param>
        public void ShowStats(string? name)
        {
            try
            {
                string[] stats = File.ReadAllLines(statsFileName);
                if (name is not null && name != "")
                {
                    // detemine if the user entered a name 
                    // and dispaly accordingly
                    Console.WriteLine($"\nStatistics for {name}\n");
                    foreach (string stat in stats)
                    {
                        if (stat.StartsWith(name.ToLower()))
                        {
                            Console.WriteLine(stat);
                        }
                    }
                }
                else
                {
                    foreach (string stat in stats)
                    {
                        Console.WriteLine(stat);
                    }
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        
        /// <summary>
        ///     Determine what type of expression we have,
        ///     choose the correct parser for it. 
        ///     Finally compare the user answer to the parser answer. 
        /// </summary>
        /// <param name="equation">
        ///     A list containing cards
        /// </param>
        /// <param name="userAnswer">
        ///     The value the user entered as the answer    
        /// </param>
        /// <returns>
        ///     A tuple of a boolean and an int. Boolean for if the answer was 
        ///     correct or not, and the int for the correct answer incase they got
        ///     it wrong.
        /// </returns>
        /// <exception cref="ArgumentException">
        ///     If we enter an expression of an unsupported length then throw an error
        /// </exception>
        public (bool,int) EvaluateExpression(List<Card> equation, int userAnswer)
        {
            int correctAnswer;
            switch (equation.Count)
            {
                case 3:
                    correctAnswer = SimpleParse(equation);
                    return (userAnswer == correctAnswer, correctAnswer);
                case 5:
                    correctAnswer = ComplexParse(equation);
                    return (userAnswer == correctAnswer,correctAnswer);
                default:
                    throw new ArgumentException("Invalid Equation Format");
            }
        }
        
        /// <summary>
        ///     Pretty Print for the expression 
        ///     Parse it as a string and return it.
        /// </summary>
        /// <param name="equation">
        ///     A list of cards
        /// </param>
        /// <returns>
        ///     A pretty string for displaying the equation
        /// </returns>
        public string DisplayEquation(List<Card> equation)
        {
            if (equation.Count == 3)
            {
                // get the second item: the operator and parse its string value
                char Operator = equation[1].GetDescriptor(equation[1].Suit);
                // return the string equation 
                return $"\n{equation[0].Value} {Operator} {equation[2].Value} = ";
            }
            else if (equation.Count == 5)
            {
                // get the first and second operator 
                char OperatorOne = equation[1].GetDescriptor(equation[1].Suit);
                char OperatorTwo = equation[3].GetDescriptor(equation[3].Suit);
                return $"\n{equation[0].Value} {OperatorOne} {equation[2].Value} {OperatorTwo} {equation[4].Value} =";
            }
            else
                return "Ivalid Equation Returned";
        }

        /// <summary>
        ///     Display the user menu and let them pick an option
        /// </summary>
        /// <returns>
        ///     Returns the int identfier of the option they have picked
        /// </returns>
        private int ShowMenu()
        {
            Console.WriteLine("\nSelect a option: \n");
            Console.WriteLine("1. Instructions");
            Console.WriteLine("2. Deal 3 Cards");
            Console.WriteLine("3. Deal 5 Cards");
            Console.WriteLine("4. Quit");
            string? option = null;
            int optionValue;
            while (true)
            {
                // error handling for the userinput 
                Console.Write("> ");
                option = Console.ReadLine();
                // read and validate input 
                if (option is not null && int.TryParse(option, out optionValue)){
                    if (optionValue >= 1 && optionValue < 5)
                    {
                        return optionValue;
                    }
                }
            }
        }
            
        /// <summary>
        ///     Deal Cards based on how many the program needs. 
        ///     Then display the equation and ask the user for the answer
        ///     Then we compute the real answer and determine if they were correct
        /// </summary>
        /// <param name="amount">
        ///     The number of cards we want to drawn
        /// </param>
        private void DealCardsAndCalculate(int amount)
        {
            List<Card> equationToSolve = new List<Card>();
            
            // add the dealt cards to the equation
            equationToSolve.AddRange(this.cardPack.Deal(amount));
            // show the equation and ask for an input 
            Console.WriteLine(DisplayEquation(equationToSolve));
            Console.WriteLine("Enter your Answer...");
            string? answer = null;

            // error handling for the input 
            int numberValue;
            while (true)
            {
                Console.Write("> ");
                answer = Console.ReadLine();
                if (int.TryParse(answer, out numberValue))
                {
                    // once we have an answer check it. 
                    (bool, int) EvalExpression = EvaluateExpression(equationToSolve, numberValue);
                    if (EvalExpression.Item1)
                    {
                        correctAnswers++;
                        Console.WriteLine("Yay you got the answer right!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("That is the wrong answer.");
                        Console.WriteLine("The Correct Answer was: ");
                        Console.Write(EvalExpression.Item2);
                        break;
                    }
                }
            }
        }
        
        /// <summary>
        ///     Main Game Loop displaying menu options and calling the correct methods
        /// </summary>
        public void Play()
        {
            bool gameRunning = true;
            Console.WriteLine("For divisions give the floor value, how many times it goes in as a whole number");
            while (gameRunning)
            {
                int menuOption = ShowMenu();

                switch (menuOption)
                {
                    case 1:
                        Tutorial.StartTutorial();
                        break;
                    case 2:
                        simpleQuestionsAsked++;
                        DealCardsAndCalculate(3);
                        break;
                    case 3:
                        complexQuestionsAsked++;
                        DealCardsAndCalculate(5);
                        break;
                    case 4:
                        Console.WriteLine($"\nWell Done you got {correctAnswers} questions right!\n");
                        Console.WriteLine($"Out of the total {simpleQuestionsAsked+complexQuestionsAsked}");
                        Console.WriteLine($"We asked {simpleQuestionsAsked} Simple Questions and {complexQuestionsAsked} Complex Questions.");
                        gameRunning = false;

                        Console.Write("What is your name ");
                        string? name = Console.ReadLine();

                        if (name is not null)
                        {
                            string userScore = $"{correctAnswers}/{simpleQuestionsAsked + complexQuestionsAsked}, {simpleQuestionsAsked} Simple and {complexQuestionsAsked} Complex";
                            try
                            {
                                WriteStatsToFile(userScore, name);
                            } catch
                            {
                                Console.WriteLine("Failed to Write to file");
                            }
                        }
                        break;
                }
            }     
        }
    }
}
