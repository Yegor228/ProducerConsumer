namespace ProducerConsumer;
public class Product
{
    public int Id { get; set; }


    public Product()
    {
        Random rnd = new Random();

        Id = rnd.Next();
    }
}
