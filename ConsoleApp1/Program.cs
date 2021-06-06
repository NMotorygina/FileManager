// Моторыгина Наталия
/*
Напишите программу «Простейший файловый менеджер».
Возможности:
1. Смена текущего каталога (путь к текущему каталогу должен всегда отображаться на экране);-------------------cd
2. Отображение всех подкаталогов текущего каталога;-----------------------------------------------------------dir/d
3. Отображение всех файлов текущего каталога;-----------------------------------------------------------------dir/f
4. Создание нового каталога в текущем каталоге;---------------------------------------------------------------md
5. Удаление уже существующего каталога (если каталог не пустой — то необходимо удалить все его содержимое,----rd
для этого Вам необходимо использовать  рекурсию).
*/

using System;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            var path = Directory.GetCurrentDirectory();
            FileManager(path);
        }
        static void FileManager(string path)
        {
            Console.Write($"{path}>");
            string selection = Console.ReadLine();
            switch (selection)
            {
                case "cd":
                    path = OpenDir();
                    FileManager(path);
                    break;
                case "dir/d":
                    PrintDirs(path);
                    FileManager(path);
                    break;
                case "dir/f":
                    PrintFiles(path);
                    FileManager(path);
                    break;
                case "md":
                    path = CreateNewDir(path);
                    FileManager(path);
                    break;
                case "rd":
                    path = DeleteDir();
                    FileManager(path);
                    break;
                case "exit":
                    break;
                default:
                    Console.WriteLine($"\"{selection}\" не является командой");
                    FileManager(path);
                    break;
            }
        }
        static string OpenDir()
        {
            string newPath;
            do
            {
                Console.Write("Введите путь к каталогу - ");
                newPath = Console.ReadLine();
            } while (!Directory.Exists(newPath));
            return newPath;
        }
        static void PrintDirs(string path)
        {
            Console.WriteLine("Список подкаталогов в указанном каталоге:");
            var dirs = Directory.GetDirectories(path);
            foreach (var dir in dirs)
            {
                Console.WriteLine(dir);
            }
        }
        static void PrintFiles(string path)
        {
            Console.WriteLine("Список файлов в указанном каталоге:");
            var files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
        }
        static string CreateNewDir(string path)
        {
            Console.Write("Введите имя каталога - ");
            var newDir = Console.ReadLine();
            var newPath = path + "\\" + newDir;
            Directory.CreateDirectory(newPath);
            return newPath;
        }
        static string DeleteDir()
        {
            string newPath;
            do
            {
                Console.Write("Введите путь к каталогу - ");
                newPath = Console.ReadLine();
            } while (!Directory.Exists(newPath));
            var parent = Directory.GetParent(newPath);
            Directory.Delete(newPath, true);
            return parent.ToString();
        }
    }
}