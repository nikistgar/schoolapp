﻿using Chezahuiny;
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
    private string lessonWhichadm;
    private string adm_func;
    private string Testnameadd;
    private string Testnameremove;
    private string admpath;
    private string admlist;
    private string admlesson;
    private string pass = "769151";
    public void getpath()
    {
        path = Path.GetFullPath(".");
    }
    public void directorieswf()
    {
        if (!Directory.Exists(path + "\\Algebra"))
        {
            try
            {
                Directory.CreateDirectory(path + "\\Algebra");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        if (!Directory.Exists(path + "\\Geometry"))
        {
            try
            {
                Directory.CreateDirectory(path + "\\Geometry");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        if (!File.Exists(path + "\\Algebra\\Algebra_list.txt"))
        {
            try
            {
                File.Create(path + "\\Algebra\\Algebra_list.txt").Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        if (!File.Exists(path + "\\Geometry\\Geometry_list.txt"))
        {
            try
            {
                File.Create(path + "\\Geometry\\Geometry_list.txt").Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    public void line_delete(string filen, string rstr)
    {
        string tempFile = Path.GetTempFileName();

        using (var sr = new StreamReader("file.txt"))
        using (var sw = new StreamWriter(tempFile))
        {
            string liner;
            while ((liner = sr.ReadLine()) != null)
            {
                if (liner != rstr)
                    sw.WriteLine(liner);
            }
        }

        File.Delete(filen);
        File.Move(tempFile, filen);
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
            using (var student = new StreamWriter(path + "\\Answers.txt", true, Encoding.UTF8))
            {
                Console.WriteLine(path);
                name = Console.ReadLine();
                student.WriteLine(name);
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
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
            admwhich();
        }
        else if (lessonWhich == "1" | lessonWhich ==  "2")
        {
            select_lessonNum();
        }
    }
    public void admwhich()
    {
        Console.WriteLine("Выбирите нужный предмет для изменений (Введите соответствующую цифру):\n" +
                              "1 - Алгебра\n" +
                              "2 - Геометрия");
        admlesson = Console.ReadLine();
        if (admlesson == "1")
        {
            lessonWhichadm = "1";
            admlessoncheck();
        }
        else if (admlesson == "2")
        {
            lessonWhichadm = "2";
            admlessoncheck();
        }
        else
        {
            Console.WriteLine("Выбирите корректный вариант");
            admwhich();
        }
    }
    public void admlessoncheck()
    {
        if (lessonWhichadm == "1")
        {
            admpath = path + "\\Algebra";
            admlist = "\\Algebra_list.txt";
            adm();
        }
        else if(lessonWhichadm == "2")
        {
            admpath = path + "\\Geometry";
            admlist = "\\Geometry_list.txt";
            adm();
        }
    }
    public void adm()
    {
        Console.WriteLine("Выбирите нужную функцию(Введите соответствующую цифру):\n" +
                          "1 - Добавить тест\n" +
                          "2 - Удалить тест\n" +
                          "3 - Вывести список текущих тестов\n" +
                          "4 - К выбору предметов\n" +
                          "0 - Выйти из режима редактирования");
        adm_func = Console.ReadLine();
        if (adm_func == "1")
        {
            admadd();
        }
        else if(adm_func == "2")
        {
            admrem();
        }
        else if(adm_func == "3")
        {
            TestList();
        }
        else if (adm_func == "4")
        {
            admwhich();
        }
        else if(adm_func == "0")
        {
            select_lessonType();
        }
        else
        {
            Console.WriteLine("Выбирите корректный вариант");
            adm();
        }
    }
    public void admadd()
    {

    }
    public void admrem()
    {

    }
    public void TestList()
    {
        using(var admListAlgebra = new StreamReader(admpath + admlist))
        {
            string linel;
            while ((linel = admListAlgebra.ReadLine()) != null)
            { 
                Console.WriteLine(linel);
            }
        }
        adm();
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