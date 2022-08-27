FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["BackendTest.csproj", "./"]
RUN dotnet restore "BackendTest.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "BackendTest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BackendTest.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BackendTest.dll"]
