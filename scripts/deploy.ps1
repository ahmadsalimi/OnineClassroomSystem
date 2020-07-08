[cmdletbinding()]
param(
    $sshUrl,
    $project
)

Import-Module .\publish.psm1 -Force
Import-Module .\upload.psm1 -Force

$VerbosePreference = "Continue"
Write-Verbose -Message "Starting publish"

$publish_file = Publish $project -verbose

Write-Verbose -Message "Publish file is $publish_file"

$upluad_file = "publish.zip"
Upload $sshUrl $publish_file $upluad_file -verbose

$run_script = "move_and_serve.sh"
Upload $sshUrl $run_script $run_script -verbose

ssh $sshUrl -T "sudo bash $run_script; sudo rm $run_script"