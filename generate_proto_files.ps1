# To exceute on windows, open powershell in your protogen folder and use the command 
# `./generate_proto_files.ps1`

# Fetch all proto files frop the gen path and output them to the server location and game asset folder
$dir = "./Server/ProtosGen/" # This is the path to your grpc_csharp_plugin.exe and protos file definitions
$files = Get-ChildItem -Path $dir -File '*.proto' | Select-Object Name
$serverProtosPath = "./Server/ActionRpg.Server.Grpc/Protos" # This is the ActionRpg server folder path
$gameProtosPath = "./Game/ActionRpg/Assets/Protos" # This is the Unity3D game for ActionRpg
$gameClientProtosPath = "./Client/ActionRpg.Client.GameClient/Protos" # This is the test game client for ActionRpg

New-Item -ItemType Directory -Force -Path $serverProtosPath
New-Item -ItemType Directory -Force -Path $gameProtosPath
New-Item -ItemType Directory -Force -Path $gameClientProtosPath

# Game
foreach ($file in $files) {
	# Delete proto if it already exists
	$delpath = $gameProtosPath + $file.Name
	if (Test-Path $delpath) {
		Remove-Item -Path -Force $delpath
	}
	
	# Write the new proto
    $gameGen = "./Server/ProtosGen/protoc.exe -I $dir --csharp_out=$gameProtosPath --grpc_out=$gameProtosPath --plugin=protoc-gen-grpc=$dir/grpc_csharp_plugin.exe " +$file.Name
    Invoke-Expression $gameGen
}

# Server
foreach($file in $files) {
	# Delete proto if it already exists
	$delpath = $gameProtosPath + $file.Name
	if (Test-Path $delpath) {
		Remove-Item -Path -Force $delpath
	}
	
	# Write the new proto
    $serverGen = "./Server/ProtosGen/protoc.exe -I $dir --csharp_out=$serverProtosPath --grpc_out=$serverProtosPath --plugin=protoc-gen-grpc=$dir/grpc_csharp_plugin.exe " + $file.Name
    Invoke-Expression $serverGen
}

# Game Client
foreach ($file in $files) {
	# Delete proto if it already exists
	$delpath = $gameClientProtosPath + $file.Name
	if (Test-Path $delpath) {
		Remove-Item -Path -Force $delpath
	}
	
	# Write the new proto
    $clientGen = "./Server/ProtosGen/protoc.exe -I $dir --csharp_out=$gameClientProtosPath --grpc_out=$gameClientProtosPath --plugin=protoc-gen-grpc=$dir/grpc_csharp_plugin.exe " +$file.Name
    Invoke-Expression $clientGen
}