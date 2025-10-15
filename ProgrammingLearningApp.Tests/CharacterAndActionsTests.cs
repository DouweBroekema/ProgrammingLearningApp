using Xunit;
using ProgrammingLearningApp;

using ProgrammingLearningApp.Actions;

namespace ProgrammingLearningApp.Tests
{
    public class CharacterAndActionsTests
    {
        [Fact]
        public void Character_Defaults_To_Origin_Facing_East()
        {
            var c = new Character();
            Assert.Equal(0, c.Position.x);
            Assert.Equal(0, c.Position.y);
            Assert.Equal(Rotation.East, c.Rotation);
        }

        [Fact]
        public void MoveAction_Moves_In_Current_Rotation()
        {
            var c = new Character(); 
            new MoveAction { Steps = 3 }.Execute(c);
            Assert.Equal(3, c.Position.x);
            Assert.Equal(0, c.Position.y);
            Assert.Equal(Rotation.East, c.Rotation);
        }

        [Fact]
        public void Turn_Right_From_East_Goes_South()
        {
            var c = new Character(); 
            new TurnAction { Direction = TurnAction.TurnDirection.Right }.Execute(c);
            Assert.Equal(Rotation.South, c.Rotation);
        }

        [Fact]
        public void Turn_Left_From_East_Goes_North()
        {
            var c = new Character(); 
            new TurnAction { Direction = TurnAction.TurnDirection.Left }.Execute(c);
            Assert.Equal(Rotation.North, c.Rotation);
        }
    }
}
