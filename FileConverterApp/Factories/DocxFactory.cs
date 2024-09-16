class DocxFactory
{
    public IFileConverter getConvertFromDocx()
    {
        return new ConvertFromDocx();
    }

    public string getExtension()
    {
        return ConvertFromDocx.EXTENSION;
    }
}