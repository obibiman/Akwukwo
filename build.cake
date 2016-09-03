#tool "nuget:?package=roundhouse"
#tool "nuget:?package=OctopusTools"
var target = Argument("target", "Default"); 

Task("Default")
  .Does(() =>  {
  Information("Hello World!"); 
}); 

RunTarget(target); 

// param($installPath, $toolsPath, $package, $project)

// $path = $env:PATH
// if (!$path.Contains($toolsPath)) {
//     $env:PATH += ";$toolsPath"
// }