﻿class ConverterApp
{
   
    static void Main(string[] args)
    {
        // Fábricas concretas
        IFileConverterFactory converterFactory = null;
        // Convertidor base
        IFileConverter fileConverter;

        int option = 0;
        string fileName = string.Empty;

        try
        {
            do
            {
                Console.WriteLine("Selecciona el convertidor de archivo: \n 1.- Docx a JPG\n 2.- PDF a JPG\n 0.- Salir del programa");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        fileName = GetFileName();
                        converterFactory = new DocxFactory();
                        Console.WriteLine("-----------------------------");
                        Console.WriteLine("Se ha generado con éxito el/los archivo(s)");
                        Console.WriteLine("-----------------------------");
                        break;
                    case 2:
                        fileName = GetFileName();
                        converterFactory = new PDFFactory();
                        Console.WriteLine("-----------------------------");
                        Console.WriteLine("Se ha generado con éxito el/los archivo(s)");
                        Console.WriteLine("-----------------------------");
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Opción no válida, intenta de nuevo");
                        break;
                }
                fileConverter = converterFactory.createFileConverter();
                fileConverter.Conversion(fileName);
            }
            while (option != 0);
            return;
        }
        catch (IOException e)
        {
            Console.WriteLine($"Intenta ingresar datos válidos -> Nombre del archivo: {fileName} & Extensión del archivo: {option}");
            Console.WriteLine(e.Message);
        }
    }
    public static string GetFileName()
    {
        Console.WriteLine("Introduce el nombre del archivo a convertir: ");
        return Console.ReadLine().Trim();
    }
}