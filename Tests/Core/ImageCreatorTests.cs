using System;
using System.Linq;
using Xunit;

using Impacker.Core;

using SixLabors.ImageSharp;

namespace ImpackerTest
{
	public class ImageCreatorTests : IDisposable
	{

		private ImageCreator _imageCreator;

		private readonly string _testImagePath = "../../../../Resources/TestTexture_Diffuse.jpg";

		public ImageCreatorTests()
		{
			_imageCreator = new ImageCreator();
		}

		public void Dispose()
		{
			_imageCreator.Dispose();
		}

		[Fact]
		public void Should_Create_Image_Of_Incorrect_Size()
		{
			var inputImage = Image.Load(_testImagePath);
			var createdImage = _imageCreator.CreateImage(inputImage, 48, "nearest");

			var actualSize = createdImage.Width;
			var expectedSize = 32;

			Assert.NotEqual(expectedSize, actualSize);
		}

		[Fact]
		public void Should_Create_Image_Of_Correct_Size()
		{
			var inputImage = Image.Load(_testImagePath);
			var createdImage = _imageCreator.CreateImage(inputImage, 48, "nearest");

			var actualSize = createdImage.Width;
			var expectedSize = 48;

			Assert.Equal(expectedSize, actualSize);
		}


		[Fact]
		public void Should_Create_Incorrect_Amount_Of_Images()
		{
			var imageSizes = new int[] { 1, 1, 1, 1, 1, 1 };
			var inputImage = ImageReader.Load(_testImagePath);
			var createdImages = _imageCreator.CreateImages(inputImage, "nearest", imageSizes);

			var actualAmount = createdImages.Count;
			var expectedAmount = imageSizes.Length + 1;

			Assert.NotEqual(expectedAmount, actualAmount);
		}

		[Fact]
		public void Should_Create_Correct_Amount_Of_Images()
		{
			var imageSizes = new int[] { 1, 1, 1, 1, 1, 1 };

			var inputImage = ImageReader.Load(_testImagePath);
			var createdImages = _imageCreator.CreateImages(inputImage, "nearest", imageSizes);

			var actualAmount = createdImages.Count;
			var expectedAmount = imageSizes.Length;

			Assert.Equal(expectedAmount, actualAmount);
		}

		[Fact]
		public void Should_Create_Images_Of_Incorrect_Sizes()
		{
			var imageSizes = new int[] { 128, 64, 48, 32, 16 };
			var inputImage = ImageReader.Load(_testImagePath);
			var createdImages = _imageCreator.CreateImages(inputImage, "nearest", imageSizes);

			var actualSizes = createdImages.Select(data => data.Image.Width).ToArray();
			var expectedSizes = new int[] { 256, 128, 64, 48, 32 };

			Assert.NotEqual(expectedSizes, actualSizes);
		}

		[Fact]
		public void Should_Create_Images_Of_Correct_Sizes()
		{
			var imageSizes = new int[] { 128, 64, 48, 32, 16 };
			var inputImage = ImageReader.Load(_testImagePath);
			var createdImages = _imageCreator.CreateImages(inputImage, "nearest", imageSizes);

			var actualSizes = createdImages.Select(data => data.Image.Width).ToArray();
			var expectedSizes = new int[] { 128, 64, 48, 32, 16 };

			Assert.Equal(expectedSizes, actualSizes);
		}
	}
}
