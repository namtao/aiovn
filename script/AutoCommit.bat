ECHO OFF
:: Di chuyển đến thư mục chứa code của chúng ta
:: cd "C:xD"

:: cập nhật thư viện
cd ..

:: Set các giá trị về file git exe và nhánh cần làm việc
set GIT_PATH="C:\Program Files\Git\bin\git.exe"
set BRANCH = "origin"

:: Tiến hành pull toàn bộ code về
%GIT_PATH% pull %BRANCH%

:: Update library
.venv\Scripts\python.exe -m pip install -r requirements.txt
.venv\Scripts\python.exe -m pip freeze --all > requirements.txt

:: Tiến hành add toàn bộ file thay đổi
%GIT_PATH% add -A

:: Commit
%GIT_PATH% commit -am "Auto-committed on %time% - %date%"

:: Push
%GIT_PATH% push %BRANCH%