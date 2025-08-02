//A classe Program é uma classe como outra qualquer que nós criamos.
//Que pode ter variaveis a nível de classe, portanto, vamos declarar e usar uma.
//Assim não temos que a passar como argumento para os outros métodos que possamos ter.
using System;
using System.Collections.Generic; // Importante para usar List<Book>
using ChallengeOne_Medium.Repository; // Importante para usar o repositório
using ChallengeOne_Medium.Model;


namespace ChallengeOne_Medium
{


    internal class Program
    {
        // A linha abaixo está comendata e não 
        private static void Main(string[] args)
        {

            // 1. Criar uma instância do respositório
            IBookRepository bookRepository = new BookRepository();
            IBookService bookService = new BookService(bookRepository);

            // 2. Criar instância da classe Program
            Program program = new Program(); // Cria uma instância da classe Program para chamar os métodos de instância.

            //Informo ao utilizador o que se esta a passar no software            
            Console.WriteLine("Bemvindo ao software de armazenamento de Livros");
            Console.WriteLine("Por favor, escolha uma opção.");
           
            int option = 0;

            do
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine(" 1 - Adicionar Livro");
                Console.WriteLine("2 - Obter Livro por ID");
                Console.WriteLine("3 - Obter todos os Livros");
                Console.WriteLine("4 - Atualizar Livro");
                Console.WriteLine("5 - Eliminar Livro");
                Console.WriteLine("0 - Sair");
                Console.Write("Opção: ");

                if (int.TryParse(Console.ReadLine(), out option))
                {
                    switch (option)
                    {
                        case 1:
                            program.Create(bookService);
                            break;
                        case 2:
                           program.Retrieve(bookService);
                            break;
                        case 3:
                            program.RetrieveAll(bookService);
                            break;
                        case 4:
                            program.Update(bookService);
                            break;
                        case 5:
                            program.Delete(bookService);
                            break;
                        case 0:
                            Console.WriteLine("Sair do programa.");
                            break;
                        default:
                            if (option != 0)
                            {
                                Console.WriteLine("A opção " + option + " não existe, tente novamente.");
                            }
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, introduza um número inteiro como opção.");
                    option = -1;
                }

                //Enquanto a opção não for 0 ou seja
                //Enquanto o utilizador não quiser sair, o software continua a correr.
            } while (option != 0);

            Console.WriteLine("Obrigado por usar software de armazenamento de Livros.");
        }

        public void Create(IBookService bookService) // alterado de static para instância
        {
            Console.WriteLine("\n--- Adicionar um Livro ----");

            Console.Write("Título: ");
            string title = Console.ReadLine();

            Console.Write("ISBN: ");
            string isbn = Console.ReadLine();

            Console.Write("Description: ");
            string description = Console.ReadLine();

            Book newCreate = new Book
            {
                Title = title,
                IsBn = isbn,
                Description = description
            };

            bookService.Create(newCreate);
            Console.WriteLine("Livro adicionado com sucesso.");

        }

        public void Retrieve(IBookService bookService)
        {
            Console.WriteLine("\nObter Livro por ID:");
            Console.Write("ID do livro: ");

            if(int.TryParse(Console.ReadLine(), out int id))
            {
                Book book = bookService.Retrieve(id);
                if(book != null)
                {
                    Console.WriteLine($"\nDetalhes do Livros com ID {id}:");
                    Console.WriteLine($"Título: {book.Title}");
                    Console.WriteLine($"ISBN: {book.IsBn}");
                    Console.WriteLine($"Descrição: {book.Description}");
                }
                else
                {
                    Console.WriteLine($"Livro com ID {id} não encontrado.");
                }
            }
            else
            {
                Console.WriteLine("ID inválido. Por favor, introduza um número inteiro.");
            }
        }

        public void RetrieveAll(IBookService bookService)
        {
            Console.WriteLine("\nLista de Todos os Livros:");
            List<Book> book = bookService.RetrieveAll();
            if(book.Count > 0)
            {
                foreach(Book books in book)
                {
                    Console.WriteLine($"\nID: {books.Id}, Titulo: {books.Title}, ISBN: {books.IsBn}, Descrição: {books.Description}");

                }
            }
            else
            {
                Console.WriteLine("Não existem livros registados.");
            }
        }

        public void Update(IBookService bookService)
        {
            Console.WriteLine("\nAtualizar Livro:");
            Console.Write("ID do Livro a Atualizar:");
            if(int.TryParse(Console.ReadLine(), out int id))
            {
                Book bookExisting = bookService.Retrieve(id);
                if(bookExisting != null)
                {
                    Console.Write("Novo Título: ");
                    string newTitle = Console.ReadLine();

                    Console.Write("Novo IsBn: ");
                    string newIsbn = Console.ReadLine();

                    Console.Write("Nova Descrição: ");
                    string newDescription = Console.ReadLine();

                    Book actualizeBook = new Book
                    {
                        Id = id,
                        Title = newTitle,
                        IsBn = newIsbn,
                        Description = newDescription
                    };

                    bookService.Update(actualizeBook);
                    Console.WriteLine("Livro atualizado com sucesso!");
                }
                else
                {
                    Console.WriteLine($"Livro com ID {id} não encontrado.");
                }
            }
            else
            {
                Console.WriteLine("ID inválido. Por favor, introduza um número inteiro.");
            }
        }

        public void Delete(IBookService bookService)
        {
            Console.WriteLine("\nApagar Livro");
            Console.Write("ID do livro a Apagar: ");
            if(int.TryParse(Console.ReadLine(), out int id))
            {
                bookService.Delete(id);
                Console.WriteLine("Livro apagado com sucesso.");
            }
            else
            {
                Console.WriteLine("ID inválido. Por favor, introduza um número inteiro.");
            }
        }
    }
}