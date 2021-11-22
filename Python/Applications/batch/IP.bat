::reg add HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer /v NoControlPanel /t REG_DWORD /d 1

ECHO OFF
::powershell -Command "& {Disable-NetAdapterBinding -Name "*" -ComponentID ms_tcpip6}"
::regedit.exe /S security.reg
::reg import .\security.reg
::CMD se khong hien thi lenh nao duoc thu thi phia duoi.
::ECHO THAY DOI DIA CHI IP
::ECHO 0: Thanh Pho
::ECHO 1: Mang noi bo
:: In ra dong van ban
::IPCONFIG /ALL
::NETSH interface ipv4 show config
::netsh interface teredo set state disabled
::netsh interface ipv6 6to4 set state state=disabled undoonstop=disabled
::netsh interface ipv6 isatap set state state=disabled

::set /p Choose=Chon mang: 
::IF %Choose% == 0 (
::	netsh interface ipv4 set address name="Ethernet" source=dhcp
::	PAUSE
::	exit
::)
::set /p Input=INPUT IP: 
::NETSH interface ipv4 set address name="Ethernet" static %Input% 255.255.255.0 192.168.1.98
netsh interface ipv4 set address name="Ethernet" source=dhcp
PAUSE
:: Cho phep nguoi dung xem ket qua. Boi vi day la dong lenh cuoi cung nen sau khi nhan phim bat ky, cua so command se duoc dong lai.