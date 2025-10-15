using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLearningApp.Actions
{

    #region IAction and types
    public interface IAction
    {
        public void Execute();
    }

    public class MoveAction : IAction
    {
        public int Steps;
        public void Execute()
        {

        }
    }

    public class TurnAction : IAction
    {
        public TurnDirection Direction;
        public void Execute()
        {

        }

        public enum TurnDirection
        {
            Left,
            Right
        }
    }

    public class RepeatAction : IAction
    {
        public int RepeatAmount;
        public List<IAction> NestedActions;
        public void Execute()
        {

        }
    }
    #endregion

    #region IParseAction and types
    public interface IParseAction
    {
        public string TextFileCommand => "Nothing";

        public IAction IParseAction(string _actionText);
    }

    public class ParseMove : IParseAction
    {
        public string TextFileCommand => "Move";

        public IAction IParseAction(string _actionText)
        {
            string[] _strings = _actionText.Split(' ');
            return new MoveAction
            {
                Steps = int.Parse(_strings[1])
            };
        }
    }

    public class ParseTurn : IParseAction
    {
        public string TextFileCommand => "Turn";

        public IAction IParseAction(string _actionText)
        {
            string[] _strings = _actionText.Split(' ');

            TurnAction.TurnDirection direction = default;

            switch (_strings[1])
            {
                case "Left":
                    direction = TurnAction.TurnDirection.Left;
                    break;
                case "right":
                    direction = TurnAction.TurnDirection.Right;
                    break;
            }

            return new TurnAction
            {
                Direction = direction        
            };
        }

    }

    public class ParseRepeat : IParseAction
    {
        public string TextFileCommand => "Repeat";

        public IAction IParseAction(string _actionText)
        {
            string[] _strings = _actionText.Split(' ');

            return new RepeatAction
            {
                RepeatAmount = int.Parse(_strings[1])
            };
        }

    }
    #endregion
}
