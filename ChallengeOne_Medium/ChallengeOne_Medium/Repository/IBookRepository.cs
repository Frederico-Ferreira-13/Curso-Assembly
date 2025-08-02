using ChallengeOne_Medium.Model;

.
internal interface IBookRepository
{
    Book Create(Book book);
    Book Retrieve(int id);
    List<Book> RetrieveAll();
    Book Update(Book book);
    void Delete(int id);
}