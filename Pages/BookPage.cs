using Microsoft.Playwright;
using PlaywrightTests;

//класс методов страницы выбранной книги
public class BookPage : BasePage
{  
    public BookPage(IPage page): base(page){}
    /// <summary>
    /// Метод скачивания книги
    /// </summary>
    public async ValueTask<string> BookDownload(int i)
    {   
        string path  = @"..\\..\\..\\BooksDownloaded/";
        await WaitingLoad();
        await Page.Locator(Locators.Allbookspage.books).Nth(i).ClickAsync();
        NUnit.Framework.TestContext.Progress.WriteLine("Переход на страницу книги совершен");
        var waitForDownloadTask = Page.WaitForDownloadAsync();
        await Page.Locator(Locators.Bookpage.bookdownload).Nth(1).ClickAsync();
        var download = await waitForDownloadTask;      
        await download.SaveAsAsync(path + download.SuggestedFilename);
        NUnit.Framework.TestContext.Progress.WriteLine("Скачивание книги совершено");
        await Page.GoBackAsync();
        await Page.GoBackAsync();
        NUnit.Framework.TestContext.Progress.WriteLine("Возврат совершен");
        return download.SuggestedFilename;
    }
}