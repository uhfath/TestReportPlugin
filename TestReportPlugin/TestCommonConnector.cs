namespace TestReportPlugin;

internal class TestCommonConnector : Common.ICommonConnector
{
	public string GetCommonData() =>
		"Hello from TestPlugin!";
}
