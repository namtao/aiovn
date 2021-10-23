::tắt câu lệnh cmd
ECHO OFF
cd C:\Data\Routine
::tạo file mới nếu chưa có
if not exist %date:~0,2%.%date:~3,2%.%date:~6,4%.txt (
	type nul > %date:~0,2%.%date:~3,2%.%date:~6,4%.txt
	::copy text
	copy Form.txt %date:~0,2%.%date:~3,2%.%date:~6,4%.txt
)
::open file
%date:~0,2%.%date:~3,2%.%date:~6,4%.txt

::thoát
exit 0