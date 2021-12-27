using System;

namespace Impacker.Core
{
	public struct ImageSettings
		{
			public ImageSettings(Int32 width, Int32 height)
			{
				Width = width;
				Height = height;
			}
		
			public Int32 Width { get; }
			public Int32 Height { get; }
		}
}
	