using System.Data;
using Microsoft.Data.SqlClient;

public class BookRepository
{
    private readonly string _connectionString;

    public BookRepository(IConfiguration config)
    {
        _connectionString = config.GetConnectionString("DefaultConnection");
    }

    // User Story 1 + 5: Connected - SqlDataReader
    public List<Book> GetAllBooksReader()
    {
        var books = new List<Book>();
        using SqlConnection con = new(_connectionString);
        // User Story 2: Parameterized query - SQL Injection safe
        string query = "SELECT BookId, Title, Author, Price, ISBN, PublishedDate FROM Books";
        using SqlCommand cmd = new(query, con);
        con.Open();
        using SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            books.Add(new Book
            {
                BookId = reader.GetInt32("BookId"),
                Title = reader.GetString("Title"),
                Author = reader.GetString("Author"),
                Price = reader.GetDecimal("Price"),
                ISBN = reader.GetString("ISBN"),
                PublishedDate = reader.GetDateTime("PublishedDate")
            });
        }
        return books;
    }

    // User Story 3: Stored Procedure Call
    public void AddBookSP(Book book)
    {
        using SqlConnection con = new(_connectionString);
        using SqlCommand cmd = new("sp_AddBook", con);
        cmd.CommandType = CommandType.StoredProcedure;
        // User Story 2: Parameterized - prevents SQL injection
        cmd.Parameters.AddWithValue("@Title", book.Title);
        cmd.Parameters.AddWithValue("@Author", book.Author);
        cmd.Parameters.AddWithValue("@Price", book.Price);
        cmd.Parameters.AddWithValue("@ISBN", book.ISBN);
        cmd.Parameters.AddWithValue("@PublishedDate", book.PublishedDate);
        con.Open();
        cmd.ExecuteNonQuery();
    }

    public void UpdateBookSP(Book book)
    {
        using SqlConnection con = new(_connectionString);
        using SqlCommand cmd = new("sp_UpdateBook", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@BookId", book.BookId);
        cmd.Parameters.AddWithValue("@Title", book.Title);
        cmd.Parameters.AddWithValue("@Author", book.Author);
        cmd.Parameters.AddWithValue("@Price", book.Price);
        cmd.Parameters.AddWithValue("@ISBN", book.ISBN);
        cmd.Parameters.AddWithValue("@PublishedDate", book.PublishedDate);
        con.Open();
        cmd.ExecuteNonQuery();
    }

    public void DeleteBookSP(int bookId)
    {
        using SqlConnection con = new(_connectionString);
        using SqlCommand cmd = new("sp_DeleteBook", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@BookId", bookId);
        con.Open();
        cmd.ExecuteNonQuery();
    }

    // User Story 4 + 5: Disconnected - DataSet, DataTable, SqlDataAdapter
    public DataSet GetBooksDataSet()
    {
        using SqlConnection con = new(_connectionString);
        string query = "SELECT * FROM Books";
        SqlDataAdapter da = new(query, con);
        DataSet ds = new();
        da.Fill(ds, "Books"); // Fills DataSet
        return ds;
    }

    public void UpdateFromDataSet(DataSet ds)
    {
        using SqlConnection con = new(_connectionString);
        string query = "SELECT * FROM Books";
        SqlDataAdapter da = new(query, con);
        SqlCommandBuilder builder = new(da); // Auto generates Insert/Update/Delete
        da.Update(ds, "Books"); // Updates DB with DataSet changes
    }
}