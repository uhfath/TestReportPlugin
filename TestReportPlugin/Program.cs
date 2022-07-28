using System.Diagnostics;
using System.Reflection;

var assembly = Assembly.LoadFrom(@"Report\Report.dll");
var type = assembly.GetTypes()
	.Where(t => typeof(Contract.IReportContract).IsAssignableFrom(t))
	.Single();

var instance = (Contract.IReportContract)Activator.CreateInstance(type);
var report = instance.Generate();
File.WriteAllBytes("report_temp.pdf", report);

Process.Start(new ProcessStartInfo
{
	FileName = "report_temp.pdf",
	UseShellExecute = true,
});
