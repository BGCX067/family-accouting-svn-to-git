@echo off
..\..\..\Tool\MSBuild\MSBuild.exe SylmarkConnectBuild.targets /nologo /target:%1 /fileLogger /fileLoggerParameters:LogFile=%1.log;Verbosity=diagnostic;Encoding=UTF-8 %~2
if not %errorlevel% == 0 pause