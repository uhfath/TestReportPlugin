using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Reflection;
using TestReportPlugin;

var path = Path.GetFullPath(@"Report\Report.dll");
var context = new PluginLoadContext(path);
var assembly = context.LoadFromAssemblyPath(path);
var reportType = assembly
	.GetTypes()
	.Where(t => typeof(Contract.IReportContract).GetTypeInfo().IsAssignableFrom(t))
	.Single();

using var services = new ServiceCollection()
	.AddTransient<Common.ICommonConnector, TestCommonConnector>()
	.AddTransient<Common.CommonClass>()
	.AddTransient(typeof(Contract.IReportContract), reportType)
	.BuildServiceProvider()
;

services.GetRequiredService<Common.CommonClass>().TestClass();

var instance = services.GetRequiredService<Contract.IReportContract>();
var report = instance.Generate();
File.WriteAllBytes("report_temp.pdf", report);

Process.Start(new ProcessStartInfo
{
	FileName = "report_temp.pdf",
	UseShellExecute = true,
});
