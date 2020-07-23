FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY MeetupUI/src/*.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY MeetupUI/src ./
# -c == --configuration; the publish command does an implicit build in 'Release' configuration
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "meetupraffle.dll"]