using ProgrammingLearningApp.Actions;
using ProgrammingLearningApp.ProgramData;

namespace ProgrammingLearningApp
{
    internal class GameManager
    {

        static void Main(string[] args)
        {
            #region Intializing Data
            Program selectedProgram = null;
            IProgramParser selectedParser = new DefaultProgramParser();
            List<IParseAction> allPossibleActions = new List<Actions.IParseAction>()
                        {
                            new ParseMove(),
                            new ParseTurn(),
                            new ParseRepeat()
                        };
            #endregion
            #region Program flow
            Console.WriteLine("Hey! Thanks for using our programming learning app! :)");
            Console.WriteLine("Select an option: " +
                "\n 1) Type R to select a random program " +
                "\n 2) Type the filepath of the program you would like to load");


            // Selecting program
            string Input = Console.ReadLine();


            switch (Input)
            {
                case "R":
                    selectedProgram = new RandomizedProgramSelector().SelectRandomProgram(selectedParser, allPossibleActions);
                    break;
                default:
                    selectedProgram = selectedParser.ParseProgram(Input,
                        new List<Actions.IParseAction>()
                        {
                            new ParseMove(),
                            new ParseTurn(),
                            new ParseRepeat()
                        });
                    break;
            }


            Console.WriteLine("Awesome! What would you like to do with your program?" +
                "\n 1) Type E to execute it!" + 
                "\n 2) Type CM to calculate the metrics of your program");

            // Selecting mode
            string mode = Console.ReadLine();
            switch (mode)
            {
                case "E":
                    Console.WriteLine(new ProgramExecutor().ExecuteProgram(selectedProgram, new Character()));
                    break;
                case "CM":
                    Console.WriteLine(new ProgramMetrics().ComputeMetrics(selectedProgram));
                    break;
            }
            #endregion

        }
    }
}
