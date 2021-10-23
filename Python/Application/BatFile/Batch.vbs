Set WshShell = CreateObject("WScript.Shell") 
WshShell.Run chr(34) & "C:\Data\Routine\Batch.bat" & Chr(34), 0
Set WshShell = Nothing