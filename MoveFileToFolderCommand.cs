using System;
using System.Management.Automation;
using System.IO;
using System.Text.RegularExpressions;
namespace FilesToFolders
{
    [Cmdlet(VerbsCommon.Move, "FileToFolder", SupportsShouldProcess = true)]
    [OutputType(typeof(VerboseRecord))]
    public class MoveFileToFolderCommand : PSCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0)]
        public string Path { get; set; } = Environment.CurrentDirectory;

        [Parameter(
            Position = 1)]
        [ValidateSet("Day", "Month", "Year")]
        public string FolderBasedOn { get; set; } = "Month";

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
                //WriteObject(files);
                foreach (string f in files)
                {
                    // New variable that stores CreationDateTime of file
                    DateTime d = File.GetCreationTime(f);

                    bool isYear = Regex.IsMatch(FolderBasedOn, "Year");
                    if (isYear)
                    {
                        // WriteObject(FolderBasedOn);
                        string folderBasedOn = d.ToString("yyyy");
                        string fullPath = $"{Path}\\{folderBasedOn}";
                        WriteVerbose($"{f} will move to: {fullPath}.");
                        if (ShouldProcess($"{f} -> {fullPath}"))
                        {
                            Directory.CreateDirectory(fullPath);
                            string fileName = System.IO.Path.GetFileName(f);
                            File.Move(f, $"{fullPath}\\{fileName}");
                            WriteVerbose($"{f} was moved to {fullPath}\\{fileName}.");
                        }
                    }

                    bool isMonth = Regex.IsMatch(FolderBasedOn, "Month");
                    if (isMonth)
                    {
                        // WriteObject(FolderBasedOn);
                        string folderBasedOn = d.ToString("yyyy-MM");
                        string fullPath = $"{Path}\\{folderBasedOn}";
                        WriteVerbose($"{f} will move to: {fullPath}.");
                        if (ShouldProcess($"{f} -> {fullPath}"))
                        {
                            Directory.CreateDirectory(fullPath);
                            string fileName = System.IO.Path.GetFileName(f);
                            File.Move(f, $"{fullPath}\\{fileName}");
                            WriteVerbose($"{f} was moved to {fullPath}\\{fileName}.");
                        }
                    }

                    bool isDay = Regex.IsMatch(FolderBasedOn, "Day");
                    if (isDay)
                    {
                        // WriteObject(FolderBasedOn);
                        string folderBasedOn = d.ToString("yyyy-MM-dd");
                        string fullPath = $"{Path}\\{folderBasedOn}";
                        WriteVerbose($"{f} will move to: {fullPath}.");
                        if (ShouldProcess($"{f} -> {fullPath}"))
                        {
                            Directory.CreateDirectory(fullPath);
                            string fileName = System.IO.Path.GetFileName(f);
                            File.Move(f, $"{fullPath}\\{fileName}");
                            WriteVerbose($"{f} was moved to {fullPath}\\{fileName}.");
                        }
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

public class PathNotFoundException : ArgumentException
{
    public PathNotFoundException()
        : base("The path provided was not found.")
    { }
}