using Microsoft.Playwright;
using PlaywrightTests;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
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
    /// <summary>
    /// Метод получения информации о книгиу
    /// </summary>
    /// <param name="i"></param>
    /// <returns>Индекс, название, автор книги</returns>
    public async ValueTask<(string, string)> GetBookInfo(int i)
    {
        NUnit.Framework.TestContext.Progress.WriteLine($"Проверка {i + 1} книги");
        string book_name = await GetBookName(i);
        int book_index = i;
        NUnit.Framework.TestContext.Progress.WriteLine($"Индекс книги - {book_index}");
        NUnit.Framework.TestContext.Progress.WriteLine($"Название книги - {book_name}");
        string book_autor = await GetBookAutor(i);
        NUnit.Framework.TestContext.Progress.WriteLine($"Имя автора книги - {book_autor}");
        return (book_name, book_autor);
    }
    /// <summary>
    /// Цикл проверки книг
    /// </summary>
    /// <param name="jsonRead"></param>
    /// <param name="book_name_check"></param>
    /// <param name="book_autor_check"></param>
    /// <returns>bool</returns>
    public async ValueTask<bool> BookChek(List<BookAll> jsonRead, string book_name_check, string book_autor_check)
    {
        await Page.WaitForLoadStateAsync();       
        foreach(var jr in jsonRead)
        {
            if(jr.bookInfo != null)
            {
                if(jr.bookInfo.Book_name == book_name_check && jr.bookInfo.Book_autor == book_autor_check)
                    return false;
            }
        }
        return true;
    }
}