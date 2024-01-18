//класс локаторов
public static class Locators
{
    //класс локаторов станицы отдельной книги
    public static class Bookpage
    {
        //локатор кнопки сказивания (для избежания конфликтов использовать Nth(1))
        public const string bookdownload = "//a[@class = 'btn']";
        public const string returntomain = "";
    }
    //класс локаторов главной страницы
    public static class Firstpage
    {
        //локатор перехода на страницу 'Книги'
        public const string bookspage = "//a[text()='Книги']";

    }
    //класс локаторов страницы 'Книги'
    public static class Allbookspage
    {
        //локатор выбора фильтрации книг
        public const string newbookschoise = "//div[@class='sort']";
        //локатор фильтрации книг по новизне 
        public const string newbooks = "//li[@class='s-lnk s-list']";
        //локатор страницы с книгой
        public const string books = "//div[@class='item_block item full_block']";
        //локатор названия книги
        public const string bookname = "//div[@class='book_name']/a";
        //локатор автора книги
        public const string bookautor = "//div[@class='item_block item full_block']//*[@class='genre']";
        //локатор страниц с книгами
        public const string page = "//ul//li/a[text()='$']";
    }
    
}