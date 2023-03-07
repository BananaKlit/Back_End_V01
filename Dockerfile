# Start with the official .NET SDK image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

WORKDIR /app


# Copy the solution file and restore dependencies
COPY *.sln .
COPY ./Back_End_V0.1.Api/*.csproj ./Back_End_V0.1.Api/
COPY ./Back_End_V0.1.DAL/*.csproj ./Back_End_V0.1.DAL/
COPY ./Back_End_V0.1.Domain/*.csproj ./Back_End_V0.1.Domain/
RUN dotnet restore
# Set the working directory

# Copy the rest of the source code and build the application
COPY . ./
RUN dotnet publish -c Release -o out

# Start with the official .NET runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0


# Copy the built application from the build image
COPY --from=build-env /app/out .

# Start the application
ENTRYPOINT ["dotnet", "BackEnd.Api.dll"]
