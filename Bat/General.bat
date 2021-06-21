@echo off
:switch-case
cls
echo 0:  Thay doi IP
echo 1:  Cau hinh tat may tinh trong mang LAN
echo 2:  Tat tat ca cac may trong mang LAN
echo 3:  Khoi dong lai tat ca cac may trong mang LAN
echo 4:  Chan Control Panel va Settings
echo 5:  Liet ke service
echo 6:  Hoc tap
echo 7:  Star Wars
echo 8:  Liet ke cac tai khoan
echo 9:  Hien thi cac ket noi
echo 10: Tao thong bao windows
echo 11: hien thi ten may tinh, nguoi dung va workgroup
echo 12: chan nguoi dung Janet su dung may tinh trong khoang thoi gian tu 9 gio sang den 6 gio toi trong tuan va 10 gio sang den 9 gio toi vao ngay cuoi tuan
echo 13: liet ke cay thu muc
echo 14: hien thi taskmanager

set /P N= Chon chuc nang: 
goto :switch-case-N-%N% 2>nul || (
	echo BYE!
	pause
	)
	goto :switch-case

	:switch-case-N-0
		ECHO 0: Thanh Pho
		ECHO 1: Mang noi bo

		::/p cho biet gia tri nhan vao duoc nhap tu ban phim
		::/a cho biet gia tri nhan vao la 1 bieu thuc
		set /p Choose=Chon mang: 
		IF %Choose% == 0 (
			netsh interface ipv4 set address name="Ethernet" source=dhcp
			PAUSE
		)
		set /p Input=Nhap IP: 
		NETSH interface ipv4 set address name="Ethernet" static %Input% 255.255.255.0 192.168.1.98
		pause
		goto :switch-case

	:switch-case-N-1
		::them key reg shutdown trong mang lan
		reg add HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System /v LocalAccountTokenFilterPolicy /t REG_DWORD /d 1
		::chay service 
		powershell -command "Set-Service -Name 'RemoteRegistry' -Status running -StartupType automatic"
		pause
		goto :switch-case

	:switch-case-N-2
		shutdown /m \\192.168.1.128 /s /f /t 60
		pause
		goto :switch-case

	:switch-case-N-3
		shutdown /m \\192.168.1.128 /r /f /t 60
		pause
		goto :switch-case

	:switch-case-N-4
		::chan control panel
		reg add HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer /v NoControlPanel /t REG_DWORD /d 1
		pause
		goto :switch-case

	:switch-case-N-5
		powershell -command "Get-Service"
		pause
		goto :switch-case

	:switch-case-N-6
		echo Six
		pause
		goto :switch-case

	:switch-case-N-7
		telnet towel.blinkenlights.nl
		pause
		goto :switch-case

	:switch-case-N-8
		net user
		pause
		goto :switch-case

	:switch-case-N-9
		netstat
		pause
		goto :switch-case

	:switch-case-N-10
		PowerShell -Command "Add-Type -AssemblyName PresentationFramework;[System.Windows.MessageBox]::Show('Would  you like to play a game?','Game input','YesNoCancel','Error')"
		pause
		goto :switch-case

	:switch-case-N-11
		net config workstation
		pause
		goto :switch-case

	:switch-case-N-12
		net user Janet /times:M-F,09-18;Sa-Su,10-21
		pause
		goto :switch-case

	:switch-case-N-13
		tree /a /f > file.txt
		pause
		goto :switch-case

	:switch-case-N-14
		tasklist > tasklist.txt
		pause
		goto :switch-case

	pause
	goto :switch-case

:END
pause

::robocopy C:\Users\PC\Downloads \\192.168.1.128\d /S /E /Z /ZB /R:5 /W:5 /TBD /NP /V /MT:128
::arp -a
::netsh wlan show profile GW040_84EEC1 key=clear


:: sendkey powershell
::$wsh = New-Object -ComObject WScript.Shell
::$wsh.SendKeys('0')

::$wshell = New-Object -ComObject wscript.shell
::Sleep 1
::Add-Type -AssemblyName System.Windows.Forms
::[System.Windows.Forms.SendKeys]::SendWait('^{ESC}');