using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using PlaywrightTests;
using Newtonsoft.Json;
using System.Text.Json;
namespace Libra;
using Newtonsoft.Json;
using System.IO;
using System;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

public class Tests : BaseTest
{
    [Test]
    public async Task GetInfo()
    {
        NUnit.Framework.TestContext.Progress.WriteLine("Начало работы программы");
        FirstPage firstpage = new FirstPage(Page);
        AllBooksPage allbooks = new AllBooksPage(Page);
        //Переход на страницу всех книг
        await firstpage.GoToAllBooksPage();
        //Запуск цикла проверки книг
        




        int count_page_books = await allbooks.Count();
        for (int page = 1; page < 10; page++)
        {
            NUnit.Framework.TestContext.Progress.WriteLine($"Проверка {page} страницы");
            for (int i = 0; i < count_page_books; i++)
            {
                //получение названия и автора книги
                NUnit.Framework.TestContext.Progress.WriteLine($"Проверка {i + 1} книги");
                string book_name = await allbooks.GetBookName(i);
                int book_index = i;
                NUnit.Framework.TestContext.Progress.WriteLine($"Индекс книги - {book_index}");
                NUnit.Framework.TestContext.Progress.WriteLine($"Название книги - {book_name}");
                string book_autor = await allbooks.GetBookAutor(i);
                NUnit.Framework.TestContext.Progress.WriteLine($"Имя автора книги - {book_autor}");
                
                //путь к БД
                string path = @"..\\..\\..\\Libra_Data.json";

                List<BookAll> jsonRead = new();
                using (StreamReader sr = new StreamReader(path, true))
                {
                    var jsonReadNew = JsonConvert.DeserializeObject<List<BookAll>>(File.ReadAllText(path));
                    NUnit.Framework.TestContext.Progress.WriteLine($"Форматировали json (DeserializeObject) {jsonReadNew}");
                    if(jsonReadNew != null)
                    {
                        NUnit.Framework.TestContext.Progress.WriteLine($"Json не пуст");
                        jsonRead = jsonReadNew;
                        jsonRead.Add(new()
                        {
                            Book_id =i,
                            bookInfo = new()
                            {
                                Book_name = book_name,
                                Book_autor = book_autor
                            }
                        });
                    }
                    else
                    {
                        NUnit.Framework.TestContext.Progress.WriteLine($"Json пусть");
                        jsonRead = new()
                        {
                            new()
                            {
                                Book_id = i,
                                bookInfo = new()
                                {
                                    Book_name = book_name,
                                    Book_autor = book_autor
                                }
                            }

                        };
                    } 
                }                
                // string jsonoutput = JsonConvert.SerializeObject(jsonRead);
                // NUnit.Framework.TestContext.Progress.WriteLine($"Сформировали запись json - {jsonoutput}");
                using (StreamWriter file = File.CreateText(path))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    //serialize object directly into file stream
                    serializer.Serialize(file, jsonRead);
                    NUnit.Framework.TestContext.Progress.WriteLine($"Записали json");
                }
            }           
            await Page.Locator(Locators.Allbookspage.page.Replace("$",Convert.ToString(page + 1))).ClickAsync();
        }             
    }
    }
