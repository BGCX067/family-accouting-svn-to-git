using System.Reflection;
using System.Runtime.InteropServices;
$if$ ($GlobalAssemblyInfoFilePath$ ==)
using System.Runtime.CompilerServices;
$endif$

$if$ ($DefaultNamespace$ ==)
[assembly: AssemblyTitle("$projectname$")]
[assembly: AssemblyProduct("$projectname$")]
$else$
[assembly: AssemblyTitle("$DefaultNamespace$")]
[assembly: AssemblyProduct("$DefaultNamespace$")]
$endif$
[assembly: AssemblyDescription("")]
[assembly: Guid("$guid1$")]

$if$ ($GlobalAssemblyInfoFilePath$ ==)
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("$registeredorganization$")]
[assembly: AssemblyCopyright("Copyright © $registeredorganization$ $year$")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
$endif$
