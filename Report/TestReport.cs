using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report
{
	internal class TestReport : Contract.IReportContract
	{
		public byte[] Generate()
		{
			using var report = new ReportForm();
			using var stream = new MemoryStream();
			report.ExportToPdf(stream);
			return stream.ToArray();
		}
	}
}
