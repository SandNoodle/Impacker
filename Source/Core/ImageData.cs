using SixLabors.ImageSharp;

namespace Impacker.Core
{
	public record ImageData
	{
		public string Name { get; init; } 
		public Image Image { get; init; }
	}
}