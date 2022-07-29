namespace Common;

public class CommonClass
{
	private readonly ICommonConnector _commonConnector;

	public CommonClass(
		ICommonConnector commonConnector)
	{
		this._commonConnector = commonConnector;
	}

	public void TestClass() =>
		Console.WriteLine(GetData());

	public string GetData() =>
		_commonConnector.GetCommonData();
}
