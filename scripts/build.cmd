@echo off
SETLOCAL

REM call scripts/check.cmd


dotnet clean
dotnet build
if not exist bin mkdir bin
copy BikeUtils\bin\Debug\net48\BikeUtils.dll bin\BikeUtils.dll
echo Copied all compiled DLLs into bin folder!
goto end

:invalid
echo Invalid configuration

:end
exit /b