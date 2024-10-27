if (args.Length == 0)
{
    Console.WriteLine("Usage: touch <file_path>");
    return;
}

string filePath = args[0];

try
{
    // If the file exists, update its timestamp
    if (File.Exists(filePath))
    {
        File.SetLastWriteTime(filePath, DateTime.Now);
        Console.WriteLine($"Updated timestamp of {filePath}");
    }
    else
    {
        // If the file does not exist, create it
        using (File.Create(filePath)) { }
        Console.WriteLine($"Created file {filePath}");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}