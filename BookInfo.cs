//класс данных книги
public class BookAll
{
        public int? Book_id { get; set; }
        public BookInfo? bookInfo {get; set;}
}

public class BookInfo
{

        public string? Book_name { get; set; }
        public string? Book_autor { get; set; }
        public string? Book_download_path { get; set; }
        
}