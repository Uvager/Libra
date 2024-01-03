using Microsoft.Playwright;
using PlaywrightTests;
//класс методов работы со страницой 'Книги'
public class AllBooksPage : BasePage
{  
    public AllBooksPage(IPage page): base(page){}
    /// <summary>
    /// Метод получения названия книги
    /// </summary>
    /// <param name="index"></param>
    /// <returns>Название книги</returns>
    public async ValueTask<string> GetBookName(int index)
    {
        await WaitingLoad();
        return await Page.Locator(Locators.Allbookspage.bookname).Nth(index).InnerTextAsync();
    }
    /// <summary>
    /// Метод получения автора книги
    /// </summary>
    /// <param name="index"></param>
    /// <returns>Имя автора книги</returns>
    public async ValueTask<string> GetBookAutor(int index)
    {
        await WaitingLoad();
        return await Page.Locator(Locators.Allbookspage.bookautor).Nth(index).InnerTextAsync();
    }
    /// <summary>
    /// Метод подсчета колличества книг на странице
    /// </summary>
    /// <returns>Колличество книг на странице</returns>
    public async ValueTask<int> Count()
    {
        await WaitingLoad();
        return await Page.Locator(Locators.Allbookspage.books).CountAsync();
    }
    
    public void BookCheck()
    {

    }

}