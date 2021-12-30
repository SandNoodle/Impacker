using System;
using System.Collections.Generic;

using CommandLine;
using CommandLine.Text;

using Impacker.Core;

namespace Impacker
{
	class Program
	{

		static void Main(string[] args)
		{
			var parser = new CommandLine.Parser(with => 
			{
				with.HelpWriter = null;
				with.CaseInsensitiveEnumValues = true;

			});
			var parseResult = parser.ParseArguments<CommandLineOptions>(args);
			parseResult
			.WithParsed<CommandLineOptions>(options => {
				var commandLineOptions = ((Parsed<CommandLineOptions>)parseResult).Value;
				ImageProcessor imageProcessor = new ImageProcessor(commandLineOptions);
				imageProcessor.Process();
			})
			.WithNotParsed<CommandLineOptions>(errors => 
				DisplayHelp(parseResult, errors)
			);
		}

		static void DisplayHelp<T>(ParserResult<T> result, IEnumerable<Error> errors)
		{
			var helpText = HelpText.AutoBuild(result, h => 
			{
				h.AdditionalNewLineAfterOption = false;
				return HelpText.DefaultParsingErrorsHandler(result, h);
			}, errors => errors);
			Console.WriteLine(helpText);
		}
	}
}
