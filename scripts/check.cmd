@echo off
SETLOCAL

REM part of codemanager

if not exist include\.git goto notfound

cd include
for /f "delims=" %%a in ('git status -s') do set "readValue=%%a"

if "%readValue%"=="" goto uptodate else goto update

:uptodate
echo Includes are up to date!
goto end

:update
git submodule update --recursive --remote
echo Includes updated!
goto end

:notfound
echo Include not found, going to pull it from github
git submodule update --init --recursive
echo Pulled includes from github, going to update them now!
goto update

:end
cd ..
exit /b