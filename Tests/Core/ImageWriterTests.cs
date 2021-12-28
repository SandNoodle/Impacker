using System;
using System.Collections.Generic;
using Xunit;

using Impacker.Core;

namespace ImpackerTest.Core
{
	public class ImageWriterTests
	{

		[Fact]
		public void Save_Should_Throw_On_No_ImageData_Provided()
		{
			CommandLineOptions commandLineOptions = new CommandLineOptions();
			Assert.Throws<ArgumentNullException>(() => ImageWriter.Save(null, commandLineOptions));
		}

		[Fact]
		public void Save_Should_Throw_On_No_CommandLineOptions_Provided()
		{
			List<ImageData> imageList = new List<ImageData>();
			Assert.Throws<ArgumentNullException>(() => ImageWriter.Save(imageList, null));
		}

		[Fact]
		public void Save_Should_Throw_On_Empty_ImageData_List_Provided()
		{
			List<ImageData> imageList = new List<ImageData>();
			CommandLineOptions commandLineOptions = new CommandLineOptions();
			Assert.Throws<ArgumentException>(() => ImageWriter.Save(imageList, commandLineOptions));			
		}
	}
}