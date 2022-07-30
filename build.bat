dotnet restore "ActionRPG.sln"
dotnet build --configuration Release --no-restore "ActionRPG.sln"
dotnet test --no-restore --verbosity normal "ActionRPG.sln"