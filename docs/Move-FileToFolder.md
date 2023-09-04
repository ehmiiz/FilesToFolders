---
external help file: FilesToFolders.dll-Help.xml
Module Name: FilesToFolders
online version:
schema: 2.0.0
---

# Move-FileToFolder

## SYNOPSIS
Moves files to folders which names are based on date formats

## SYNTAX

```
Move-FileToFolder [-Path] <String> [[-FolderNameFormat] <String>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The `Move-FileToFolder` cmdlet moves files from the path specified to the user, and creates folders with names that are based on date formats, the formats translate to:
- `yyyy` -> `2023`
- `yyyy-MM` -> `2023-09`
- `yyyy-MM-dd` -> `2023-09-04`.

## EXAMPLES

### Example 1
```powershell
PS > Move-FileToFolder -Path $pwd -FolderNameFormat yyyy-MM-dd
```
```Output
Creating dir: C:\Temp\test\2023-09-04
Moving file: C:\Temp\test\123.ps1
Moving file: C:\Temp\test\321.ps1
```

In this example `$pwd` equals to `C:\Temp\test`. This directory contains two files, `123.ps1` and `321.ps1`. `Move-FileToFolder` moves both files to the newly created folder `2023-09-04`.

### Example 2
```powershell
PS > Move-FileToFolder -Path $pwd -FolderNameFormat yyyy-MM-dd -WhatIf
```
```Output
What if: Performing the operation "Move-FileToFolder" on target "C:\Temp\test\123.ps1 -> C:\Temp\test\2023-09-04".
What if: Performing the operation "Move-FileToFolder" on target "C:\Temp\test\321.ps1 -> C:\Temp\test\2023-09-04".
```

In this example `$pwd` equals to `C:\Temp\test`. This directory contains two files, `123.ps1` and `321.ps1`. `Move-FileToFolder` would have created the folder `2023-09-04` and moved the files there, but since -WhatIf was specified, nothing was changed.

### Example 3
```powershell
PS > Move-FileToFolder -Path $pwd -FolderNameFormat yyyy-MM-dd -Verbose
```
```Output
VERBOSE: Path exists.
VERBOSE: C:\Temp\test\123.ps1 will move to: C:\Temp\test\2023-09-04.
VERBOSE: Performing the operation "Move-FileToFolder" on target "C:\Temp\test\123.ps1 -> C:\Temp\test\2023-09-04".
Creating dir: C:\Temp\test\2023-09-04
Moving file: C:\Temp\test\123.ps1
VERBOSE: C:\Temp\test\123.ps1 was moved to C:\Temp\test\2023-09-04\123.ps1.
VERBOSE: C:\Temp\test\321.ps1 will move to: C:\Temp\test\2023-09-04.
VERBOSE: Performing the operation "Move-FileToFolder" on target "C:\Temp\test\321.ps1 -> C:\Temp\test\2023-09-04".
Moving file: C:\Temp\test\321.ps1
VERBOSE: C:\Temp\test\321.ps1 was moved to C:\Temp\test\2023-09-04\321.ps1.
VERBOSE: End!
```

In this example `$pwd` equals to `C:\Temp\test`. This directory contains two files, `123.ps1` and `321.ps1`. `Move-FileToFolder` moves both files to the newly created folder `2023-09-04`, and outputs progress to the verbose and output stream.

## PARAMETERS

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FolderNameFormat
The names are based on .NET Frameworks format specifiers, however only 3 values are allowed.

Multiple folders will be created if the files have different `CreationDate` values.

If the date would be 2023-09-04, folder name would translate to:

- `yyyy` -> `2023`
- `yyyy-MM` -> `2023-09`
- `yyyy-MM-dd` -> `2023-09-04`.

```yaml
Type: String
Parameter Sets: (All)
Aliases:
Accepted values: yyyy-MM-dd, yyyy-MM, yyyy

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Path
Specify a path on the filesystem to operate on.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

## NOTES

## RELATED LINKS