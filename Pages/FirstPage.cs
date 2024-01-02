using Microsoft.Playwright;
using PlaywrightTests;

//класс методов главной страницы 
public class FirstPage : BasePage
{  
    public FirstPage(IPage page): base(page){}
    /// <summary>
    /// Метод перехода с главной страницы на страницу 'Книги' с выбором новинок
    /// </summary>
    public async ValueTask GoToAllBooksPage()
    {
        await WaitingLoad();
        await Page.Locator(Locators.Firstpage.bookspage).ClickAsync();
        NUnit.Framework.TestContext.Progress.WriteLine("Переход на страницу 'Книги' совершен");
        await Page.Locator(Locators.Allbookspage.newbookschoise).ClickAsync();
        await Page.Locator(Locators.Allbookspage.newbooks).ClickAsync();
        NUnit.Framework.TestContext.Progress.WriteLine("Выбраны новинки ");

    }

}