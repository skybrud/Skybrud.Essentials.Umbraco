@echo off
dotnet build src/Skybrud.Essentials.Umbraco --configuration Release /t:rebuild /t:pack -p:PackageOutputPath=../../releases/nuget