using Chezahuiny;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public class Global
{
    private string name;
    private string path;
    private string lesson;
    private string lessonWhich;
    private string adm_func;
    private string pass = "769151";
    public void getpath()
    {
        path = Path.GetFullPath(".");
    }
    public void directorieswf()
    {
        if (!Directory.Exists(path + "\\Algebra"))
        {
            Directory.CreateDirectory(path + "\\Algebra");
        }
        if (!Directory.Exists(path + "\\Geometry"))
        {
            Directory.CreateDirectory(path + "\\Geometry");
        }
        if (!File.Exists(path + "\\Algebra\\Algebra_list.txt"))
        {
            File.Create(path + "\\Algebra\\Algebra_list.txt").Close();
        }
        if (!File.Exists(path + "\\Geometry\\Geometry_list.txt"))
        {
            File.Create(path + "\\Geometry\\Geometry_list.txt").Close();
        }
    }
    public void introduction()
    {
        Console.WriteLine("Programm created by Nikist,Asembly,Luci \n" +
                          "Для уроков алгебры/геометрии Ишмурзины Елены Рашидовны");
    }
    public void introduce()
    {
        Console.WriteLine("Введите свои данные одной строкой в формате Фамилия | Имя | Класс");
        try
        {
            using (StreamWriter student = new StreamWriter(path + "\\Answers.txt", true, Encoding.UTF8))
            {
                Console.WriteLine(path);
                name = Console.ReadLine();
                student.WriteLine(name);
            }
        }
        catch(Exception ex)
        {
            Console.Write(ex.Message);
        }
    }
    public void select_lessonType()
    {
        Console.WriteLine("Выбирите нужный предмет (Введите соответствующую цифру):\n" +
                          "1 - Алгебра\n" +
                          "2 - Геометрия");
        lesson = Console.ReadLine();
        if (lesson == "1")
        {
            lessonWhich = "1";
        }
        else if (lesson == "2")
        {
            lessonWhich = "2";
        }
        else if (lesson == pass)
        {
            lessonWhich = "3";
        }
        else
        {
            Console.WriteLine("Выбирите корректный вариант");
            select_lessonType();
        }
    }
    public void pass_check()
    {
        if (lessonWhich == "3")
        {
            Console.WriteLine("Вход в режим редактирования");
            adm();
        }
        else if (lessonWhich == "1" | lessonWhich ==  "2")
        {
            select_lessonNum();
        }
    }
    public void adm()
    {
        Console.WriteLine("Выбирите нужную функцию(Введите соответствующую цифру):\n" +
                          "1 - Добавить тест\n" +
                          "2 - Удалить тест");
        adm_func = Console.ReadLine();
        if (adm_func == "1")
        {
            using(StreamWriter admadd = new StreamWriter(path + "\\Algebra\\Algebra_list.txt",false))
            {
                admadd.WriteLine("sdfsdf");
            }
        }
        else if(adm_func == "2")
        {

        }
        else
        {
            Console.WriteLine("Выбирите корректный вариант");
            adm();
        }
    }
    public void select_lessonNum()
    {
        if (lessonWhich == "1")
        {

        }
        else if (lessonWhich == "2")
        {

        }
    }
}

namespace Chezahuiny
{
    internal class Program
    {
        static int Main(string[] args)
        {
            Global lessons = new Global();
            lessons.getpath();
            lessons.directorieswf();
            lessons.introduction();
            lessons.introduce();
            lessons.select_lessonType();
            lessons.pass_check();
            Console.ReadKey();
            return(0);
        }
    }
}