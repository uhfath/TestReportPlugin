namespace Report;

internal class TestReport : Contract.IReportContract
{
	private readonly Common.CommonClass _commonClass;

	public TestReport(
		Common.CommonClass commonClass)
	{
		this._commonClass = commonClass;
	}

	public byte[] Generate()
	{
		using var report = new ReportForm();
		report.Parameters["Message"].Value = _commonClass.GetData();

		using var stream = new MemoryStream();
		report.ExportToPdf(stream);
		return stream.ToArray();
	}
}
