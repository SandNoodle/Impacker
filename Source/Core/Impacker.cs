using System;
using System.IO;
using System.Linq;

using System.Collections.Generic;

namespace Impacker.Core
{
	public class Impacker
	{

		private CommandLineOptions _commandLineOptions;

		public Impacker(CommandLineOptions commandLineOptions) => _commandLineOptions = commandLineOptions;

		public void ProcessFiles()
		{
			var outputDirectory = _commandLineOptions.OutputDirectory;
			var imageSizes = _commandLineOptions.ImageSizes;
			CreateOutputDirectories(outputDirectory, imageSizes);

			var inputDirectory = _commandLineOptions.InputDirectory;
			var inputImageList = LoadImages(inputDirectory);

			for (int i = 0; i < inputImageList.Count; i++)
			{
				var imageData = inputImageList[i];
				var outputImageList = ImageProcessor.CreateImages(imageData, imageSizes);

				ImageWriter.Save(outputImageList, _commandLineOptions);
				ImageProcessor.DisposeImages(ref outputImageList);
			}

			ImageProcessor.DisposeImages(ref inputImageList);
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