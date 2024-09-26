@echo off
SETLOCAL

echo Staging changes
git add -A
echo Commiting changes to local repo
git commit -m %ARG%
echo Pushing changes into remote repo(Github)
git push origin main
echo Done!

:exit
exit /b