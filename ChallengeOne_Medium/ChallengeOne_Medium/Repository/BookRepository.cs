using ChallengeOne_Medium.Model;
using System.Collections.Generic; // Importante para usar List<Book>
using System.Linq;

namespace ChallengeOne_Medium.Repository
{
    internal class BookRepository : IBookRepository
    {
        
        public static List<Book> _bookList = new List<Book>();        
        public static int _id = 1;

        public Book Create(Book book) // Atribui um ID único ao livro e adiciona-o à lista.
        {
            book.Id = _id++; // Atribui o ID e incrementa para o próximo livro.
            _bookList.Add(book); // Adiciona o livro à lista.
            return book;
        }

        // Implementação d método Retrieve da interface IBookRepository
        public Book Retrieve(int id)
        {
            // Procura um livro na lista com o ID especificado.  FirstOrDefault retorna null se não encontrar.
            return _bookList.FirstOrDefault(b => b.Id == id);
        }
        // Implementação do método RetrieveAll da interface IBookRepository
        public List<Book> RetrieveAll()
        {
            return _bookList; // Retorna a lista completa de livros.
        }

        public Book Update(Book book)
        {
            // Procura o livro na lista pelo ID.
            Book existingBook = _bookList.FirstOrDefault(b => b.Id == book.Id);
            if(existingBook != null)
            {
                // Atualiza as propriedades do livro existente.
                existingBook.Title = book.Title;
                existingBook.IsBn = book.IsBn;
                existingBook.Description = book.Description;
                return existingBook;
            }
            return null;
            // Se o livro não for encontrado, podemos lançar uma exceção ou fazer outra coisa, dependendo dos requisitos.
        }

        public void Delete(int id)
        {
            _bookList.RemoveAll(b => b.Id == id);
        }
       
    }
}
