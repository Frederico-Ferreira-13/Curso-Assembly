//Aqui temos o nome da classe do serviço, sem os : que indica, neste caso,
//que é uma implementação da interface lembrando que os : também servem pra hierarquia
using System.Runtime.InteropServices;
using ChallengeOne_Medium.Model;

internal class BookService : IBookService
{
    //para esta classe funcionar eu preciso guardar os dados depois de os verificar
    //então preciso instanciar um repositorio, atenção ao tipo o objeto
    //IMyObjectRepository, o que indica que a classe de serviço está interessada em
    //classes que sabem fazer o que a interface declara mas não está interessada em como é feito
    //Aqui temos um ótimo exemplo dos 4 pilares de OOP ao mesmo tempo
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public Book Create(Book book)
    {
       return _bookRepository.Create(book);
        
    }

    public Book Retrieve(int id)
    {
       return _bookRepository.Retrieve(id);
    }

    public List<Book> RetrieveAll()
    {
        return _bookRepository.RetrieveAll();
    }

    public Book Update(Book book)
    {
       return _bookRepository.Update(book);
    }

    public void Delete(int id)
    {
        _bookRepository.Delete(id);
    }

}