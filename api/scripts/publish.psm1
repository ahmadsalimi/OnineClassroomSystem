function Publish {

    [CmdletBinding()]
    Param($project)

    $VerbosePreference = "Continue"
    $publish_location = "bin\Release\netcoreapp3.1\publish"

    $current = Get-Location

    Set-Location $project

    Write-Verbose -Message "Removing publish folder"
    Remove-Item $publish_location -Recurse

    Write-Verbose -Message "Starting publish"
    Write-Verbose -Message ""
    Write-Verbose -Message ""
    $_ = dotnet publish --configuration Release
    Write-Verbose ""
    Write-Verbose ""
    Write-Verbose -Message "Publish done"

    Set-Location $publish_location

    $archive = "archive/"
    $name = "publish.zip"

    $archive_path = Join-Path -Path $archive -ChildPath $name

    $_ = mkdir -Path $archive

    Write-Verbose -Message "Start Compressing"
    Write-Verbose -Message ""
    Write-Verbose -Message ""
    Compress-Archive -Path * -DestinationPath $archive_path
    Write-Verbose -Message ""
    Write-Verbose -Message ""
    Write-Verbose -Message "Compress done."

    Set-Location $current

    return Join-Path -Path $project -ChildPath (Join-Path -Path $publish_location -ChildPath $archive_path)
}
