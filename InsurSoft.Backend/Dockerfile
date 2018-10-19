FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 52321
EXPOSE 44394

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["InsurSoft.Backend/InsurSoft.Backend.csproj", "InsurSoft.Backend/"]
RUN dotnet restore "InsurSoft.Backend/InsurSoft.Backend.csproj"
COPY . .
WORKDIR "/src/InsurSoft.Backend"
RUN dotnet build "InsurSoft.Backend.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "InsurSoft.Backend.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "InsurSoft.Backend.dll"]