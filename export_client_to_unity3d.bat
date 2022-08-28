rem Copies the ActionRpg game client to Unity3d project folder
call build.bat
call publish.bat
copy /y "%CD%\Client\ActionRpg.Client.GameClient\bin\Release\netstandard2.1\publish\ActionRpg.Client.GameClient.dll" "%CD%\Game\ActionRpg\Assets\ActionRpgAssets\Plugins\ActionRpgClient\ActionRpg.Client.GameClient.dll"