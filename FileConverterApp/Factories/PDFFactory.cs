class PDFFactory : IFileConverterFactory
{
    public IFileConverter createFileConverter() {
        return new ConvertFromPDF();
    }

    public string getExtension() {
        return ConvertFromPDF.EXTENSION;
    }
    
}