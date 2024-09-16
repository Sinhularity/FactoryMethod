interface IFileConverter
{
    static readonly string defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    void Conversion(string fileName);
}