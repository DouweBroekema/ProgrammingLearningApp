using ProgrammingLearningApp.ProgramData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammingLearningApp.ProgramData;
using ProgrammingLearningApp.Actions;


namespace ProgrammingLearningApp
{
    public class RandomizedProgramSelector
    {

        public Program SelectRandomProgram(IProgramParser _parser, List<IParseAction> _allPossibleActions)
        {
            string exampleDirectory = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "ExamplePrograms");

            List<Program> examplePrograms = new();
            String[] allExampleFiles = Directory.GetFiles(exampleDirectory);

            foreach (String exampleFile in allExampleFiles)
            {
                examplePrograms.Add(_parser.ParseProgram(exampleFile, _allPossibleActions));
            }

            var random = new Random();
            var randomFile = random.Next(examplePrograms.Count);
            return examplePrograms[randomFile];
        }
    }


}
