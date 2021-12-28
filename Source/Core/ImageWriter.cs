using System;
using System.IO;
using System.Collections.Generic;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Tga;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Formats.Bmp;
using SixLabors.ImageSharp.Formats.Jpeg;


namespace Impacker.Core
{
	public class ImageWriter
	{

		private static Dictionary<string, IImageEncoder> availableEncoders = new Dictionary<string, IImageEncoder>()
		{
			{ "png", new PngEncoder() },
			{ "jpg", new JpegEncoder() },
			{ "tga", new TgaEncoder() },
			{ "bmp", new BmpEncoder() },
		};

		public static void Save(List<ImageData> outputImages, CommandLineOptions options)
		{
			var baseOutputDirectory = options.OutputDirectory;
			var fileType = options.FileType;
			var encoder = GetEncoder(fileType);

			for(int i = 0; i < outputImages.Count; i++)
			{
				var currentSize = outputImages[i].Image.Width;
				var currentImage = outputImages[i];
				var baseName = outputImages[i].Name;
				var outputName = ConstructImageName(baseName, fileType, currentSize);
				var outputDirectory = ConstructOutputDirectory(baseOutputDirectory, currentSize);
				var savePath = Path.Combine(outputDirectory, outputName);

				currentImage.Image.Save(savePath, encoder);
			}
		}

		private static string ConstructImageName(string name, string extension, int size)
		{
			return $"T_{name}_{size}px.{extension}";
		}

		private static string ConstructOutputDirectory(string baseOutputDirectory, int currentSize)
		{
			return Path.Combine(baseOutputDirectory, currentSize.ToString());
		}

		private static IImageEncoder GetEncoder(string encoderType)
		{
			IImageEncoder encoder;
			if(availableEncoders.TryGetValue(encoderType.ToLowerInvariant(), out encoder))
			{
				return encoder;
			}

			return new PngEncoder();
		}
	}
}