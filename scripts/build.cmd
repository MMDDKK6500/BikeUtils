@echo off
SETLOCAL

REM call scripts/check.cmd

if "%ARG%"=="" goto debug 

:build
dotnet clean -c %ARG%
dotnet build -c %ARG%
if not exist bin mkdir bin
REM copy BikeUtils\bin\Debug\net48\BikeUtils.dll bin\BikeUtils.dll
REM echo Copied all compiled DLLs into bin folder!
goto end

:debug
set ARG="debug"
goto build

:invalid
echo Invalid configuration

:end
exit /b