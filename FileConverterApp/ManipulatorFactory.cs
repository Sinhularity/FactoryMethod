class ManipulatorFactory
{
    private string[] files = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) // Obtiene todos los archivos en el directorio
                                       .Select(file => Path.GetFileNameWithoutExtension(file).Trim()) // Obtiene el nombre del archivo sin la extensión
                                       .ToArray(); // Convierte la lista en un array

    FormatsAvailable formatsAvailable = new FormatsAvailable();
    DocxFactory docxFactory = new DocxFactory();
    PDFFactory pdfFactory = new PDFFactory();
    public void showfiles(){
        Console.WriteLine("Files in the directory: ");
        foreach (var file in files)
        {
            Console.WriteLine($"* {file}");
        }
    }
    public bool doesFileExist(string fileName)
    {
        bool fileExists = files.Any(file => file.Equals(fileName));
        return fileExists;
    }
    public ManipulatorFactory() {
        formatsAvailable.AddFormat(docxFactory.getExtension(), docxFactory.getConvertFromDocx());
        formatsAvailable.AddFormat(pdfFactory.getExtension(), pdfFactory.getConvertFromPDF());
    }

    public void mainMenu()
    {
        string fileName = string.Empty;
        int fileExtension = 0;
        try
        {
            do {
                Console.WriteLine("Select the file extension to convert: ");
                FormatsAvailable.GetFormats(); // PDF to image, DOCX to image...
                fileExtension = int.Parse(Console.ReadLine() ?? "0");
                Console.WriteLine("Enter the file name to convert: ");
                fileName = Console.ReadLine().Trim();

                if (!doesFileExist(fileName))
                {
                    Console.WriteLine("The file does not exist in the directory.");
                } else if (!formatsAvailable.isValidFormat(fileExtension))
                {
                    Console.WriteLine("The file extension is not valid.");
                }
            } while (!formatsAvailable.isValidFormat(fileExtension) || !files.Contains(fileName));

            formatsAvailable.initializeConversion(fileExtension, fileName);

            Console.WriteLine("File converted successfully.");
            return;
        }
        catch (IOException e)
        {
            Console.WriteLine($"Try putting a valid input -> File name: {fileName} & file extension: {fileExtension}");
            Console.WriteLine(e.Message);
        }
    }

    class FormatsAvailable
    {
        private static SortedDictionary<int, string> fileExtensions = new SortedDictionary<int, string>();
        private static SortedDictionary<int, IFileConverter> fileFormat = new SortedDictionary<int, IFileConverter>();

        public static void GetFormats()
        {
            foreach (var format in fileExtensions)
            {
                Console.WriteLine($"{format.Key}. {format.Value}");
            }
        }
        public void AddFormat(string extension, IFileConverter fileFormatToConvert)
        {
            fileExtensions.Add(fileExtensions.Count + 1, extension);
            fileFormat.Add(fileFormat.Count + 1, fileFormatToConvert);
        }
        public string getExtension(int extension)
        {
            return fileExtensions[extension];
        }
        public bool isValidFormat(int option) {
            return fileFormat.ContainsKey(option);
        }
        public void initializeConversion (int option, string fileName)
        {
            fileFormat[option].Conversion(fileName);
        }
    }

}