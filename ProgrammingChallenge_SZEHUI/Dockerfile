# Use .NET SDK for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory inside the container
WORKDIR /app

# Copy the project file into the container and restore dependencies
COPY ../ChallengeB/ChallengeB.csproj .
RUN dotnet restore

# Copy the entire application source code and build it
COPY ../ChallengeB/. .
RUN dotnet publish -c Release -o /app/publish

# Define the runtime image
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS runtime

# Copy the compiled files from the build stage
COPY --from=build /app/publish .

# Copy the file from the same directory as the Dockerfile into the container
COPY RandomObjects.txt /app/RandomObjects.txt

# Run the application
ENTRYPOINT ["dotnet", "ChallengeB.dll"]