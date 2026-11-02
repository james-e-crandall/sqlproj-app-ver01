https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/applying?tabs=dotnet-core-cli


dotnet ef migrations script --idempotent --output artifacts/migrations.sql

-----------------------------------

dotnet ef migrations add 20260211a

dotnet ef migrations script


dotnet ef migrations script --idempotent --output ../Data-Tier/BlogLib/20260211a.sql

dotnet ef migrations script --output ../Data-Tier/BlogLib/20260211a.sql

dotnet ef migrations script --output ../Data-Tier/BlogLib/bundle.sql --idempotent




-----------------------------------

Restore complete (0.2s)
  Data-Tier net10.0 failed with 3 error(s) (0.7s)
    C:\Users\jcrandall\source\repos\sqlproj-app-ver01\Data-Tier\BlogLib\20260211a.sql(1,1): error SQL70501: DML statements cannot be modeled.
    C:\Users\jcrandall\source\repos\sqlproj-app-ver01\Data-Tier\BlogLib\20260211a.sql(1,1): error SQL71006: Only one statement is allowed per batch. A batch separator, such as 'GO', might be required between statements.
    C:\Users\jcrandall\.nuget\packages\msbuild.sdk.sqlproj\4.4.0\Sdk\Sdk.targets(260,5): error MSB3073: The command "dotnet "C:\Users\jcrandall\.nuget\packages\msbuild.sdk.sqlproj\4.4.0\Sdk\../tools/net10.0/DacpacTool.dll" build -o "obj\Debug\net10.0\Data-Tier.dacpac" -n "Data-Tier" -v "1.0.0" -sv Sql160 -i "obj\Debug\net10.0\Data-Tier.InputFiles.txt"    -dp IncludeCompositeObjects=true           -an  -aa "C:\Program Files\dotnet\sdk\10.0.202\Sdks\Microsoft.NET.Sdk\targets\..\analyzers\Microsoft.CodeAnalysis.CSharp.NetAnalyzers.dll" -aa "C:\Program Files\dotnet\sdk\10.0.202\Sdks\Microsoft.NET.Sdk\targets\..\analyzers\Microsoft.CodeAnalysis.NetAnalyzers.dll" -aa "C:\Users\jcrandall\.nuget\packages\erikej.dacfx.sqlserver.rules\5.1.2\analyzers\dotnet\cs\SqlServer.Rules.NetFx.dll" -aa "C:\Users\jcrandall\.nuget\packages\erikej.dacfx.sqlserver.rules\5.1.2\analyzers\dotnet\cs\SqlServer.Rules.dll" -aa "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\10.0.6\analyzers/dotnet/cs/Microsoft.Interop.ComInterfaceGenerator.dll" -aa "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\10.0.6\analyzers/dotnet/cs/Microsoft.Interop.JavaScript.JSImportGenerator.dll" -aa "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\10.0.6\analyzers/dotnet/cs/Microsoft.Interop.LibraryImportGenerator.dll" -aa "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\10.0.6\analyzers/dotnet/cs/Microsoft.Interop.SourceGeneration.dll" -aa "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\10.0.6\analyzers/dotnet/cs/System.Text.Json.SourceGeneration.dll" -aa "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\10.0.6\analyzers/dotnet/cs/System.Text.RegularExpressions.Generator.dll" -pg "45685A90-FF03-4105-A0F6-1197FD2BD1E9"" exited with code 1.
