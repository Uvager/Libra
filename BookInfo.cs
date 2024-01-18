//класс данных книги
public class BookAll
{
        public int Book_id { get; set; }
        public required BookInfo bookInfo {get; set;}
}

public class BookInfo
{

        public required string Book_name { get; set; }
        public required string Book_autor { get; set; }
        public required string Book_download_path { get; set; }
        
}