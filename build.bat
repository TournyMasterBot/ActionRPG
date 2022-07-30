REM This build bat is to help out codeql
docker pull mcr.microsoft.com/dotnet/sdk:6.0
dotnet build "./ActionRpg.sln"