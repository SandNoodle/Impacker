﻿using System;

using CommandLine;

using Impacker.Core;

namespace Impacker
{
	class Program
	{

		static void Main(string[] args)
		{
			// Parse command line arguments
			var parseResult = Parser.Default.ParseArguments<CommandLineOptions>(args);
			if(parseResult.Tag == ParserResultType.Parsed)
			{
				var commandLineOptions = ((Parsed<CommandLineOptions>)parseResult).Value;
				ImageProcessor imageProcessor = new ImageProcessor(commandLineOptions);
				imageProcessor.Process();
			}

		}
	}
}
