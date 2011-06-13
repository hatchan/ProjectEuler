using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Args.Help;
using Args.Help.Formatters;

namespace ProjectEuler.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var modelBindingDefinition = Args.Configuration.Configure<RunnerCommands>();
            var command = modelBindingDefinition.CreateAndBind(args);

            var helpProvider = new HelpProvider();
            var generateModelHelp = helpProvider.GenerateModelHelp(modelBindingDefinition);

            var formatter = new ConsoleHelpFormatter();
            formatter.WriteHelp(generateModelHelp, Console.Out);

            Console.WriteLine();

            //Console.WriteLine("RunProblem: {0}", command.RunProblem.HasValue ? command.RunProblem.Value.ToString() : "No value" );
            //Console.WriteLine("Page: {0}", command.Page.HasValue ? command.Page.Value.ToString() : "No value");
        }
    }

    public class RunnerCommands
    {
        [System.ComponentModel.Description("Immediately run this problem")]
        public int? RunProblem { get; set; }

        [System.ComponentModel.Description("Open the problem browser on this page (defaults to 20 items per page)")]
        public int? Page { get; set; }
    }
}
