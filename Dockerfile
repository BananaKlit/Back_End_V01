# Start with the official .NET SDK image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

# Install the .NET SDK
RUN apt-get update \
    && apt-get install -y --no-install-recommends \
        curl \
        gnupg \
    && curl -fsSL https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor > microsoft.asc.gpg \
    && mv microsoft.asc.gpg /etc/apt/trusted.gpg.d/ \
    && curl -fsSL https://packages.microsoft.com/config/debian/11/prod.list > /etc/apt/sources.list.d/microsoft-prod.list \
    && apt-get update \
    && apt-get install -y --no-install-recommends \
        dotnet-sdk-6.0

WORKDIR /app

# Copy the solution file and restore dependencies
COPY *.sln .
COPY ./Back_End_V0.1.Api/*.csproj ./Back_End_V0.1.Api/
COPY ./Back_End_V0.1.DAL/*.csproj ./Back_End_V0.1.DAL/
COPY ./Back_End_V0.1.Domain/*.csproj ./Back_End_V0.1.Domain/
RUN dotnet restore

# Copy the rest of the source code and build the application
COPY . ./
RUN dotnet publish -c Release -o out

# Start with the official .NET runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0

# Copy the built application from the build image
COPY --from=build-env /app/out .

# Start the application
ENTRYPOINT ["dotnet", "BackEndMinimalApiVersion0.1.dll"]
