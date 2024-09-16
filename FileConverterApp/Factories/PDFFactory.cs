class PDFFactory
{
    public IFileConverter getConvertFromPDF() {
        return new ConvertFromPDF();
    }

    public string getExtension() {
        return ConvertFromPDF.EXTENSION;
    }
}