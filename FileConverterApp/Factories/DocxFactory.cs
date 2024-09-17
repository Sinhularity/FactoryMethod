class DocxFactory : IFileConverterFactory
{
   public IFileConverter createFileConverter() {
        return new ConvertFromDocx();
   }

    public string getExtension()
    {
        return ConvertFromDocx.EXTENSION;
    }
}