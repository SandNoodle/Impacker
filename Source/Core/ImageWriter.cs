using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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

		private static ReadOnlyDictionary<FileType, IImageEncoder> _availableEncoders = new ReadOnlyDictionary<FileType, IImageEncoder>
		(
			new Dictionary<FileType, IImageEncoder>()
			{
				{ FileType.Png, new PngEncoder() },
				{ FileType.Jpg, new JpegEncoder() },
				{ FileType.Tga, new TgaEncoder() },
				{ FileType.Bmp, new BmpEncoder() },
			}
		);

		public static void Save(List<ImageData> outputImages, CommandLineOptions options)
		{
			if (outputImages == null) { throw new ArgumentNullException(); }
			if (options == null) { throw new ArgumentNullException(); }
			if (outputImages.Count == 0) { throw new ArgumentException("Provided ImageData List cannot be empty!"); }

			var isHorizontalAxis = options.ScaleAxis == ScaleAxis.Width;
			var baseOutputDirectory = options.OutputDirectory;
			var fileType = options.FileType;
			var encoder = GetEncoder(fileType);

			for (int i = 0; i < outputImages.Count; i++)
			{
				var currentImage = outputImages[i];
				var currentSize = isHorizontalAxis ? currentImage.Image.Width : currentImage.Image.Height;
				var baseName = currentImage.Name;
				var outputName = ConstructImageName(baseName, fileType, currentSize);
				var outputDirectory = ConstructOutputDirectory(baseOutputDirectory, currentSize);
				var savePath = Path.Combine(outputDirectory, outputName);

				currentImage.Image.Save(savePath, encoder);
			}
		}

		private static string ConstructImageName(string name, FileType extension, int size)
		{
			return $"T_{name}_{size}px.{extension.ToString().ToLowerInvariant()}";
		}

		private static string ConstructOutputDirectory(string baseOutputDirectory, int currentSize)
		{
			return Path.Combine(baseOutputDirectory, currentSize.ToString());
		}

		private static IImageEncoder GetEncoder(FileType encoderType)
		{
			IImageEncoder encoder;
			if (_availableEncoders.TryGetValue(encoderType, out encoder))
			{
				return encoder;
			}

			return new PngEncoder();
		}
	}
}