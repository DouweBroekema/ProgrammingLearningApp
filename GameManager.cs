namespace ProgrammingLearningApp
{
    internal class GameManager
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");


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
