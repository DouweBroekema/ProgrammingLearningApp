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
        public void Execute(Character _character);
    }

    public class MoveAction : IAction
    {
        public int Steps;
        public void Execute(Character _character)
        {

            switch (_character.Rotation)
            {
                case Rotation.South:
                    _character.Position = new Vector2Int(_character.Position.x, _character.Position.y - Steps);
                    break;
                case Rotation.East:
                    _character.Position = new Vector2Int(_character.Position.x + Steps, _character.Position.y);
                    break;
                case Rotation.North:
                    _character.Position = new Vector2Int(_character.Position.x, _character.Position.y + Steps);
                    break;
                case Rotation.West:
                    _character.Position = new Vector2Int(_character.Position.x - Steps, _character.Position.y);
                    break;
            }
        }
    }

    public class TurnAction : IAction
    {
        public TurnDirection Direction;
        public void Execute(Character _character)
        {
            int result = 0;
            int maxRot = Enum.GetNames(typeof(Rotation)).Length;
            switch (Direction)
            {
                case TurnDirection.Left:
                    result = (int)_character.Rotation + 1;
                    int lastValue = maxRot;
                    if (result > lastValue) _character.Rotation = 0;
                    else _character.Rotation += 1;
                    break;
                case TurnDirection.Right:
                    result = ((int)_character.Rotation - 1 + maxRot) % maxRot;
                    if (result < 0) _character.Rotation -= 1;
                    else _character.Rotation = (Rotation)result;
                    break;
            }
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
        public void Execute(Character _character)
        {
            for (int i = 0; i < RepeatAmount; i++)
            {
                foreach (var _action in NestedActions)
                {
                    _action.Execute(_character);
                }
            }
        }
    }
    #endregion

    #region IParseAction and types
    public interface IParseAction
    {
        public bool UseNesting => false;
        public string TextFileCommand => "Nothing";

        public IAction IParseAction(string _actionText = default, List<IAction> _nestedActions = default);
    }

    public class ParseMove : IParseAction
    {
        public bool UseNesting => false;
        public string TextFileCommand => "Move";

        public IAction IParseAction(string _actionText = default, List<IAction> _nestedActions = default)
        {
            _actionText = _actionText.TrimStart(' ');
            string[] _strings = _actionText.Split(' ');
            return new MoveAction
            {
                Steps = int.Parse(_strings[1])
            };
        }
    }

    public class ParseTurn : IParseAction
    {
        public bool UseNesting => false;
        public string TextFileCommand => "Turn";

        public IAction IParseAction(string _actionText = default, List<IAction> _nestedActions = default)
        {
            _actionText = _actionText.TrimStart(' ');
            string[] _strings = _actionText.Split(' ');

            TurnAction.TurnDirection direction = default;

            switch (_strings[1])
            {
                case "left":
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
        public bool UseNesting => true;
        public string TextFileCommand => "Repeat";

        public IAction IParseAction(string _actionText = default, List<IAction> _nestedActions = default)
        {
            _actionText = _actionText.TrimStart(' ');
            string[] _strings = _actionText.Split(' ');

            return new RepeatAction
            {
                RepeatAmount = int.Parse(_strings[1]),
                NestedActions = _nestedActions  
            };
        }

    }
    #endregion
}
