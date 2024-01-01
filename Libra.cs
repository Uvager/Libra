using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using PlaywrightTests;
using Newtonsoft.Json;
namespace Libra;

public class Tests : BaseTest
{
    [Test]
    public async Task GetInfo()
    {
        NUnit.Framework.TestContext.Progress.WriteLine("Начало работы программы");
        FirstPage firstpage = new FirstPage(Page);
        AllBooksPage allbooks = new AllBooksPage(Page);
        await firstpage.GoToAllBooksPage();
        int count_page_books = await allbooks.Count();

        for (int page = 1; page < 10; page++)
        {
            NUnit.Framework.TestContext.Progress.WriteLine($"Проверка {page} страницы");
            for (int i = 0; i < count_page_books; i++)
            {
                NUnit.Framework.TestContext.Progress.WriteLine($"Проверка {i} книги");
                string book_name = await allbooks.GetBookName(i);
                NUnit.Framework.TestContext.Progress.WriteLine($"Название книги - {book_name}");
                string book_autor = await allbooks.GetBookAutor(i);
                NUnit.Framework.TestContext.Progress.WriteLine($"Имя автора книги - {book_autor}"); 
            }
            
            await Page.Locator(Locators.Allbookspage.page.Replace("$",Convert.ToString(page + 1))).ClickAsync();
        }

        
        
    }
    }
