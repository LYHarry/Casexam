@echo off

setlocal

if exist install.bat goto ok
echo install.bat must be run from its folder
goto end

:ok

set OLDGOPATH=%GOPATH%
set GOPATH=%cd%

REM echo "~dp0: " %~dp0
REM echo "cd: " %cd%

gofmt -w src

go install main

set GOPATH=OLDGOPATH

:end
echo finished

pause