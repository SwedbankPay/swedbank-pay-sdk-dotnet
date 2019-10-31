var target = Argument("target", "Copy-And-Publish-Artifacts");
var configuration = Argument("configuration", "Release");
var proj = $"./src/SwedbankPay.Sdk/SwedbankPay.Sdk.csproj";

var version = "4.0.0"; 

var artifactsDir = MakeAbsolute(Directory("artifacts"));
var packagesDir = artifactsDir.Combine(Directory("packages"));

Task("Build")    
    .Does(() => {
        DotNetCoreBuild(proj, new DotNetCoreBuildSettings { Configuration = "Release" });
    });

Task("Test")
    .IsDependentOn("Build")
    .Does(() => {
        Warning("Lacking tests."); 
        //var testproj = $"./src/SwedbankPay.Sdk/SwedbankPay.Sdk.csproj";       
        //DotNetCoreTest(testproj);     
});

Task("Pack")
    .IsDependentOn("Test")
    .Does(() => {
        var coresettings = new DotNetCorePackSettings
        {
            Configuration = "Release",
            OutputDirectory = packagesDir,
        };
        coresettings.MSBuildSettings = new DotNetCoreMSBuildSettings()
                                        .WithProperty("Version", new[] { version });

        
        DotNetCorePack(proj, coresettings);
});

Task("Copy-And-Publish-Artifacts")
	.IsDependentOn("Pack")
    .WithCriteria(BuildSystem.IsRunningOnAzurePipelinesHosted)
    .Does(() =>
    {
        Information($"Uploading files from packagesDir directory: {packagesDir} to TFS");
        TFBuild.Commands.UploadArtifactDirectory($"{packagesDir}");
    });

Task("PublishToNugetOrg")
    .IsDependentOn("Pack")
    .Does(() => {        
        var settings = new DotNetCoreNuGetPushSettings
        {
            Source = "https://api.nuget.org/v3/index.json",
            ApiKey = Argument("nugetapikey", "must-be-given")
        };

        DotNetCoreNuGetPush($"{packagesDir}/SwedbankPay.Sdk.{version}.nupkg", settings);        
});

RunTarget(target);