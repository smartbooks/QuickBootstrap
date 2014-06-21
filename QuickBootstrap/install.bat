
echo off
set target=%USERPROFILE%\Documents\Visual Studio 2013\Templates\ProjectTemplates\Visual C#\Web
set targetFileName=QuickBootstrap.zip

mkdir "%target%"

copy /y %targetFileName% "%target%"\%targetFileName%

pause