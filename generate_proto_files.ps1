# To exceute on windows, open powershell in your protogen folder and use the command 
# `./generate_proto_files.ps1`

# Fetch all proto files frop the gen path and output them to the server location and game asset folder
$basePath = Split-Path $MyInvocation.MyCommand.Path
echo "Base path: $basePath"
$dir = Convert-Path "$basePath/Server/ProtosGen" # This is the path to your grpc_csharp_plugin.exe and protos file definitions
echo "Protos path: $dir"
echo "Creating Generated Input Path"
New-Item -ItemType Directory -Force -Path "$dir/GeneratedInput"
$inputPath = Convert-Path "$dir/GeneratedInput/"
echo "Creating Generated Output Path"
New-Item -ItemType Directory -Force -Path "$dir/GeneratedOutput"
$outputPath = Convert-Path "$dir/GeneratedOutput/"
echo "Output Path: $outputPath"
$serverProtosPath = Convert-Path "$basePath/Server/ActionRpg.Server.Grpc/Protos" # This is the ActionRpg server folder path
echo "Sever Protos Path: $serverProtosPath"
$gameProtosPath = Convert-Path "$basePath/Game/ActionRpg/Assets/ActionRpgAssets/Protos" # This is the Unity3D game for ActionRpg
echo "Game Protos Path: $gameProtosPath"
$gameClientProtosPath = Convert-Path "$basePath/Client/ActionRpg.Client.GameClient/Protos" # This is the test game client for ActionRpg
echo "Game Client Protos Path: $gameClientProtosPath"

# Create output locations
echo "Creating Server Protos Path: $serverProtosPath"
New-Item -ItemType Directory -Force -Path $serverProtosPath
echo "Creating Game Protos Path: $gameProtosPath"
New-Item -ItemType Directory -Force -Path $gameProtosPath
echo "Creating Game Client Protos Path: $gameClientProtosPath"
New-Item -ItemType Directory -Force -Path $gameClientProtosPath

# Delete existing items
Remove-Item "$inputPath*.*"
Remove-Item "$outputPath*.*"
Remove-Item "$serverProtosPath*.*"
Remove-Item "$gameProtosPath*.*"
Remove-Item "$gameClientProtosPath*.*"

# Fetch source files
echo "Consolidating input files"
$inputFiles = Get-ChildItem -Path $dir -Recurse -File '*.proto'
foreach ($file in $inputFiles) {
	$filepath = $file.FullName
	$fileName = $file.Name
	echo "Copying to input path: $inputPath, file name: $fileName"
	$copyInputPath = $inputPath + $fileName
	Copy-Item -Path $filepath -Destination $copyInputPath 
}

# Create the protoc files at output location
echo "Generating output files"
$files = Get-ChildItem -Path $inputPath -Recurse -File '*.proto' | Select-Object Name
foreach ($file in $files) {	
	# Write the new proto
	$filePath = $file.FullName
	$fileName = $file.Name
	$protoGen = "$dir/protoc.exe -I $inputPath --csharp_out=$outputPath --grpc_out=$outputPath --plugin=protoc-gen-grpc=$dir/grpc_csharp_plugin.exe " + $file.Name
	echo "Protoc output: $outputPath$fileName"
	Invoke-Expression $protoGen
}

# Copy files to new locations
$outputFiles = Get-ChildItem -Path $outputPath -Recurse -File '*.cs'
foreach($file in $outputFiles) {
	$filePath = $file.FullName
	$fileName = $file.Name
	echo "Exporting file to $serverProtosPath$fileName"
	Copy-Item -Path $filepath -Destination $serverProtosPath
	echo "Exporting file to $gameProtosPath$fileName"
	Copy-Item -Path $filepath -Destination $gameProtosPath
	echo "Exporting file to $gameClientProtosPath$fileName"
	Copy-Item -Path $filepath -Destination $gameClientProtosPath
}