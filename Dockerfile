#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443


FROM mcr.microsoft.com/dotnet/sdk AS build
WORKDIR /src
COPY ["ToDoListApp/ToDoListApp.csproj", "ToDoListApp/"]
RUN dotnet restore "ToDoListApp/ToDoListApp.csproj"
COPY . .
WORKDIR "/src/ToDoListApp"
RUN dotnet build "ToDoListApp.csproj" -c Release -o /app/build



FROM build AS publish
RUN dotnet publish "ToDoListApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToDoListApp.dll"]