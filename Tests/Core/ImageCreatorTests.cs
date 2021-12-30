using System;
using System.Linq;
using Xunit;

using Impacker.Core;

using SixLabors.ImageSharp;

namespace ImpackerTest.Core
{
	public class ImageCreatorTests : IDisposable
	{

		private CommandLineOptions _defaultCommandLineOptions;
		private ImageCreator _imageCreator;

		private readonly string _testSquareImagePath = "../../../../Resources/TestTexture_Diffuse.jpg";
		private readonly string _testNonSquareImagePath = "../../../../Resources/TestTexture_NonSquare.jpg";

		private record ImageDimensions
		{
			public Int32 Width { get; init; }
			public Int32 Height { get; init; }

			public override string ToString() { return $"[{Width}, {Height}]"; }
		};

		public ImageCreatorTests()
		{
			_defaultCommandLineOptions = new CommandLineOptions();
			_defaultCommandLineOptions.FileType = "png";
			_defaultCommandLineOptions.FilterType = "nearest";
			_defaultCommandLineOptions.ScaleAxis = ScaleAxis.Width;
			_defaultCommandLineOptions.InputDirectory = ".";
			_defaultCommandLineOptions.OutputDirectory = "./out";
			_defaultCommandLineOptions.ImageSizes = new int[] { 128, 64, 48, 32, 16 };

			_imageCreator = new ImageCreator(_defaultCommandLineOptions);
		}

		public void Dispose()
		{
			_imageCreator.Dispose();
		}

		[Fact]
		public void CreateImage_Should_Create_SquareImage_Of_Incorrect_Size()
		{
			var inputImage = Image.Load(_testSquareImagePath);
			var createdImage = _imageCreator.CreateImage(inputImage, 48);

			var actualSize = createdImage.Width;
			var expectedSize = 32;

			Assert.NotEqual(expectedSize, actualSize);
		}

		[Fact]
		public void CreateImage_Should_Create_NonSquareImage_Of_Incorrect_Size()
		{
			var inputImage = Image.Load(_testNonSquareImagePath);
			var createdImage = _imageCreator.CreateImage(inputImage, 48);

			var actualSize = new ImageDimensions
			{
				Width = createdImage.Width,
				Height = createdImage.Height,
			};

			var expectedSize = new ImageDimensions
			{
				Width = 32,
				Height = 64,
			};

			Assert.NotEqual(expectedSize, actualSize);
		}

		[Fact]
		public void CreateImage_Should_Create_SquareImage_Of_Correct_Size()
		{
			var inputImage = Image.Load(_testSquareImagePath);
			var createdImage = _imageCreator.CreateImage(inputImage, 48);

			var actualSize = createdImage.Width;
			var expectedSize = 48;

			Assert.Equal(expectedSize, actualSize);
		}

		[Fact]
		public void CreateImage_Should_Create_NonSquareImage_Of_Crrect_Size()
		{
			var inputImage = Image.Load(_testNonSquareImagePath);
			var createdImage = _imageCreator.CreateImage(inputImage, 48);

			var actualSize = new ImageDimensions
			{
				Width = createdImage.Width,
				Height = createdImage.Height,
			};

			var expectedSize = new ImageDimensions
			{
				Width = 48,
				Height = 96,
			};

			Assert.Equal(expectedSize, actualSize);
		}

		[Fact]
		public void CreateImages_Should_Create_Incorrect_Amount_Of_Images()
		{
			var imageSizes = new int[] { 1, 1, 1, 1, 1, 1 };
			var inputImage = ImageReader.Load(_testSquareImagePath);
			var createdImages = _imageCreator.CreateImages(inputImage, imageSizes);

			var actualAmount = createdImages.Count;
			var expectedAmount = imageSizes.Length + 1;

			Assert.NotEqual(expectedAmount, actualAmount);
		}

		[Fact]
		public void CreateImages_Should_Create_Correct_Amount_Of_Images()
		{
			var imageSizes = new int[] { 1, 1, 1, 1, 1, 1 };

			var inputImage = ImageReader.Load(_testSquareImagePath);
			var createdImages = _imageCreator.CreateImages(inputImage, imageSizes);

			var actualAmount = createdImages.Count;
			var expectedAmount = imageSizes.Length;

			Assert.Equal(expectedAmount, actualAmount);
		}

		[Fact]
		public void CreateImages_Should_Create_SquareImages_Of_Incorrect_Sizes()
		{
			var imageSizes = new int[] { 128, 64, 48, 32, 16 };
			var inputImage = ImageReader.Load(_testSquareImagePath);
			var createdImages = _imageCreator.CreateImages(inputImage, imageSizes);

			var actualSizes = createdImages.Select(data => data.Image.Width).ToArray();
			var expectedSizes = new int[] { 256, 128, 64, 48, 32 };

			Assert.NotEqual(expectedSizes, actualSizes);
		}

		[Fact]
		public void CreateImages_Should_Create_NonSquareImages_Of_Incorrect_Sizes()
		{
			var imageSizes = new int[] { 128, 64, 48, 32, 16 };
			var inputImage = ImageReader.Load(_testNonSquareImagePath);
			var createdImages = _imageCreator.CreateImages(inputImage, imageSizes);

			var actualSizes = createdImages.Select(data =>
										new ImageDimensions
										{
											Width = data.Image.Width,
											Height = data.Image.Height
										})
										.ToArray();

			var expectedSizes = new ImageDimensions[] { new ImageDimensions {Width = 256, Height = 512},
														new ImageDimensions {Width = 128, Height = 256},
														new ImageDimensions {Width = 64, Height = 128},
														new ImageDimensions {Width = 48, Height = 96},
														new ImageDimensions {Width = 32, Height = 64},
														};

			Assert.NotEqual(expectedSizes, actualSizes);
		}

		[Fact]
		public void CreateImages_Should_Create_SquareImages_Of_Correct_Sizes()
		{
			var imageSizes = new int[] { 128, 64, 48, 32, 16 };
			var inputImage = ImageReader.Load(_testSquareImagePath);
			var createdImages = _imageCreator.CreateImages(inputImage, imageSizes);

			var actualSizes = createdImages.Select(data => data.Image.Width).ToArray();
			var expectedSizes = new int[] { 128, 64, 48, 32, 16 };

			Assert.Equal(expectedSizes, actualSizes);
		}

		[Fact]
		public void CreateImages_Should_Create_NonSquareImages_Of_Correct_Sizes()
		{
			var imageSizes = new int[] { 128, 64, 48, 32, 16 };
			var inputImage = ImageReader.Load(_testNonSquareImagePath);
			var createdImages = _imageCreator.CreateImages(inputImage, imageSizes);

			var actualSizes = createdImages.Select(data =>
										new ImageDimensions
										{
											Width = data.Image.Width,
											Height = data.Image.Height
										})
										.ToArray();

			var expectedSizes = new ImageDimensions[] { new ImageDimensions {Width = 128, Height = 256},
														new ImageDimensions {Width = 64, Height = 128},
														new ImageDimensions {Width = 48, Height = 96},
														new ImageDimensions {Width = 32, Height = 64},
														new ImageDimensions {Width = 16, Height = 32},
														};

			Assert.Equal(expectedSizes, actualSizes);
		}
	}
}
