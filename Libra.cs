
using PlaywrightTests;

namespace Libra;
public class Tests : BaseTest
{
    [Test]
    public async Task GetInfo()
    {
        NUnit.Framework.TestContext.Progress.WriteLine("Начало работы программы");
        //подключение классов
        FirstPage firstpage = new FirstPage(Page);
        AllBooksPage allbooks = new AllBooksPage(Page);
        JsonActions jsonaction = new JsonActions();
        BookPage book = new BookPage(Page);
        //Переход на страницу всех книг
        await firstpage.GoToAllBooksPage();
        //Получение количества книг
        int count_page_books = await allbooks.Count();
        //Запуск цикла по книгам и страницам
        for (int page = 1; page < 10; page++)
        {
            NUnit.Framework.TestContext.Progress.WriteLine($"Проверка {page} страницы");
            for (int i = 0; i < count_page_books; i++)
            {
                //получение названия и автора книги
                string book_name, book_autor;
                (book_name, book_autor) = await allbooks.GetBookInfo(i);
                //Получение всех книг из БД
                List<BookAll> allBoks = jsonaction.ReturnJsonBooksAll();
                if(!await allbooks.BookChek(allBoks, book_name, book_autor))
                    continue;
                //Обновление счетчика книг
                count_book +=1;
                //Скачиваем книгу
                string pathDownloadFile = await book.BookDownload(i);
                //Добавление новой книги в список
                allBoks = jsonaction.AddNewElement(allBoks, count_book, book_name, book_autor, pathDownloadFile);
                //Записываем в БД
                jsonaction.JsonRead(allBoks);                         
            }
            //Переход на новую страницу           
            await Page.Locator(Locators.Allbookspage.page.Replace("$",Convert.ToString(page + 1))).ClickAsync();
        }           
    }
}
