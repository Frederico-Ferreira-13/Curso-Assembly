using ChallengeOne_Medium.Model;

//Nesta interface vamos ter apenas as declaracoes do que precisa ser feito a nível de serviço,
//Os métodos não tem implementação, ou seja, não tem recheio / corpo.

//Por 'a nível de serviço', digo regras de negócio,
//se podemos realizar a criacao de um novo produto sem preço, por exemplo.
//Na implementação do método create há de ter uma verificação se o produto tem preço antes de o armazenar
internal interface IBookService
{
    //Aqui, apesar de não estarmos na camada de repositorio, vamos ter os mesmos métodos que temos lá.
    //Isto só acontece agora porque não temos um software complexo,
    //mas nos deixa com uma estrutura mais adequada

    //Sim, eu percebo que há uma redundancia entre as interfaces do service e do repository
    //Pra já, é isso mesmo.

    Book Create(Book book);
    Book Retrieve(int id);
    List<Book> RetrieveAll();
    Book Update(Book book);
    void Delete(int id);
}