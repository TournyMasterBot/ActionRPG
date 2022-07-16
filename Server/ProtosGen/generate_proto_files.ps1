# To exceute on windows, open powershell in your protogen folder and use the command 
# `./generate_proto_files.ps1`

# Fetch all proto files frop the gen path and output them to the server location and game asset folder
$dir = "./"
$files = Get-ChildItem $dir -File '*.proto' | Select-Object Name
$serverProtosPath = "../ActionRpg.Server.Grpc/Protos"
$gameProtosPath = "../../Game/Assets/Protos"

New-Item -ItemType Directory -Force -Path $serverProtosPath
New-Item -ItemType Directory -Force -Path $gameProtosPath

# Server
foreach($file in $files) {
	# Delete proto if it already exists
	$delpath = $gameProtosPath + $file.Name
	if (Test-Path $delpath) {
		Remove-Item -Path -Force $delpath
	}
	
	# Write the new proto
    $serverGen = "./protoc.exe -I . --csharp_out=$serverProtosPath --grpc_out=$serverProtosPath --plugin=protoc-gen-grpc=grpc_csharp_plugin.exe " + $file.Name
    Invoke-Expression $serverGen
}

# Game
foreach ($file in $files) {
	# Delete proto if it already exists
	$delpath = $gameProtosPath + $file.Name
	if (Test-Path $delpath) {
		Remove-Item -Path -Force $delpath
	}
	
	# Write the new proto
    $gameGen = "./protoc.exe -I . --csharp_out=$gameProtosPath --grpc_out=$gameProtosPath --plugin=protoc-gen-grpc=grpc_csharp_plugin.exe " +$file.Name
    Invoke-Expression $gameGen
}