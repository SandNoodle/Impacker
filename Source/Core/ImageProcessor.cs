using System;
using System.Linq;
using System.Collections.Generic;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace Impacker.Core
{
	public class ImageProcessor
	{
		public static List<ImageData> CreateImages(ImageData inputImage, IEnumerable<Int32> imageSizes)
		{
			var outputList = new List<ImageData>();
			imageSizes.ToList()
					.ForEach(size => outputList
					.Add(
					new ImageData(
						inputImage.Name,
						Create(inputImage.Image, new ImageSettings(size, size)
					))));

			return outputList;
		}

		public static Image Create(Image inputImage, ImageSettings settings)
		{
			// TODO: Ability to select resampler
			return inputImage.Clone(i => i.Resize(settings.Width, settings.Height, KnownResamplers.NearestNeighbor));
		}

		public static void DisposeImages(ref List<ImageData> imageDataList)
		{
			imageDataList.ForEach(data => data.Image.Dispose());
			imageDataList.Clear();
		}

	}
}
