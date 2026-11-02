  <Target Name="CheckCentralPackageManagement" BeforeTargets="Restore">
    <Error Condition="'$(ManagePackageVersionsCentrally)' == 'true' and '@(PackageReference->WithMetadataValue('Version', ''))' != ''"
           Text="error NU1008: The following PackageReference items cannot define a value for Version: @(PackageReference->WithMetadataValue('Version', '')->Distinct()). Projects using Central Package Management must define a Version value on a PackageVersion item. For more information, visit https://aka.ms/nuget/cpm/gettingstarted" />
  </Target>

  error NU1008: The following PackageReference items cannot define a value for Version: ErikEJ.DacFX.SqlServer.Rules.
 Projects using Central Package Management must define a Version value on a PackageVersion item. For more information, visit https://aka.ms/nuget/cpm/gettingstarted


PS C:\Users\jcrandall\source\repos\sqlproj-app-ver01\Data-Tier> dotnet build
Restore complete (0.2s)
  Data-Tier net10.0 succeeded with 4 warning(s) (1.7s) → bin\Debug\net10.0\Data-Tier.dacpac
    EXEC : warning SRD0700: SqlServer.Rules : Set `<PageVerify>CHECKSUM</PageVerify>` in the project file to enable PAGE_VERIFY = CHECKSUM. (Use `<PageVerifyMode>Checksum</PageVerifyMode>`for MSBuild.Sdk.SqlProj projects.) (https://github.com/ErikEJ/SqlServer.Rules/blob/master/docs/Design/SRD0700.md)
    EXEC : warning SRD0701: SqlServer.Rules : Set `<QueryStoreDesiredState>READ_WRITE</QueryStoreDesiredState>` in the project file to enable Query Store. (Use `<QueryStoreDesiredState>ReadWrite</QueryStoreDesiredState>` for MSBuild.Sdk.SqlProj projects.) (https://github.com/ErikEJ/SqlServer.Rules/blob/master/docs/Design/SRD0701.md)
    EXEC : warning SRD0703: SqlServer.Rules : Set `<QueryStoreCaptureMode>AUTO</QueryStoreCaptureMode>` in the project file to enable QUERY_STORE_CAPTURE_MODE = AUTO. (https://github.com/ErikEJ/SqlServer.Rules/blob/master/docs/Design/SRD0703.md)
    EXEC : warning SRD0704: SqlServer.Rules : Set `<TargetRecoveryTimePeriod>60</TargetRecoveryTimePeriod>` in the project file to enable TARGET_RECOVERY_TIME. (https://github.com/ErikEJ/SqlServer.Rules/blob/master/docs/Design/SRD0704.md)


    https://github.com/ErikEJ/SqlServer.Rules/blob/master/docs/Design/SRD0700.md