using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using UglyToad.PdfPig;

class ConvertFromPDF : IFileConverter
{
    private string defaultPath = IFileConverter.DEFAULT_PATH;
    private string[] files = IFileConverter.ACTUAL_FILES;
    public const string EXTENSION = ".pdf";
    private const string OUTPUT_EXTENSION = IFileConverter.OUTPUT_EXTENSION;

    public void Conversion(string fileName)
    {
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

    }
}