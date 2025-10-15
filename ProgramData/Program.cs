using ProgrammingLearningApp.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLearningApp.ProgramData
{
    public class Program
    {
        public List<string> AllStrings;
        public List<IAction> AllActions;

        public Program(List<IAction> _allActions, List<string> _allStrings)
        {
            AllActions = _allActions;  
            AllStrings = _allStrings;
        }
    }
}
