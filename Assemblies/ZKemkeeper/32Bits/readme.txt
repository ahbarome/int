Copy all sdk *.dll files to %windir%\system32 folder , and then run cmd.exe ,enter the following command:

    regsvr32.exe %windir%\system32\zkemkeeper.dll
 

If you want to unregister sdk , run cmd.exe ,enter the following command:

    regsvr32.exe -u %windir%\system32\zkemkeeper.dll