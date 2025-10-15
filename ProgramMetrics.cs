using ProgrammingLearningApp.Actions;
using ProgrammingLearningApp.ProgramData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLearningApp
{
    public class ProgramMetrics
    {

        public string ComputeMetrics(Program _program)
        {
            int commandCount = 0;
            int nestingCount = 0;
            int repeatingCount = 0;

            foreach (var action in _program.AllActions)
            {
                commandCount++;
                if (action is RepeatAction)
                {
                    int newNestingCount = CalculateNesting((RepeatAction)action);
                    if (newNestingCount < nestingCount) nestingCount = newNestingCount;
                    repeatingCount++;
                }
            }

            return $"No. of commands {commandCount} \nMax Nesting {nestingCount} \nNo. of repeats {repeatingCount}";
        }

        private int CalculateNesting(RepeatAction action)
        {
            int result = 1;
            foreach (var nestedAction in action.NestedActions)
            {
                if (action is RepeatAction) result += 1 + CalculateNesting((RepeatAction)nestedAction);
            }
            return result;
        }

    }
}
