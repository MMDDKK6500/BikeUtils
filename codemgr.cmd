@echo off
REM This script was made by MMDDKK6500 for zDarkneSz Network for use with plugin source code management

if not exist "C:\Program Files\Git\cmd" goto nogit

if "%~1"=="" goto help

if "%~1"=="-h" goto help

if "%~1"=="build" goto build
if "%~1"=="clean" goto clean
if "%~1"=="commit" goto commit
if "%~1"=="pack" goto pack


:help
echo:
echo Hi! This script was made by MMDDKK6500 for use with plugin source code management
echo usage: codemanager [command] (arguments)
echo:
echo Commands available:
echo    build   Will run the build.cmd script(runs check.cmd)
echo    clean   Will run the dotnet clean command
echo    commit  Will stage, commit and push every change into github!
goto end

:build
REM if "%~2"=="" goto noargs
set ARG=%~2
call scripts/build.cmd
goto end

:clean
dotnet clean
goto end

:commit
if "%~2"=="" goto noargs
set ARG=%~2
call scripts/commit.cmd
goto end

:pack
call scripts/pack.cmd
goto end

:noargs
echo You seem to be missing an argument for the commit message, please add one by doing codemgr.cmd commit "<Insert comment here>" 
goto end

:nogit
echo It appears you don't have git installed, please install that first, then run this script!

:end
exit /b