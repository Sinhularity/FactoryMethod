interface IFileConverter
{
    // No puede ser constante debido a que el método nos devuelve un ambiente dinámico
    static readonly string DEFAULT_PATH = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
<<<<<<< HEAD
=======
    static readonly string [] ACTUAL_FILES =  Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) // Obtiene todos los archivos en el directorio
                                       .Select(file => Path.GetFileNameWithoutExtension(file).Trim()) // Obtiene el nombre del archivo sin la extensión
                                       .ToArray(); // Convierte la lista en un array
>>>>>>> 35c4b7d2a7007c5d8b28bb6afc1f964bcfdd4cf2
    const string OUTPUT_EXTENSION = ".jpg";
    void Conversion(string fileName);
}