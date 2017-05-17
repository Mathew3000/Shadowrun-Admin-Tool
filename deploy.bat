@echo off
echo Deploying...
xcopy /Y ".\AdminTool\bin\Release GIT\AdminTool.exe" ".\Release\AdminTool.exe"
xcopy /Y ".\Database\bin\Release GIT\Database.dll" ".\Release\Database.dll"
xcopy /Y ".\Types\bin\Release GIT\Types.dll" ".\Release\Types.dll"
echo Done!
pause