using SixLabors.ImageSharp;

namespace Impacker.Core
{
	public struct ImageData
	{
		public ImageData(string name, Image image)
		{
			Name = name;
			Image = image;
		}

		public string Name { get; } 
		public Image Image { get; }
	}
}