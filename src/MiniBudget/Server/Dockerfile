#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MiniBudget/Server/MiniBudget.Server.csproj", "MiniBudget/Server/"]
COPY ["MiniBudget/Shared/MiniBudget.Shared.csproj", "MiniBudget/Shared/"]
COPY ["MiniBudget/Client/MiniBudget.Client.csproj", "MiniBudget/Client/"]
RUN dotnet restore "MiniBudget/Server/MiniBudget.Server.csproj"
COPY . .
WORKDIR "/src/MiniBudget/Server"
RUN dotnet build "MiniBudget.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MiniBudget.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MiniBudget.Server.dll"]