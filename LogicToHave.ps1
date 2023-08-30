function test {
    param ($path,
        [ValidateSet("year","month","day")]
        $FolderBasedOn)
    if (test-path $path) {

        $FilesInPath = Get-ChildItem -File -Path $path
        
        if ($FilesInPath) {
            foreach ($f in $FilesInPath) {

                $CreationTime = $f.CreationTime

                if ($FolderBasedOn -eq 'year') {
                    $YearofFile = get-date $CreationTime -Format yyyy
                }
                elseif($FolderBasedOn -eq 'month') {
                    $YearofFile = get-date $CreationTime -Format yyyy-MM
                }
                elseif($FolderBasedOn -eq 'day') {
                    $YearofFile = get-date $CreationTime -Format yyyy-MM-dd
                }

                $FullpathOfNewFolder = "$Path\$YearofFile"

                if (Test-Path $FullpathOfNewFolder) {
                    # Move file
                    Move-Item -Path $f.FullName -Destination $FullpathOfNewFolder -Verbose
                }
                else {
                    # Create folder, move file
                    New-Item -ItemType Directory -Path $FullpathOfNewFolder
                    Move-Item -Path $f.FullName -Destination $FullpathOfNewFolder -Verbose
                }
                
            }
        }
        
    }
    else {
        write-error "n"
    }
}