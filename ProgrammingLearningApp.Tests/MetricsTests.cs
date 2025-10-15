using Xunit;
using ProgrammingLearningApp;
using ProgrammingLearningApp.ProgramData;
using ProgrammingLearningApp.Actions;
using System.Collections.Generic;

namespace ProgrammingLearningApp.Tests
{
    public class MetricsTests
    {
        [Fact]
        public void Metrics_Match_Spec_For_Examples()
        {
            var metrics = new ProgramMetrics();

            
            var rect1 = new Program(
                new List<IAction>
                {
                    new MoveAction{ Steps = 10 },
                    new TurnAction{ Direction = TurnAction.TurnDirection.Right },
                    new MoveAction{ Steps = 10 },
                    new TurnAction{ Direction = TurnAction.TurnDirection.Right },
                    new MoveAction{ Steps = 10 },
                    new TurnAction{ Direction = TurnAction.TurnDirection.Right },
                    new MoveAction{ Steps = 10 },
                    new TurnAction{ Direction = TurnAction.TurnDirection.Right },
                },
                new List<string>()
            );
            var m1 = metrics.ComputeMetrics(rect1);
            Assert.Contains("No. of commands 8", m1);
            Assert.Contains("Max Nesting 0", m1);
            Assert.Contains("No. of repeats 0", m1);

            
            var rect2 = new Program(
                new List<IAction>
                {
                    new RepeatAction
                    {
                        RepeatAmount = 4,
                        NestedActions = new List<IAction>
                        {
                            new MoveAction{ Steps = 10 },
                            new TurnAction{ Direction = TurnAction.TurnDirection.Right }
                        }
                    }
                },
                new List<string>()
            );
            var m2 = metrics.ComputeMetrics(rect2);
            Assert.Contains("No. of commands 3", m2);
            Assert.Contains("Max Nesting 1", m2);
            Assert.Contains("No. of repeats 1", m2);

            
            var random = new Program(
                new List<IAction>
                {
                    new MoveAction{ Steps = 5 },
                    new TurnAction{ Direction = TurnAction.TurnDirection.Left },
                    new TurnAction{ Direction = TurnAction.TurnDirection.Left },
                    new MoveAction{ Steps = 3 },
                    new TurnAction{ Direction = TurnAction.TurnDirection.Right },
                    new RepeatAction
                    {
                        RepeatAmount = 3,
                        NestedActions = new List<IAction>
                        {
                            new MoveAction{ Steps = 1 },
                            new TurnAction{ Direction = TurnAction.TurnDirection.Right },
                            new RepeatAction
                            {
                                RepeatAmount = 5,
                                NestedActions = new List<IAction>
                                {
                                    new MoveAction{ Steps = 2 }
                                }
                            }
                        }
                    }
                },
                new List<string>()
            );
            var m3 = metrics.ComputeMetrics(random);
            Assert.Contains("No. of commands 10", m3);
            Assert.Contains("Max Nesting 2", m3);
            Assert.Contains("No. of repeats 2", m3);
        }
    }
}
