@echo off
SETLOCAL

REM call scripts/check.cmd


dotnet clean
dotnet build
if not exist bin mkdir bin
copy Adrenaline\bin\Debug\net48\Adrenaline.dll bin\Adrenaline.dll
copy Push\bin\Debug\net48\Push.dll bin\Push.dll
echo Copied all plugin DLLs into bin folder!
goto end

:invalid
echo Invalid configuration

:end
exit /b