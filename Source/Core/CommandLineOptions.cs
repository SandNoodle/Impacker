using System;
using System.Collections.Generic;

using CommandLine;

public class CommandLineOptions
{

	[Option('s', "size", Required = true, HelpText = "Output image size. Multiple values can be specified.")]
	public IEnumerable<Int32> ImageSizes { get; set; }

	[Option('i', "input", Default = "./", Required = false, HelpText="Input directory.")]
	public string InputDirectory { get; set; }
	
	[Option('o', "output", Required = false, Default = "./out/", HelpText="Output directory.")]
	public string OutputDirectory { get; set; }

	[Option('t', "type", Required = false, Default="png", HelpText="Output file type. Possible values: [PNG], TGA, JPG, BMP")]
	public string FileType { get; set; }

	[Option('f', "filter", Required = false, Default = "nearest", HelpText = "Resizing filtering alghoritm. Possible values: [NEAREST], BILINEAR, BICUBIC.")]
	public string FilterType { get; set; }

}