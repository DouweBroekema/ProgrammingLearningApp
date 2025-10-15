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
        public Program ParseProgram(string _filePath);
    }

    public class DefaultProgramParser : IProgramParser
    {
        /// <summary>
        /// Parses text file with the specified layout from the assignment.
        /// </summary>
        /// <param name="_filePath"></param> specified file path
        /// <param name="allPossibleCommands"></param> all possible actions in this program
        /// <returns></returns>
        public Program ParseProgram(string _filePath, List<IParseAction> _allPossibleActions)
        {
            try
            {
                List<IAction> allActions = new();

                // Create stream reader.
                StreamReader newStreamReader = new StreamReader(_filePath);

                // Scanning document
                string currentLine = newStreamReader.ReadLine();
                
                // Continue until end of the file
                while (currentLine != null)
                {
                    
                }

                // Close file
                newStreamReader.Close();    


            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong whilst parsing the program.");
                return null;
            }

            return null;

        }

        public IAction ActionParser(string _actionString, List<IParseAction> _allPossibleActions)
        {

            // Searching through commands for match.
            foreach (IParseAction action in _allPossibleActions)
            {
                // Check if command matches with data from textfile
                if (_actionString.Contains(action.TextFileCommand)) return action.IParseAction(_actionString);
            }

            // No corresponding action found. Break program and output to console 
            Console.WriteLine("Action string in program did not match any of the implemented actions");
            return default;
        }


    }


}
