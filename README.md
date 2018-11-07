# dxShell
使用.net core运行一些小的辅助程序

----
## 使用备忘
### 按格式列出文件
dotnet run -- listfile -d "D:\Work\F3DSystem\x64\Debug" -p "*.obj" -f "123:{0}"

*注意运行dotnet run -- 参数后面要带一个空格，否则传递给程序的参数前面会有一个--*