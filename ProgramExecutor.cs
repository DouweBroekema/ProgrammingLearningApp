using ProgrammingLearningApp.ProgramData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLearningApp
{
    public class ProgramExecutor
    {
        public string ExecuteProgram(Program _program, Character _character)
        {
            string executedString = "";
            foreach (var action in _program.AllActions)
            {
                action.Execute(_character);
            }

            for (int i = 0; i < _program.AllStrings.Count; i++)
            {
                if (i == _program.AllStrings.Count - 1) executedString += _program.AllStrings[i] + ".";
                else executedString = _program.AllStrings[i] + ", ";
;           }

            executedString += $" End state ({_character.Position.x},{_character.Position.y}) facing {Enum.GetName(typeof(Rotation), _character.Rotation)}";
            return executedString;           
        }
    }
}
