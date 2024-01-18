using System.Linq;
using Newtonsoft.Json;

public class BookHandler
{
    //public string path = @"..\\..\\..\\Libra_Data.json";
    // public void HandlerGetBook(List<BookAll> allBoks)
    // {
    //     Console.WriteLine("Выберите параметры для поиска книги/n1 - поиск по названию/n2 - поиск по автору/n3 - поиск по Id/n4 - общий поиск/n5 - отмена поиска");
    //     public int handlerchoise = Convert.ToInt32(Console.ReadLine());
    //     switch (handlerchoise)
    //     {
    //         case 1:
    //         Console.WriteLine("Введите название");
    //         string handlerbookname = Console.ReadLine();
    //         //foreach ( var handlerbookname in allBoks.Book_name)
    //         case 2:
    //         Console.WriteLine("Введите автора");
    //         string handlerbookautor = Console.ReadLine();
    //         case 3:
    //         Console.WriteLine("Введите id");
    //         int handlerbookid = Convert.ToInt32(Console.ReadLine());
    //         case 4:
    //         Console.WriteLine("Введите данные");
    //         var handlerbookdata = Console.ReadLine();
    //         case 5:
    //         Console.WriteLine("Отмена поиска");
    //         break;


    // }

    // Получение книги по названию
    public BookAll GetBookByName(List<BookAll> allBoks, string ss)
    {       
        NUnit.Framework.TestContext.Progress.WriteLine("Введите название");
        var s = (from book in allBoks 
                    where book.bookInfo.Book_name == ss 
                    select book).First(); 
        return s;
    }
    // Получение книги по автору
    public BookAll GetBookById(List<BookAll> allBoks, string ss)
    {       
        NUnit.Framework.TestContext.Progress.WriteLine("Введите автора");
        var s = (from book in allBoks 
                    where book.bookInfo.Book_autor == ss 
                    select book).First(); 
        return s;
    }
        

    // public string GetBookById(List<BookAll> allBoks)
    // {
    //     Console.WriteLine("Введите id");
    //     var handlerbookid = Convert.ToInt32(Console.ReadLine());
    //     // foreach ( handlerbookname in allBoks)
    //     // if (allBoks.Contains(handlerbookname))
        
    //     using (StreamReader sr = new StreamReader(path, true))
    //     {
    //         var jsonReadHandl = JsonConvert.DeserializeObject<List<BookAll>>(File.ReadAllText(path));
    //         if (jsonReadHandl.Contains(handlerbookname))
    //     }
    //     return jsonReadHandl;
    // }
    
}
