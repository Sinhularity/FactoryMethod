using Spire.Doc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

class ConvertFromDocx : IFileConverter
{
    private string defaultPath = IFileConverter.defaultPath;

    public const string EXTENSION = ".docx";
    public const string OUTPUT_EXTENSION = ".png";
    public void Conversion(string fileName)
    {
        string inputFile = fileName + EXTENSION;
        string outputFile;
        string inputPath = Path.Combine(defaultPath, inputFile);
        string outputPath;
        Document docxDocument = new Document();
        docxDocument.LoadFromFile(inputPath);

        for (int i = 0; i < docxDocument.Sections.Count; i++)
        {
            // Convertir cada sección del DOCX a una imagen de System.Drawing.Image
            using (System.Drawing.Image sectionImage = docxDocument.SaveToImages(i, Spire.Doc.Documents.ImageType.Bitmap))
            {
                // Guardar la imagen de System.Drawing.Image en un MemoryStream
                using (MemoryStream ms = new MemoryStream())
                {
                    sectionImage.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp); // Guardar en formato BMP en el stream
                    ms.Seek(0, SeekOrigin.Begin); // Volver al inicio del stream

                    // Cargar la imagen en ImageSharp desde el MemoryStream
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
    }
}