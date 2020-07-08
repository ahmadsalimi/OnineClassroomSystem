
function Upload {
    
    [cmdletbinding()]
    Param($sshUrl, $source, $target)

    $VerbosePreference = "Continue"

    if ([string]::IsNullOrEmpty($source))
    {
        return "Source is null"
    }

    if ((Get-Item $source) -is [System.IO.DirectoryInfo]) {
        Write-Verbose -Message "Cannot upload directories."
        return
    }
        
    Write-Verbose -Message "Starting Upload."
        
    Get-Content $source | ssh $sshUrl -T "cat > $target;"
        
    Write-Verbose -Message "Upload Finished."
}