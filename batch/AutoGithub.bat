ECHO OFF
:: Di chuyển đến thư mục chứa code của chúng ta
:: cd "C:xD"
:: cập nhật thư viện
python -m pip freeze --all > requirements.txt
:: Set các giá trị về file git exe và nhánh cần làm việc
set GIT_PATH="C:\Program Files\Git\bin\git.exe"
set BRANCH = "origin"
:: Tiến hành pull toàn bộ code về
%GIT_PATH% pull %BRANCH%
:: Tiến hành add toàn bộ file thay đổi
%GIT_PATH% add -A
:: Commit lên
%GIT_PATH% commit -am "Auto-committed on %time% - %date%"
:: Push lên
%GIT_PATH% push %BRANCH%