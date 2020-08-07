FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY MeetupAPIService/src/*.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY MeetupAPIService/src ./
# -c == --configuration; the publish command does an implicit build in 'Release' configuration
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

ARG BUILD_DATE
ARG BUILD_VERSION

LABEL org.brkthroo.image.authors="nirajbhatt@outlook.com" \
      org.brkthroo.image.source="https://github.com/nirajrules" \
      org.brkthroo.image.created=$BUILD_DATE \
      org.brkthroo.image.title="nirajrules/meetupapiservice" \
      org.brkthroo.image.description="The repository contains meetupapi extensions " \
      org.brkthroo.image.source=$BUILD_VERSION

WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "MeetupAPIService.dll"]