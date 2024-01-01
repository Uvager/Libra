using System.Drawing;
using System.Threading.Tasks;
using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
namespace PlaywrightTests;

//Класс базовой страницы
public class BasePage
{
    string url = "https://avidreaders.ru/";
    public IPage Page {get;set;}
    public BasePage(IPage page)
    {
        Page = page;
    }
    //Метод перехода на сайт с выбором московского региона
    public async ValueTask GoUrl()
    {
        await WaitingLoad();
        await Page.GotoAsync(url);
        NUnit.Framework.TestContext.Progress.WriteLine("Переход на сайт");
    }
    //Метод получения случайного числа
    public int RandomThing(int minValue, int maxValue)
    {
        return new Random().Next(minValue, maxValue);
    }
    //Метод получения числа из текста
    public int FindNumber(string n)
    {
        return Convert.ToInt32(Regex.Match(n, @"\d+").Value);
    }
    //Метод ожидания прогрузки страницы
    private protected async ValueTask WaitingLoad()
    {
        await Page.WaitForTimeoutAsync(800);
        await Page.WaitForLoadStateAsync(LoadState.Load);
        await Page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
    }
    //Очистка allure результатов 
        public static bool AllureFilesClean(string path)
        {
            try
            {
                if (String.IsNullOrEmpty(path))
                    return false;
                // список файлов
                string[] files = Directory.GetFiles(path);
                if (files.Length == 0)
                    return true;
                return true;
            }
            catch(Exception ex)
            {
                NUnit.Framework.TestContext.Progress.WriteLine($"\nОшибка в процессе удаления Allure отчетов по пути {path} !!!" +
                    $"\nERR: {ex.Message}");
                return false;
            }
        }
}