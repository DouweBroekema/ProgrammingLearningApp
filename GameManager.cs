using ProgrammingLearningApp.Actions;
using ProgrammingLearningApp.ProgramData;

namespace ProgrammingLearningApp
{
    internal class GameManager
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hey! Thanks for using our programming learning app! :)");
            Console.WriteLine("Select an option: " +
                "\n 1) Type R to select a random program " +
                "\n 2) Type the filepath of the program you would like to load");


            // Selecting program
            string Input = Console.ReadLine();
            Program selectedProgram = null;

            switch (Input)
            {
                case "R":
                    selectedProgram = new RandomizedProgramSelector().SelectRandomProgram();
                    break;
                default:
                    selectedProgram = new DefaultProgramParser().ParseProgram(Input,
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



            // Class diagram

            // GameManager
            // Reads the inputs from the user and executes accordingly.


            // ProgramExecutor
            // Takes parsed program and executes that program.
            // methods:
            // ExecuteProgram (Program _program) // perform all IActions.

            // Program
            // List<IAction>


            // IParseAProgram
            // DefaultProgramParser : IProgramParser
            // Program ReadAndParseProgram (string _FilePath)
            // IAction ParseAction (string _newAction) ---> Returns new action based on string
            // Read text file and turn into IAction list. Creates a new program.


            // Here we implement the composite design pattern.
            //IAction
            //methods: 
            // Activate (Player _player)
            //The following inherit from action.
            //MoveAction : IAction
            //TurnAction : IAction
            //RepeatAction : IAction ---> Will hold a list of IActions.  So thus could be more repeaters.


            // Character
            // attribute:
            // position Vector2
            // facingDirection Vector2
            //methods:
            // moveCharacter (Vector2 _movement = Vector2.Zero, Vector2 _direction = Vector2.Zero)


            // MetricsManager
            // CalculateAllMetrics (Program _program)


            // RandomizedExampleProgram
            // Attribute
            // List<Program> examplePrograms;
            // Program SelectRandomProgram()




        }
    }
}
