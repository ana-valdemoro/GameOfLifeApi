FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY . ./ 
RUN dotnet restore ./GameOfLifeApi2.sln

#  build
RUN dotnet build ./GameOfLifeApi2.sln -c Release --no-restore

WORKDIR /app/API
RUN dotnet publish ./GameOfLifeApi2.csproj -c Docker -o out --no-restore

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env  /app/API/out  ./
ENTRYPOINT ["dotnet", "GameOfLifeApi2.dll"]