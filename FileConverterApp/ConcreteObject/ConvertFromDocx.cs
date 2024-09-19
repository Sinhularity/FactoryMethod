using Spire.Doc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

class ConvertFromDocx : IFileConverter
{
    private string defaultPath = IFileConverter.DEFAULT_PATH;
<<<<<<< HEAD
    public const string EXTENSION = ".docx";
    private const string OUTPUT_EXTENSION = IFileConverter.OUTPUT_EXTENSION;
=======
    private string[] files = IFileConverter.ACTUAL_FILES;
    public const string EXTENSION = ".docx";
    public const string OUTPUT_EXTENSION = IFileConverter.OUTPUT_EXTENSION;
>>>>>>> 35c4b7d2a7007c5d8b28bb6afc1f964bcfdd4cf2
    public void Conversion(string fileName)
    {
        string inputFile = fileName + EXTENSION;
        string outputFile;
        string inputPath = Path.Combine(defaultPath, inputFile);
        string outputPath;
        Document docxDocument = new Document();
<<<<<<< HEAD

            docxDocument.LoadFromFile(inputPath);

            for (int i = 0; i < docxDocument.PageCount; i++)
            {
                using (System.Drawing.Image pageImage = docxDocument.SaveToImages(i, Spire.Doc.Documents.ImageType.Bitmap))
                {
                    using (MemoryStream ms = new MemoryStream())
=======

        docxDocument.LoadFromFile(inputPath);

        for (int i = 0; i < docxDocument.PageCount; i++)
        {
            using (System.Drawing.Image pageImage = docxDocument.SaveToImages(i, Spire.Doc.Documents.ImageType.Bitmap))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    pageImage.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    ms.Seek(0, SeekOrigin.Begin);

                    using (var image = SixLabors.ImageSharp.Image.Load<Rgba32>(ms))
>>>>>>> 35c4b7d2a7007c5d8b28bb6afc1f964bcfdd4cf2
                    {
                        pageImage.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                        ms.Seek(0, SeekOrigin.Begin);

                        using (var image = SixLabors.ImageSharp.Image.Load<Rgba32>(ms))
                        {
                            // Guardar la imagen como JPG
                            outputFile = fileName + "_page" + (i + 1) + OUTPUT_EXTENSION;
                            outputPath = Path.Combine(defaultPath, outputFile);
                            image.Save(outputPath);
                        }
                    }
                }
            }
<<<<<<< HEAD
=======
            Console.WriteLine($"JPG {outputFile} creado en {outputPath}");
        }
>>>>>>> 35c4b7d2a7007c5d8b28bb6afc1f964bcfdd4cf2
    }
}