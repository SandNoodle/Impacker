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

		public static readonly ReadOnlyDictionary<FilterType, IResampler> _AvailableResamplers = new ReadOnlyDictionary<FilterType, IResampler>
		(
			new Dictionary<FilterType, IResampler>()
			{
				{ FilterType.Nearest, KnownResamplers.NearestNeighbor },
				{ FilterType.Bilinear, KnownResamplers.Triangle },
				{ FilterType.Bicubic, KnownResamplers.Bicubic },
			}
		);

		private readonly CommandLineOptions _commandLineOptions;

		public ImageCreator(CommandLineOptions options) => _commandLineOptions = options;

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

		public List<ImageData> CreateImages(ImageData imageData, IEnumerable<Int32> imageSizes)
		{
			var outputList = new List<ImageData>();
			imageSizes.ToList()
					.ForEach(outputSize => outputList
					.Add(
					new ImageData
					{
						Name = imageData.Name,
						Image = CreateImage(imageData.Image, outputSize)
					}));

			return outputList;
		}

		public Image CreateImage(Image inputImage, int size)
		{
			var isHorizontalAxis = _commandLineOptions.ScaleAxis == ScaleAxis.Width;
			var resampler = GetResampler(_commandLineOptions.FilterType);
			var aspectRatio = isHorizontalAxis ? (inputImage.Height / inputImage.Width) : (inputImage.Width / inputImage.Height);
			var aspectCorrectedSize = GetAspectRatioCorrectedValue(size, aspectRatio);
			return inputImage.Clone(i => i
							.Resize(isHorizontalAxis ? size : aspectCorrectedSize,
								 	isHorizontalAxis ? aspectCorrectedSize : size,
									resampler));
		}

		private static IResampler GetResampler(FilterType resamplerType)
		{
			IResampler resampler;
			if (ImageCreator._AvailableResamplers.TryGetValue(resamplerType, out resampler))
			{
				return resampler;
			}

			return KnownResamplers.NearestNeighbor;
		}

		private Int32 GetAspectRatioCorrectedValue(int value, double aspectRatio)
		{
			return (Int32)Math.Round(value * aspectRatio);
		}

	}
}
