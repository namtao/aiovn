ECHO OFF
::disable control
reg add "HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer" /v NoControlPanel /t REG_DWORD /d 1 /f
::disable proxy
reg add "HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Internet Settings" /v ProxyEnable /t REG_DWORD /d 1 /f
reg add "HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Windows\CurrentVersion\Internet Settings" /v ProxySettingsPerUser /t REG_DWORD /d 1 /f
reg add "HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Internet Settings" /v ProxyServer /t REG_SZ /d 192.168.1.98 /f
reg add "HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Internet Settings" /v AutoDetect /t REG_DWORD /d 1 /f
::reg add "HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Internet Settings" /v ProxyOverride /t REG_SZ /d *theSysadminChannel.com; <local> /f
::netsh interface ipv4 set address name="Ethernet" source=dhcp
::cai dat tat may tinh
::reg add "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System" /v LocalAccountTokenFilterPolicy /t REG_DWORD /d 1
::powershell -command "Set-Service -Name 'RemoteRegistry' -Status running -StartupType automatic"
::copy file hosts
::COPY "\\192.168.1.202\New folder\hosts" "C:\Windows\System32\drivers\etc" /Y
::tat ipv6
powershell -Command "& {Disable-NetAdapterBinding -Name "*" -ComponentID ms_tcpip6}"
::static dns
netsh interface ipv4 set dns name="Ethernet" static 192.168.1.98
::netsh interface ipv4 set dns name="Ethernet" static 192.168.1.98 index = 2
::netsh interface ipv4 set dnsservers name"Ethernet" source=dhcp
::set /p Input=INPUT IP: 
::NETSH interface ipv4 set address name="Ethernet" static %Input% 255.255.255.0 192.168.1.98
::attrib +s +h "C:\Data\New Text Document.txt"
::attrib -s -h "C:\Data\New Text Document.txt"

::disable regedit
::reg add "HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System" /v DisableRegistryTools /t REG_DWORD /d 1 /f
::shutdown -s -t 30
::disable cmd
::reg add "HKEY_CURRENT_USER\Software\Policies\Microsoft\Windows" /v DisableCMD /t REG_DWORD /d 1 /f
::cmdkey /delete 192.168.1.98
::shutdown -s -t 30
pause