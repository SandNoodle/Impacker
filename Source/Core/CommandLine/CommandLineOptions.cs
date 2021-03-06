using System;
using System.Collections.Generic;

using CommandLine;

using Impacker.Core;

public class CommandLineOptions
{

	[Option('s', "size", Required = true, HelpText = "Output image size. Multiple values can be specified.")]
	public IEnumerable<Int32> ImageSizes { get; set; }

	[Option('i', "input", Default = "./", Required = false, HelpText = "Input directory.")]
	public string InputDirectory { get; set; }

	[Option('o', "output", Required = false, Default = "./out/", HelpText = "Output directory.")]
	public string OutputDirectory { get; set; }

	[Option('t', "type", Required = false, Default = "png", HelpText = "Output file type. Possible values: [PNG], TGA, JPG, BMP")]
	public FileType FileType { get; set; }

	[Option('f', "filter", Required = false, Default = FilterType.Nearest, HelpText = "Resizing filtering alghoritm. Possible values: [NEAREST], BILINEAR, BICUBIC.")]
	public FilterType FilterType { get; set; }

	[Option('a', "axis", Required = false, Default = ScaleAxis.Width, HelpText = "Axis by which to scale the image. Possible values [width], height.")]
	public ScaleAxis ScaleAxis { get; set; }

}