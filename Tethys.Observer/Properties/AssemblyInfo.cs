using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.Owin;
using Tethys.Observer.Hubs;

[assembly: AssemblyTitle("Tethys.Observer")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Tethys.Observer")]
[assembly: AssemblyCopyright("Copyright ©  2014")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
[assembly: Guid("5c314460-1a71-48ae-bd93-569b4a15439a")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: OwinStartup(typeof(StartUp))]