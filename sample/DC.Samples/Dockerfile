FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["sample/DC.Samples/DC.Samples.csproj", "sample/DC.Samples/"]
RUN dotnet restore "sample/DC.Samples/DC.Samples.csproj"
COPY . .
WORKDIR "/src/sample/DC.Samples"
RUN dotnet build "DC.Samples.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DC.Samples.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DC.Samples.dll"]