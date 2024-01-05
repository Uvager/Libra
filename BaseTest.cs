using System.Drawing;
using System.Threading.Tasks;
using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[assembly:Parallelizable(ParallelScope.All)]
[assembly:LevelOfParallelism(4)]

namespace PlaywrightTests;

[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class BaseTest : PageTest
{
    //Индекс последней скачанной книги
    public static int count_book = 0;
    
    [OneTimeSetUp]
    public static void OneTimeSetUp()
    {
        //Подключение класса работы с json
        JsonActions ja = new JsonActions();
        //Возвращение последнего индекса
        count_book = ja.ReturnLastIndexSaveBooks();
    }

    [OneTimeTearDown]
    public static void OneTimeTearDown() 
    {
    }

    [SetUp]
    public async Task SetUp()
    {
        await Task.Delay(0);
        BasePage page = new BasePage(Page);
        await page.GoUrl();
    }

    [TearDown]
    public async Task TearDown()
    {
        await Task.Delay(0);
    }

}