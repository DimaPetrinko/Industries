namespace Industries.Models
{
	public interface ITestData
	{
		public string TestString { get; }
	}
	public sealed class TestData : ITestData
	{
		public string TestString => "Hello world";
	}
}