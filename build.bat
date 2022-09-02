echo ## Executing Build Script
dotnet restore "ActionRpg.sln"
dotnet build --configuration Debug --no-restore "ActionRpg.sln"
dotnet test --no-restore --verbosity normal "ActionRpg.sln"