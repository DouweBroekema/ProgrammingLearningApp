using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ProgrammingLearningApp.Actions;

namespace ProgrammingLearningApp.ProgramData
{
    public interface IProgramParser
    {
        public Program ParseProgram(string _filePath, List<IParseAction> _allPossibleActions);
    }

    public class DefaultProgramParser : IProgramParser
    {
        private string currentLine;
        private List<IParseAction> allPossibleAction;
        private StreamReader reader;


        /// <summary>
        /// Parses text file with the specified layout from the assignment.
        /// </summary>
        /// <param name="_filePath"></param> specified file path
        /// <param name="allPossibleCommands"></param> all possible actions in this program
        /// <returns></returns>
        public Program ParseProgram(string _filePath, List<IParseAction> _allPossibleActions)
        {
            this.allPossibleAction = _allPossibleActions;   


            List<IAction> _allActionsCollected = new();

            reader = new StreamReader(_filePath);
            // Reading file
            using (reader) 
            {
                
                currentLine = reader.ReadLine();

                _allActionsCollected = ParseRecursive(0);
            }

            return new Program(_allActionsCollected);
        }

        // TDOO: Parser not working fully yet.

        /// <summary>
        /// Recursively search the file to generate IAction list.
        /// </summary>
        /// <param name="_curentWhiteSpacing"></param>
        /// <returns></returns>
        private List<IAction> ParseRecursive(int _curentWhiteSpacing)
        {
            List<IAction> _collectedActions = new();

            while(currentLine != null)
            {
                if(currentLine.Contains("Repeat") && ComputeWhiteSpacing(currentLine) == _curentWhiteSpacing)
                {
                    // Nested loop.
                    currentLine = reader.ReadLine();

                    // Create the nested action
                    RepeatAction nestedAction = (RepeatAction)ActionParser(currentLine);

                    nestedAction.NestedActions = ParseRecursive(_curentWhiteSpacing + 1);
                    _collectedActions.Add(nestedAction);

                    _collectedActions.Add(nestedAction);
                }
                else if (ComputeWhiteSpacing(currentLine) == _curentWhiteSpacing)
                {
                    _collectedActions.Add(ActionParser(currentLine));
                }

                currentLine = reader.ReadLine();
            }

            return _collectedActions;

        }


        /// <summary>
        /// Parse string or list of strings into IAction
        /// </summary>
        /// <param name="_actionString"></param>
        /// <param name="_allPossibleActions"></param>
        /// <returns></returns>
        private IAction? ActionParser(string _actionString, List<IAction> _nestedActions = default)
        {

            // Searching through commands for match.
            foreach (IParseAction _action in allPossibleAction)
            {
                // Check if command matches with data from textfile
                if (_actionString.Contains(_action.TextFileCommand)) return _action.IParseAction(_actionString, _nestedActions);
            }

            // No corresponding action found. Break program and output to console 
            Console.WriteLine("Action string in program did not match any of the implemented actions");
            return default;
        }


        /// <summary>
        /// Computes white spacing placed at the start of the string.
        /// </summary>
        /// <param name="_String"></param>
        /// <returns></returns>
        private int ComputeWhiteSpacing(string _String) => _String.TakeWhile(x => x == ' ').Count();

    }


}
