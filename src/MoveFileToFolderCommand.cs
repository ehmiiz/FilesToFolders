using System;
using System.Management.Automation;
using System.IO;

namespace FilesToFolders
{
    [Cmdlet(VerbsCommon.Move, "FileToFolder", SupportsShouldProcess = true)]
    [OutputType(typeof(VerboseRecord))]
    public class MoveFileToFolderCommand : PSCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0)]
        public string Path { get; set; }

        [Parameter(
            Position = 1)]
        [ValidateSet("yyyy-MM-dd", "yyyy-MM", "yyyy")]
        public string FolderNameFormat { get; set; } = "yyyy-MM";

        // If any folders on given path exist, create a folder(s) in that path with
        // the Day, Month, Year, naming standard: "2023-01-31", "2023-01", "2023"
        // and move the files there
        protected override void ProcessRecord()
        {
            if (Directory.Exists(Path))
            {
                WriteVerbose("Path exists.");
                // Create two variables with the files full path and
                // the files creation date
                Path = Path.TrimEnd('\\');
                string[] files = Directory.GetFiles(Path);
                

                foreach (string f in files)
                {
                    // New variable that stores CreationDateTime of file
                    DateTime d = File.GetCreationTime(f);
                    string folderNameFormat = d.ToString(FolderNameFormat);

                    string fullPath = $"{Path}\\{folderNameFormat}";
                    WriteVerbose($"{f} will move to: {fullPath}.");
                    if (ShouldProcess($"{f} -> {fullPath}"))
                    {
                        
                        bool testPath = Directory.Exists(fullPath);

                        // If path does not exist, output progress and create
                        if (!testPath)
                        {
                            WriteObject($"Creating dir: {fullPath}");
                            Directory.CreateDirectory(fullPath);
                        }

                        // Get the filename only to build destination path
                        string fileName = System.IO.Path.GetFileName(f);
                        WriteObject($"Moving file: {f}");


                        // Build the destination path and move the file
                        string destinationPath = $"{fullPath}\\{fileName}";
                        File.Move(f, destinationPath);

                        // debug msg
                        WriteVerbose($"{f} was moved to {fullPath}\\{fileName}.");
                    
                    }
                }
            }
            else
            {
                throw new PathNotFoundException();
            }
        }
        protected override void EndProcessing()
        {
            WriteVerbose("End!");
        }
    }
}