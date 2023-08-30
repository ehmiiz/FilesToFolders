# FilesToFolders


Moves all files from the current working directory into folders named after each files creation date

```powershell
Move-FileToFolder -Path $pwd -FolderBasedOn Month
```

```Output
Mode                 LastWriteTime         Length Name
----                 -------------         ------ ----
d----           8/30/2023  1:08 PM                2022-06
d----           8/30/2023  1:08 PM                2022-07
d----           8/30/2023  1:08 PM                2022-08
d----           8/30/2023  1:08 PM                2022-09
d----           8/30/2023  1:08 PM                2022-10
d----           8/30/2023  1:08 PM                2022-11
d----           8/30/2023  1:08 PM                2022-12
d----           8/30/2023  1:08 PM                2023-03
d----           8/30/2023  1:08 PM                2023-08
```


```powershell
Set-Location -Path C:\Temp
Move-FileToFolder -FolderBasedOn Month -WhatIf
```