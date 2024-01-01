using Microsoft.Playwright;
using PlaywrightTests;

public class AllBooksPage : BasePage
{  
    public AllBooksPage(IPage page): base(page){}
    public async ValueTask<string> GetBookName(int index)
    {
        await WaitingLoad();
        return await Page.Locator(Locators.Allbookspage.bookname).Nth(index).InnerTextAsync();
    }
    public async ValueTask<string> GetBookAutor(int index)
    {
        await WaitingLoad();
        return await Page.Locator(Locators.Allbookspage.bookautor).Nth(index).InnerTextAsync();
    }
    public async ValueTask<int> Count()
    {
        await WaitingLoad();
        return await Page.Locator(Locators.Allbookspage.books).CountAsync();
    }

}