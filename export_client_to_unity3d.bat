rem Execute Build Script
call build.bat
rem Execute Publish Script 
call publish.bat
rem Copy files to client location
copy /y "%CD%\Client\ActionRpg.Client.GameClient\bin\Release\netstandard2.1\publish\ActionRpg.Client.GameClient.dll" "%CD%\Game\ActionRpg\Assets\ActionRpgAssets\Plugins\ActionRpgClient\ActionRpg.Client.GameClient.dll"