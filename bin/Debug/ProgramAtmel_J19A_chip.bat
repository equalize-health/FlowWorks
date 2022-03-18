REM Set the boot protection fuses to "allow bootloader programming" (unprotect addresses 0 - 0x3fff)
REM .\atprogram.exe  -t atmelice -i SWD -d atsamd51j19a write --fuses -o 0x0804000 --values 38969afe
REM Program the application and the bootloader in one .hex file
.\atprogram.exe  -t atmelice -i SWD -d atsamd51j19a program -c -f "FlowLiteATSAMD51J19A.hex"
REM Set the boot protection fuses to "protect first 16kBytes" to protect the bootloader (protect addresses 0 - 0x3fff) for production builds
REM .\atprogram.exe  -t atmelice -i SWD -d atsamd51j19a write --fuses -o 0x0804000 --values 38969af6
pause
