using Xunit;
using ProgrammingLearningApp.ProgramData;
using ProgrammingLearningApp.Actions;
using System.Linq;

namespace ProgrammingLearningApp.Tests
{
    public class ParserTests
    {
        [Fact]
        public void Parses_Move_And_Turn_Lines()
        {
            var text = 
@"Move 5
Turn right
Move 3";

            var path = TestHelpers.CreateTempProgramFile(text);
            var parser = TestHelpers.MakeDefaultParser();

            var program = parser.ParseProgram(path, TestHelpers.DefaultActions());

            Assert.Equal(3, program.AllActions.Count);
            Assert.Equal(3, program.AllStrings.Count);

            Assert.Contains("Move 5", program.AllStrings[0]);
            Assert.Contains("Turn right", program.AllStrings[1]);
        }

        [Fact]
        public void Parses_Repeat_With_Indents_And_Nested_Actions()
        {
            var text =
@"Repeat 3 times
    Move 2
    Turn left";

            var path = TestHelpers.CreateTempProgramFile(text);
            var program = TestHelpers.MakeDefaultParser().ParseProgram(path, TestHelpers.DefaultActions());

            Assert.Single(program.AllActions);
            var repeat = Assert.IsType<RepeatAction>(program.AllActions[0]);
            Assert.Equal(3, repeat.RepeatAmount);
            Assert.Equal(2, repeat.NestedActions.Count);
            Assert.IsType<MoveAction>(repeat.NestedActions[0]);
            Assert.IsType<TurnAction>(repeat.NestedActions[1]);
        }

        [Fact]
        public void Parses_Nested_Repeat_In_Repeat()
        {
            var text =
@"Repeat 2 times
    Repeat 3 times
        Move 1";

            var path = TestHelpers.CreateTempProgramFile(text);
            var program = TestHelpers.MakeDefaultParser().ParseProgram(path, TestHelpers.DefaultActions());

            var outer = Assert.IsType<RepeatAction>(program.AllActions.Single());
            Assert.Equal(2, outer.RepeatAmount);

            var inner = Assert.IsType<RepeatAction>(outer.NestedActions.Single());
            Assert.Equal(3, inner.RepeatAmount);

            Assert.IsType<MoveAction>(inner.NestedActions.Single());
        }
    }
}

