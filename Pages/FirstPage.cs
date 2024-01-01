using Microsoft.Playwright;
using PlaywrightTests;

public class FirstPage : BasePage
{  
    public FirstPage(IPage page): base(page){}
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