using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
namespace Курсовая
{
    class Program
    {
        class MyOptions
        {
            public string Title { get; set; }
        }
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("json1.json").Build();
            var options = configuration.GetSection("CustomOptions").Get<MyOptions>();
            Console.WriteLine(options.Title);

            string path = @"C:\1";
            string[] a = Directory.GetDirectories(path);
            foreach (string fn in a)
            {
                Console.WriteLine(fn);
            }

            if (Directory.Exists(path))
            {
                Console.WriteLine("Подкаталоги:");
                string[] dirs = Directory.GetDirectories(path, "*.*", SearchOption.AllDirectories);
                foreach (string s in dirs)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine();
                Console.WriteLine("Файлы:");
                string[] files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
                foreach (string s in files)
                {
                    Console.WriteLine(s);
                }



            }
            InfoAboutDirectory(path); //вывод информации о каталоге
            GetInfoFile(path); // получение информации о файле
            CopyFileAndDirectories(path);// копирование файлов
            DeleteDirMethod(path); // удаление директории,вместе с ее содержимым 
        }






        static void GetInfoFile(string path)
        {
            var files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                FileInfo MYFILE = new FileInfo(file);
                Console.WriteLine("Размер: {0}", MYFILE.Length);
                Console.WriteLine("Путь: {0}", MYFILE.DirectoryName);
                Console.WriteLine("Имя файла: {0}", MYFILE.Name);
                Console.WriteLine("Время создания: {0}", MYFILE.CreationTime);

            }
        }

        static void InfoAboutDirectory(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            DirectoryInfo[] diArray = directory.GetDirectories(); //массив объектов DirInfo который возвращает все каталоги в папке
            foreach (DirectoryInfo directory1 in diArray)
            {
                Console.WriteLine("FullName: {0} ", directory1.FullName);
                Console.WriteLine("Parent: {0} ", directory1.Parent);
                Console.WriteLine("Creation: {0} ", directory1.CreationTime);
                Console.WriteLine("Attributes: {0} ", directory1.Attributes);
                Console.WriteLine("Root: {0} ", directory1.Root);
            }

        }
        static void CopyFileAndDirectories(string path)
        {
            Console.WriteLine("введите команду");
            var vvod = Console.ReadLine();
            if (vvod == "cp")
            
                try
                {

                    string fileName = "файл.txt";
                    string sourcePath = @"C:\1\";
                    string targetPath = @"C:\1\первая";

                    string sourceFile = Path.Combine(sourcePath, fileName);
                    string destFile = Path.Combine(targetPath, fileName);

                    Directory.CreateDirectory(targetPath);

                    File.Copy(sourceFile, destFile, true);

                    //копирование всех файлов
                    if (Directory.Exists(sourcePath))
                    {
                        string[] files = Directory.GetFiles(sourcePath);


                        foreach (string s in files)
                        {
                            fileName = Path.GetFileName(s);
                            destFile = Path.Combine(targetPath, fileName);
                            File.Copy(s, destFile, true);
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Такого файла/директории не существует");
                }

            
        }
        static void DeleteDirMethod(string path)
        {
            Console.WriteLine("введите команду");
            var vvod = Console.ReadLine();
            if (vvod == "delete")
                try
                {
                    Console.WriteLine("введите название папки или файла, который хотите удалить ");
                    var choice = Console.ReadLine();
                    string directoria =  ($@"C:\1\{choice}");
                    Directory.Delete(directoria, true); //true - если директория не пуста удаляем все ее содержимое
                    Directory.CreateDirectory(directoria);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
        }
    }
}
string fileName = "файл.txt";
string sourcePath = @"C:\1\";
string targetPath = @"C:\1\первая";