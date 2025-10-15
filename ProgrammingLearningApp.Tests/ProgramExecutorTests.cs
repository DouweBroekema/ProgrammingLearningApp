using Xunit;
using ProgrammingLearningApp;
using ProgrammingLearningApp.ProgramData;
using ProgrammingLearningApp.Actions;
using System.Collections.Generic;

namespace ProgrammingLearningApp.Tests
{
    public class ProgramExecutorTests
    {
        [Fact]
        public void Executes_Simple_Sequence_And_Reports_EndState()
        {
            var program = new Program(
                new List<IAction>
                {
                    new MoveAction{ Steps = 1 }, // east
                    new TurnAction{ Direction = TurnAction.TurnDirection.Right }, //south
                    new MoveAction{ Steps = 2 }  // (1,-2)
                },
                new List<string>
                {
                    "Move 1",
                    "Turn right",
                    "Move 2",
                });

            var character = new Character();
            var executor = new ProgramExecutor();

            var trace = executor.ExecuteProgram(program, character);

            Assert.Contains("Move 1", trace);
            Assert.Contains("Turn right", trace);
            Assert.Contains("Move 2", trace);
            Assert.Contains("End state (1,-2) facing South", trace);
        }

        [Fact]
        public void Rectangle_Repeat_Four_Times_Ends_At_Origin_Facing_East_And_TraceMentionsCommands()
        {
            var repeat = new RepeatAction
            {
                RepeatAmount = 4,
                NestedActions = new List<IAction>
                {
                    new MoveAction{ Steps = 10 },
                    new TurnAction{ Direction = TurnAction.TurnDirection.Right }
                }
            };

            var program = new Program(
                new List<IAction> { repeat },
                new List<string>
                {
                   "Repeat 4 times",
                   "    Move 10",
                   "    Turn right"
                });

            var character = new Character();
            var executor = new ProgramExecutor();
            var output = executor.ExecuteProgram(program, character);


            Assert.Contains("End state (0,0) facing East", output);

            Assert.Contains("Repeat 4 times", output);
            Assert.Contains("Move 10", output);
            Assert.Contains("Turn right", output);
        }
    }
}

