@echo off
echo Deploying...
xcopy /Y ".\AdminTool\bin\Release GIT\AdminTool.exe" ".\Release\AdminTool.exe"
xcopy /Y ".\Database\bin\Release GIT\Database.dll" ".\Release\Database.dll"
xcopy /Y ".\Types\bin\Release GIT\Types.dll" ".\Release\Types.dll"
cd .\Release
del /Q Release.rar
echo Removed old Archive
"C:\Program Files\WinRAR\rar.exe" a -r Release.rar *.*
echo Deploy finished!
pause