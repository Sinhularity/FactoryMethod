using Aspose.Words;

class ConvertFromPDF : IFileConverter
{
    private string defaultPath = IFileConverter.DEFAULT_PATH;
    public const string EXTENSION = ".pdf";
    private const string OUTPUT_EXTENSION = IFileConverter.OUTPUT_EXTENSION;

    public void Conversion(string fileName)
    {
        string inputFile = fileName + EXTENSION;
        string outputFile;
        string inputPath = Path.Combine(defaultPath, inputFile);
        string outputPath;
        
        var doc = new Document(inputPath);
        for (int i = 0; i < doc.PageCount; i++)
        {
            var extractedPage = doc.ExtractPages(i, 1);
            extractedPage.Save(fileName + i + OUTPUT_EXTENSION);
        }
    }
}