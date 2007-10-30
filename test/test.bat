@echo off
pushd %~dp0
setlocal
for %%i in (Debug Release) do if exist ..\bin\%%i\jsonchk.exe set JSON_CHECKER_PATH=..\bin\%%i\jsonchk.exe
if "%JSON_CHECKER_PATH%"=="" goto notfound
for %%i in (*.json) do echo %%i && %JSON_CHECKER_PATH% "%%i"
goto exit
:notfound
echo JSON Checker executable not found. Did you forget to build?
goto exit
:exit
popd
