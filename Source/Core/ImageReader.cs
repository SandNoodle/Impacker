using System.IO;
using System.Linq;
using System.Collections.Generic;

using SixLabors.ImageSharp;

namespace Impacker.Core
{
	public class ImageReader
	{
		private static readonly List<string> _allowedExtensions = new List<string> { "png", "jpg", "tga", "bmp" };

		public static ImageData Load(string file)
		{
			return new ImageData { 
				Name = Path.GetFileNameWithoutExtension(file), 
				Image = Image.Load(file)
			};
		}

		public static List<ImageData> LoadImages(string path)
		{
			var imagePaths = GetAllImages(path);
			var loadedImages = new List<ImageData>();

			imagePaths.ForEach(imagePath => loadedImages.Add(Load(imagePath)));

			return loadedImages;
		}

		public static List<string> GetAllImages(string directory)
		{
			return Directory.EnumerateFiles(directory, "*.*", SearchOption.TopDirectoryOnly)
									.Where(file => _allowedExtensions
									.Contains(Path
									.GetExtension(file)
									.TrimStart('.')
									.ToLowerInvariant()))
									.ToList();
		}

	}
}