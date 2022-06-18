namespace ProducerConsumer;


public class Program
{
    public static void Main()
    {
        Producer pr = new Producer();
        ProductManager pm = new ProductManager(pr);
        Consumer consumer = new Consumer(pm);
        Task.Run(()=> consumer.TakeProduct());
        Console.ReadKey();
    }
}



