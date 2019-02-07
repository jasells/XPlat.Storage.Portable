# Read in the build configuration value (default to debug)
param($configuration="Debug", $outputDir=".\")

# This is coded specifically for XPlat.Storage.Portable
# If you want to use this script for another package modify paths accordingly
# MSBUMP updates the product version of the file, so that's what we'll grab
$nugetVersion = (Get-Item "XPlat.Storage.Portable\bin\$configuration\netstandard1.4\XPlat.Storage.Portable.dll").VersionInfo.ProductVersion

# Run the pack command
if($configuration.ToLower().Equals("debug"))
{
	.\nuget pack "XPlat.Storage.Portable\pack.nuspec" -OutputDirectory $outputDir -Properties Configuration=$configuration -Version $nugetVersion -Symbols -SymbolPackageFormat snupkg
}
else
{
	.\nuget pack "XPlat.Storage.Portable\pack.nuspec" -OutputDirectory $outputDir -Properties Configuration=$configuration -Version $nugetVersion
}