Please install the following softwares first:
* Install nunit3-console https://github.com/nunit/nunit-console/releases/download/3.16.2/NUnit.Console-3.16.2.msi
	* After installation, please add `C:\Program Files (x86)\NUnit.org\nunit-console` to PATH

# VS2005

Open the `csharp-otp.sln` in VS2005 and build the solution.

To run the test:
```powershell
nunit3-console.exe --framework=net-2.0 ".\unit-test\bin\Debug\unit-test.dll"
```

# VS2019

Open the `csharp-otp-2019.sln` in VS2019 and build the solution.

You can run tests in VS2019 or run it powershell:
```powershell
nunit3-console.exe --framework=net-4.5.1 ".\NUnit.Tests\bin\Debug\NUnit.Tests.dll"
```
