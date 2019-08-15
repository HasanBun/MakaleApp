#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-sac2016 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk-nanoserver-sac2016 AS build
WORKDIR /src
COPY ["MakaleApp.Api/MakaleApp.Api.csproj", "MakaleApp.Api/"]
RUN dotnet restore "MakaleApp.Api/MakaleApp.Api.csproj"
COPY . .
WORKDIR "/src/MakaleApp.Api"
RUN dotnet build "MakaleApp.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MakaleApp.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MakaleApp.Api.dll"]