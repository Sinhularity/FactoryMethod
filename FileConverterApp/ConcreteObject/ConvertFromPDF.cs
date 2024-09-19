using Aspose.Words;

class ConvertFromPDF : IFileConverter
{
    private string defaultPath = IFileConverter.DEFAULT_PATH;
<<<<<<< HEAD
=======
    private string[] files = IFileConverter.ACTUAL_FILES;
>>>>>>> 35c4b7d2a7007c5d8b28bb6afc1f964bcfdd4cf2
    public const string EXTENSION = ".pdf";
    private const string OUTPUT_EXTENSION = IFileConverter.OUTPUT_EXTENSION;

    public void Conversion(string fileName)
    {
<<<<<<< HEAD
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
=======
        if (files.Any(file => file.Equals(fileName)))
        {
            string inputFile = fileName + EXTENSION;
            string outputFile;
            string inputPath = Path.Combine(defaultPath, inputFile);
            string outputPath;

            using (PdfDocument pdfDocument = PdfDocument.Open(inputPath))
            {
                int pageIndex = 1;
                foreach (var page in pdfDocument.GetPages())
                {
                    var image = new Image<Rgba32>(800, 600);
                    image.Mutate(x => x.BackgroundColor(Color.White));

                    outputFile = fileName + pageIndex + OUTPUT_EXTENSION;
                    outputPath = Path.Combine(defaultPath, outputFile);
                    image.Save(outputPath);

                    pageIndex++;
                }
            }
        }
        else
        {
            Console.WriteLine("El archivo no existe...");
        }

>>>>>>> 35c4b7d2a7007c5d8b28bb6afc1f964bcfdd4cf2
    }
}