public static class Locators
{
    public static class Bookpage
    {

    }
    public static class Firstpage
    {
        public const string bookspage = "//a[text()='Книги']";

    }
    public static class Allbookspage
    {
        public const string newbookschoise = "//div[@class='sort']";
        public const string newbooks = "//li[@class='s-lnk s-list']";
        public const string books = "//div[@class='item_block item full_block']";
        public const string bookname = "//div[@class='book_name']/a";
        public const string bookautor = "//div[@class='item_block item full_block']//*[@class='genre']";
        public const string page = "//ul//li/a[text()='$']";
    }
    
}