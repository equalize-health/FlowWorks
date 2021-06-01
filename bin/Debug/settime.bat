@echo off
set hour=%time:~0,2%
if "%hour:~0,1%" == " " set hour=0%hour:~1,1%
rem echo hour=%hour%
set min=%time:~3,2%
if "%min:~0,1%" == " " set min=0%min:~1,1%
rem echo min=%min%
set secs=%time:~6,2%
if "%secs:~0,1%" == " " set secs=0%secs:~1,1%
rem echo secs=%secs%
set day=%date:~7,2%
rem echo day=%day%
set month=%date:~4,2%
rem echo month=%month%
set year=%date:~-4%
rem echo year=%year%

