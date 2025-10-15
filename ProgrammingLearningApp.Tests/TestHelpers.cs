using System;
using System.IO;
using System.Collections.Generic;
using ProgrammingLearningApp.Actions;
using ProgrammingLearningApp.ProgramData;

namespace ProgrammingLearningApp.Tests
{
    internal static class TestHelpers
    {
        public static string CreateTempProgramFile(string contents)
        {
            var path = Path.GetTempFileName();
            File.WriteAllText(path, contents.Replace("\r\n", "\n").Replace("\n", Environment.NewLine));
            return path;
        }

        public static IProgramParser MakeDefaultParser()
            => new DefaultProgramParser();

        public static List<IParseAction> DefaultActions() => new()
        {
            new ParseMove(),
            new ParseTurn(),
            new ParseRepeat()
        };
    }
}