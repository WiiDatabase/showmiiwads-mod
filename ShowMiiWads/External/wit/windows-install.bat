@echo off
if not exist bash.exe cd bin
bash.exe ./windows-install.sh --cygwin
pause
