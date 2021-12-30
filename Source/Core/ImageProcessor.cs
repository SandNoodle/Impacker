using System;
using System.IO;
using System.Linq;

using System.Collections.Generic;

namespace Impacker.Core
{
	public class ImageProcessor
	{

		private CommandLineOptions _commandLineOptions;

		public ImageProcessor(CommandLineOptions commandLineOptions) => _commandLineOptions = commandLineOptions;

		public void Process()
		{
			// Create output direcotry
			var outputDirectory = _commandLineOptions.OutputDirectory;
			var imageSizes = _commandLineOptions.ImageSizes.ToArray();
			CreateOutputDirectories(outputDirectory, imageSizes);

			// Load input files (no recursion)
			var inputDirectory = _commandLineOptions.InputDirectory;
			var inputImageList = LoadImages(inputDirectory);

			// Create ouput images
			ImageCreator imageCreator = new ImageCreator(_commandLineOptions);
			for (int i = 0; i < inputImageList.Count; i++)
			{
				var imageData = inputImageList[i];
				var outputImageList = imageCreator.CreateImages(imageData, imageSizes);

				ImageWriter.Save(outputImageList, _commandLineOptions);
			}
		}

		private void CreateOutputDirectories(string baseOutputDirectory, IEnumerable<Int32> imageSizes)
		{
			imageSizes.ToList().ForEach(size => Directory
							.CreateDirectory(Path
							.Combine(baseOutputDirectory, size.ToString())));
		}

		private string CreateOutputImageName(string baseImageName, int imageSize)
		{
			return $"T_{baseImageName}_{imageSize}px";
		}

		private List<ImageData> LoadImages(string inputDirectory)
		{
			return ImageReader.LoadImages(inputDirectory);
		}
	}
}