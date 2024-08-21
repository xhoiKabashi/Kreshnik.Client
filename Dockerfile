# Use the official .NET 8.0 SDK image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Use the SDK image to build and publish the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Kreshnik.Client/BlazorDex.csproj", "Kreshnik.Client/"]
RUN dotnet restore "Kreshnik.Client/BlazorDex.csproj"
COPY . .
WORKDIR "/src/Kreshnik.Client"
RUN dotnet publish "BlazorDex.csproj" -c Release -o /app/publish

# Copy the app to the base image and set the entry point
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "BlazorDex.dll"]
