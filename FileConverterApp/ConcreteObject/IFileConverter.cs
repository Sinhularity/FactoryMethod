interface IFileConverter
{
    // No puede ser constante debido a que el método nos devuelve un ambiente dinámico
    static readonly string DEFAULT_PATH = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    const string OUTPUT_EXTENSION = ".jpg";
    void Conversion(string fileName);
}