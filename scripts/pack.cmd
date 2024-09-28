@echo off
SETLOCAL

dotnet clean -c release
dotnet pack

:exit
exit /b