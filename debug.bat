@echo off
dotnet build src/Skybrud.Essentials.Umbraco --configuration Debug /t:rebuild /t:pack -p:PackageOutputPath=c:\nuget\Umbraco10