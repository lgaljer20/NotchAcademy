#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["cassiopeia-be/cassiopeia-be.csproj", "cassiopeia-be/"]
COPY ["cassiopeia-be.Business/cassiopeia-be.Business.csproj", "cassiopeia-be.Business/"]
COPY ["cassiopeia-be.Data/cassiopeia-be.Data.csproj", "cassiopeia-be.Data/"]
RUN dotnet restore "cassiopeia-be/cassiopeia-be.csproj"
COPY . .
WORKDIR "/src/cassiopeia-be"
RUN dotnet build "cassiopeia-be.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "cassiopeia-be.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "cassiopeia-be.dll"]