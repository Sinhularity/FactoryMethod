interface IFileConverter
{
    // No puede ser constante debido a que el método nos devuelve un ambiente dinámico
    static readonly string DEFAULT_PATH = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    static readonly string [] ACTUAL_FILES =  Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) // Obtiene todos los archivos en el directorio
                                       .Select(file => Path.GetFileNameWithoutExtension(file).Trim()) // Obtiene el nombre del archivo sin la extensión
                                       .ToArray(); // Convierte la lista en un array
    const string OUTPUT_EXTENSION = ".jpg";
    void Conversion(string fileName);
}