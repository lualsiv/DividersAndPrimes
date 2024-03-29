#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.


FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DividersAndPrimes.WebApi/DividersAndPrimes.WebApi.csproj", "DividersAndPrimes.WebApi/"]
COPY ["DividersAndPrimes.Application/DividersAndPrimes.Application.csproj", "DividersAndPrimes.Application/"]
COPY ["DividersAndPrimes.Domain/DividersAndPrimes.Domain.csproj", "DividersAndPrimes.Domain/"]
RUN dotnet restore "DividersAndPrimes.WebApi/DividersAndPrimes.WebApi.csproj"
COPY . .
WORKDIR "/src/DividersAndPrimes.WebApi"
RUN dotnet build "DividersAndPrimes.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DividersAndPrimes.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DividersAndPrimes.WebApi.dll"]
