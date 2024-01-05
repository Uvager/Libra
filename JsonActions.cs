using Newtonsoft.Json;
using System.IO;

//класс работы с json
public class JsonActions 
{
    //Расположение БД
    string path = @"..\\..\\..\\Libra_Data.json";
    /// <summary>
    /// Метод возвращения индекса последней скачанной книги
    /// </summary>
    /// <returns></returns>
    public int ReturnLastIndexSaveBooks()
    {
        using (StreamReader sr = new StreamReader(path, true))
        {
            var jsonReadNew = JsonConvert.DeserializeObject<List<BookAll>>(File.ReadAllText(path));
            if(jsonReadNew !=null)
                return jsonReadNew.Last().Book_id;
            else
                return 0;
        }
    }
    /// <summary>
    /// Метод возвращения информации о книгах
    /// </summary>
    /// <returns>jsonRead</returns>
    public List<BookAll> ReturnJsonBooksAll()
    {
        List<BookAll> jsonRead = new();
        using (StreamReader sr = new StreamReader(path, true))
        {
            var jsonReadNew = JsonConvert.DeserializeObject<List<BookAll>>(File.ReadAllText(path));
            if(jsonReadNew != null)
                jsonRead = jsonReadNew;
        }
        return jsonRead;
    }
    /// <summary>
    /// Добавление нового элемента 
    /// </summary>
    /// <param name="jsonReadNew"></param>
    /// <param name="i"></param>
    /// <param name="book_name"></param>
    /// <param name="book_autor"></param>
    /// <param name="path"></param>
    /// <returns>jsonReadNew</returns>
    public List<BookAll> AddNewElement(List<BookAll> jsonReadNew, int i, string book_name, string book_autor, string path)
    {
        NUnit.Framework.TestContext.Progress.WriteLine($"Количество книг в полученном списке {jsonReadNew.Count}");
        if(jsonReadNew != null)
        {
            NUnit.Framework.TestContext.Progress.WriteLine($"Json не пуст");
            jsonReadNew.Add(new()
            {
                Book_id = i,
                bookInfo = new()
                {
                    Book_name = book_name,
                    Book_autor = book_autor,
                    Book_download_path = Directory.GetCurrentDirectory() + path
                }
            });
        }
        else
        {
            NUnit.Framework.TestContext.Progress.WriteLine($"Json пусть");
            jsonReadNew = new()
            {
                new()
                {
                    Book_id = i,
                    bookInfo = new()
                    {
                        Book_name = book_name,
                        Book_autor = book_autor,
                        Book_download_path = Directory.GetCurrentDirectory() + path
                    }
                }

            };
        }
        return jsonReadNew;
    }
    /// <summary>
    /// Запись Json
    /// </summary>
    /// <param name="jsonRead"></param>
    public void JsonRead(List<BookAll> jsonRead)
    {
        
         using (StreamWriter file = File.CreateText(path))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, jsonRead);
            NUnit.Framework.TestContext.Progress.WriteLine($"Записали json");
        }

    }
}