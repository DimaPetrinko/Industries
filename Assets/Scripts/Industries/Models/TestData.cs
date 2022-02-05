using Core.Models;

namespace Industries.Models
{
	public interface ITestData : IData
	{
		public string TestString { get; }
	}
	public sealed class TestData : ITestData
	{
		public string TestString => "Hello world";
	}
}