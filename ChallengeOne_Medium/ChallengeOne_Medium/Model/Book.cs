namespace ChallengeOne_Medium.Model
{   
    internal class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IsBn { get; set; }

        //Implementamos o método ToString para podermos imprimir uma instância de MyObject
        //usando o método WriteLine() da constante Console;
        override
        public string ToString()
        {
            //o caractere de escape \t é o equivalente a um 'Tab'
            return "ID:\t" + Id + "\tTitle:\t" + Title + "\tDescription:\t" + Description + "\tIs Book Name:\t" + IsBn;
        }


        //Os métodos Equals e Hashcode são usados para definir o conceito de 'igual' que pode
        //usado no método Delete do Repositório se usarmos List
        //Deixe-o assim pra já
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
