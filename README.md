# VS2005

Please install the following softwares first:
* Install nunit 2.7.1 https://github.com/nunit-legacy/nunitv2/releases/download/2.7.1/NUnit-2.7.1.msi
	* After installation, please add `C:\Program Files (x86)\NUnit 2.7.1\bin` to PATH

Then open the `csharp-otp.sln` in VS2005 and build the solution.

To run the test:
```powershell
nunit-console.exe /framework=v2.0 .\unit-test\bin\Debug\unit-test.dll
```


