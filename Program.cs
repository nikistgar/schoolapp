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
    private string lessonWhichadm;
    private string adm_func;
    private string Testnameadd;
    private string Testnameremove;
    private string admpath;
    private string admlist;
    private string admlesson;
    private string finaltestname;
    private string admedit;
    private string admeditq;
    private string pass = "769151";
    private string testselfinal;
    private int admlinecount;
    private int testsel;
    private int tempsel;
    public void Getpath()
    {
        path = Path.GetFullPath(".");
    }
    public void Directorieswf()
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
        if (!File.Exists(path + "\\Answers.txt"))
        {
            using (var anscr = new StreamWriter(path + "\\Answers.txt", true, Encoding.UTF8))
            {

            }
        }
        if (!File.Exists(path + "\\Algebra\\Algebra_list.txt"))
        {
            using (var algcr = new StreamWriter(path + "\\Algebra\\Algebra_list.txt", true, Encoding.UTF8))
            {

            }
        }
        if (!File.Exists(path + "\\Geometry\\Algebra_list.txt"))
        {
            using (var geocr = new StreamWriter(path + "\\Geometry\\Geometry_list.txt", true, Encoding.UTF8))
            {

            }
        }
    }
    public void Line_delete(string filen, string rstr)
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
    public void Testcount()
    {
        admlinecount = 1;
        using (var admListcount = new StreamReader(admpath + admlist))
        {
            while (admListcount.ReadLine() != null)
            {
                admlinecount++;
            }
        }
    }
    public void Testselection(string test)
    {
        using (var testselection = new StreamReader(admpath + admlist))
        {
            testsel = Convert.ToInt32(test);
            for (int i = 0; i < testsel; i++)
            {
                testselfinal = testselection.ReadLine();
            }
            Console.WriteLine("Выбран тест: " + testselfinal);
        }
    }
    public void Testselectionq()
    {

    }
    public void Testquestionsanswersview()
    {
        try
        {
            using (var testedit1 = new StreamReader(admpath + "\\" + testselfinal + ".txt"))
            using (var testedit2 = new StreamReader(admpath + "\\" + testselfinal + " - Ответы.txt"))
            {
                string linee1;
                string linee2;
                while ((linee1 = testedit1.ReadLine()) != null)
                {
                    int tempv = 1;
                    linee2 = testedit2.ReadLine();
                    Console.Write(tempv + ". " + linee1 + " - ");
                    Console.WriteLine(linee2);
                    tempv++;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    public void Introduction()
    {
        Console.WriteLine("Programm created by Nikist,Asembly,Luci \n" +
                          "Для уроков алгебры/геометрии Ишмурзины Елены Рашидовны");
    }
    public void Introduce()
    {
        Console.WriteLine("Введите свои данные одной строкой в формате Фамилия | Имя | Класс");
        try
        {
            using (var student = new StreamWriter(path + "\\Answers.txt", true, Encoding.UTF8 ))
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
    public void Select_lessonType()
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
            Select_lessonType();
        }
    }
    public void Pass_check()
    {
        if (lessonWhich == "3")
        {
            Console.WriteLine("Вход в режим редактирования");
            Admwhich();
        }
        else if (lessonWhich == "1" | lessonWhich ==  "2")
        {
            Select_lessonNum();
        }
    }
    public void Admwhich()
    {
        Console.WriteLine("Выбирите нужный предмет для изменений (Введите соответствующую цифру):\n" +
                              "1 - Алгебра\n" +
                              "2 - Геометрия");
        admlesson = Console.ReadLine();
        if (admlesson == "1")
        {
            lessonWhichadm = "1";
            Admlessoncheck();
        }
        else if (admlesson == "2")
        {
            lessonWhichadm = "2";
            Admlessoncheck();
        }
        else
        {
            Console.WriteLine("Выбирите корректный вариант");
            Admwhich();
        }
    }
    public void Admlessoncheck()
    {
        if (lessonWhichadm == "1")
        {
            admpath = path + "\\Algebra";
            admlist = "\\Algebra_list.txt";
            Adm();
        }
        else if(lessonWhichadm == "2")
        {
            admpath = path + "\\Geometry";
            admlist = "\\Geometry_list.txt";
            Adm();
        }
    }
    public void Adm()
    {
        Console.WriteLine("Выбирите нужную функцию(Введите соответствующую цифру):\n" +
                          "1 - Добавить тест\n" +
                          "2 - Удалить тест\n" +
                          "3 - Просмотр теста и редактирование теста\n" +
                          "4 - Вывести список текущих тестов\n" +
                          "5 - К выбору предметов\n" +
                          "0 - Выйти из режима редактирования");
        adm_func = Console.ReadLine();
        if (adm_func == "1")
        {
            Admadd();
        }
        else if(adm_func == "2")
        {
            Admrem();
        }
        else if(adm_func == "3")
        {
            Testviewedit();
        }
        else if(adm_func == "4")
        {
            TestList();
            Console.WriteLine("");
            Adm();
        }
        else if (adm_func == "5")
        {
            Admwhich();
        }
        else if(adm_func == "0")
        {
            Select_lessonType();
        }
        else
        {
            Console.WriteLine("Выбирите корректный вариант");
            Adm();
        }
    }
    public void Admadd()
    {
        Testcount();
        Console.WriteLine("Введите название нового теста");
        Testnameadd = Console.ReadLine();
        finaltestname = admlinecount + " - " + Testnameadd;
        using (var admadd = new StreamWriter(admpath + admlist,true,Encoding.UTF8))
        {
            try
            {
                admadd.WriteLine(finaltestname);
                File.Create(admpath + "\\" + finaltestname + ".txt").Close();
                File.Create(admpath + "\\" + finaltestname + " - Ответы.txt").Close();
                Console.WriteLine("Тест успешно создан");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Попробуйте ещё раз");
            }
        }
        Adm();
    }
    public void Admrem()
    {

    }
    public void Testviewedit()
    {
        Console.WriteLine("Выберите нужный тест");
        TestList();
        admedit = Console.ReadLine();
        Testselection(admedit);
        Testquestionsanswersview();
        Console.WriteLine("Выберите вопрос для редактирования");
        admeditq = Console.ReadLine();
        
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
    }
    public void Select_lessonNum()
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
            Console.OutputEncoding = Encoding.GetEncoding(1251);
            Console.InputEncoding = Encoding.GetEncoding(1251);
            Global lessons = new Global();
            lessons.Getpath();
            lessons.Directorieswf();
            lessons.Introduction();
            lessons.Introduce();
            lessons.Select_lessonType();
            lessons.Pass_check();
            Console.ReadKey();
            return(0);
        }
    }
}