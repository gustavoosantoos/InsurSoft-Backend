#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 53919
EXPOSE 44375

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["src/InsurSoft.Backend.Web.Api/InsurSoft.Backend.Web.Api.csproj", "src/InsurSoft.Backend.Web.Api/"]
RUN dotnet restore "src/InsurSoft.Backend.Web.Api/InsurSoft.Backend.Web.Api.csproj"
COPY . .
WORKDIR "/src/src/InsurSoft.Backend.Web.Api"
RUN dotnet build "InsurSoft.Backend.Web.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "InsurSoft.Backend.Web.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "InsurSoft.Backend.Web.Api.dll"]