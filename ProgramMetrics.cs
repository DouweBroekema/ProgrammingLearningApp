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
                    int additionalRepeats = 0;
                    int additionalNestedCommands = 0;

                    int newNestingCount = CalculateNesting((RepeatAction)action, ref additionalRepeats, ref additionalNestedCommands);
                  
                    repeatingCount += 1 + additionalRepeats;
                    commandCount += additionalNestedCommands;

                    if (newNestingCount  > nestingCount) nestingCount = newNestingCount;
                }
            }

            return $"No. of commands {commandCount} \nMax Nesting {nestingCount} \nNo. of repeats {repeatingCount}";
        }

        private int CalculateNesting(RepeatAction action, ref int additionalRepeats, ref int additionalNestedCommands)
        {
            int maxDepth = 0;

            foreach (var nestedAction in action.NestedActions)
            {
                additionalNestedCommands++; 
                if (nestedAction is RepeatAction)
                {
                    additionalRepeats++;
                    int checkDepth = CalculateNesting((RepeatAction)nestedAction, ref additionalRepeats, ref additionalNestedCommands);
                    if(checkDepth > maxDepth) maxDepth = checkDepth;
                }

            }

            return 1 + maxDepth;
        }

    }
}
