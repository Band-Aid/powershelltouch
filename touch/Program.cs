if (args.Length == 0)
{
    Console.WriteLine("Usage: touch <file_path> [<file_size>]");
    return;
}

string filePath = args[0];
long fileSize = args.Length > 1 ? long.Parse(args[1]) : -1;

try
{
    // If the file exists, update its timestamp
    if (File.Exists(filePath))
    {
        File.SetLastWriteTime(filePath, DateTime.Now);
        Console.WriteLine($"Updated timestamp of {filePath}");

        if (fileSize >= 0)
        {
            using (var fs = new FileStream(filePath, FileMode.Open))
            {
                fs.SetLength(fileSize);
            }
            Console.WriteLine($"Updated size of {filePath} to {fileSize} bytes");
        }
    }
    else
    {
        // If the file does not exist, create it
        using (var fs = File.Create(filePath))
        {
            if (fileSize >= 0)
            {
                fs.SetLength(fileSize);
            }
        }
        Console.WriteLine($"Created file {filePath} with size {fileSize} bytes");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}