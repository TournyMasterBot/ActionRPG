rem ActionRpg is actively developed against 2022.1.12f1
echo ## Creating directory if required ##
@if not exist "%CD%\Game\Assets\Plugins\" (
	md  "%CD%\Game\ActionRpg\Assets\Plugins\"
)
@if not exist "%CD%\Game\Assets\Protos\" (
	md  "%CD%\Game\ActionRpg\Assets\Protos\"
)
echo ## Executing Protos Script ##
powershell.exe -file "generate_proto_files.ps1"
echo ## Executing Publish Script ##
call publish.bat
echo ## Copying output files ##
xcopy /s "%CD%\UnityBinaries\*.*" "%CD%\Game\ActionRpg\Assets\Plugins\" /y /E