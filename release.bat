@echo off
SET /P RMODE=Are you using a 64bit system (y/n)?
if /i {%RMODE%}=={y} (goto :sf)
if /i {%RMODE%}=={n} (goto :tt)
exit

:sf
Obfuscar.exe obfuscar.xml
del "GifStudio\bin\x86\Release\Confused\Mapping.txt"
goto :runnable

:tt
Obfuscar.exe obfuscarx86.xml
del "GifStudio\bin\Release\Confused\Mapping.txt"
goto :runnable

:runnable
SET /P RMODE=Would you like to run the project (y/n)?
if /i {%RMODE%}=={y} (goto :run)
if /i {%RMODE%}=={n} (exit)

:run
"GifStudio\bin\x86\Release\Confused\studio.exe"