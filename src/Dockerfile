FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Octo.Demo.Api/Octo.Demo.Api.csproj", "Octo.Demo.Api/"]
COPY ["Octo.Demo.Api.Tests/Octo.Demo.Api.Tests.csproj", "Octo.Demo.Api.Tests/"]

RUN dotnet restore "Octo.Demo.Api/Octo.Demo.Api.csproj"
RUN dotnet restore "Octo.Demo.Api.Tests/Octo.Demo.Api.Tests.csproj"

COPY . .

RUN dotnet build "Octo.Demo.sln" -c Release -o /app/build
RUN dotnet test "Octo.Demo.Api.Tests/Octo.Demo.Api.Tests.csproj" -c Release --logger "trx;LogFileName=test_results.trx"

FROM build AS publish
RUN dotnet publish "Octo.Demo.Api/Octo.Demo.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Octo.Demo.Api.dll"]