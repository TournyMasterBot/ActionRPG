#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Server/ActionRpg.Server.Grpc/ActionRpg.Server.Grpc.csproj", "Server/ActionRpg.Server.Grpc/"]
COPY ["Core/ActionRpg.Models/ActionRpg.Models.csproj", "Core/ActionRpg.Models/"]
COPY ["Core/ActionRpg.Core/ActionRpg.Core.csproj", "Core/ActionRpg.Core/"]
COPY ["Server/ActionRpg.Server.GameModels/ActionRpg.Server.GameModels.csproj", "Server/ActionRpg.Server.GameModels/"]
RUN dotnet restore "Server/ActionRpg.Server.Grpc/ActionRpg.Server.Grpc.csproj"
COPY . .
WORKDIR "/src/Server/ActionRpg.Server.Grpc"
RUN dotnet build "ActionRpg.Server.Grpc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ActionRpg.Server.Grpc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ActionRpg.Server.Grpc.dll"]