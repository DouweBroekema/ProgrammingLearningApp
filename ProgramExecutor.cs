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
        public void ExecuteProgram(Program _program, Character _character)
        {

            foreach (var action in _program.AllActions)
            {
                action.Execute(_character);
            } 
        }
    }
}
