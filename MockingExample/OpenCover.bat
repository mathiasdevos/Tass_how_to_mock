packages\OpenCover.4.5.1923\OpenCover.Console.exe ^
-targetdir:"MockingExample\bin\Debug" ^
-target:"..\..\..\packages\NUnit.Runners.2.6.3\tools\nunit.exe" ^
-targetargs:"..\..\..\Tests\bin\Debug\Tests.dll" ^
-output:"coverageReport\coverage.xml" ^
-register:user 