using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Processing.Processors.Transforms;

namespace Impacker.Core
{
	public class ImageCreator : IDisposable
	{

		public static readonly ReadOnlyDictionary<string, IResampler> _AvailableResamplers = new ReadOnlyDictionary<string, IResampler>
		(
			new Dictionary<string, IResampler>()
			{
				{ "nearest", KnownResamplers.NearestNeighbor },
				{ "bilinear", KnownResamplers.Triangle },
				{ "bicubic", KnownResamplers.Bicubic },
			}
		);

		private List<ImageData> _storedImageData = new List<ImageData>();

		/// <summary>
		/// Disposes image data from memory.
		/// Due to ImageSharp's data storing mechanism, freeing of allocated memory is required.
		/// </summary>
		public void Dispose()
		{
			_storedImageData.ForEach(data => data.Image.Dispose());
			_storedImageData.Clear();
			GC.SuppressFinalize(this);
		}

		public List<ImageData> CreateImages(ImageData imageData, string filterType, IEnumerable<Int32> imageSizes)
		{
			var outputList = new List<ImageData>();
			imageSizes.ToList()
					.ForEach(outputSize => outputList
					.Add(
					new ImageData
					{
						Name = imageData.Name,
						Image = CreateImage(imageData.Image, outputSize, filterType)
					}));
			
			return outputList;
		}

		public Image CreateImage(Image inputImage, int size, string filterType)
		{
			var resampler = GetResampler(filterType);
			return inputImage.Clone(i => i.Resize(size, size, resampler));
		}

		private static IResampler GetResampler(string resamplerType)
		{
			IResampler resampler;
			if (ImageCreator._AvailableResamplers.TryGetValue(resamplerType.ToLowerInvariant(), out resampler))
			{
				return resampler;
			}

			return KnownResamplers.NearestNeighbor;
		}

	}
}
