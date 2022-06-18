namespace ProducerConsumer
{
    public class Consumer
    {
        private List<Product> _products;
        private Producer _producer;
        public Consumer(ProductManager pm)
        {
            _producer = pm.TakeProducer();
            pm.NewProduct += NewProductMsg;
            _products = new List<Product>();
        }

        private void NewProductMsg(Object sender, NewProductEventArgs e)
        {
            Console.WriteLine("Product added");
            Console.WriteLine(" Id = {0}", e.ProductId);
        }

        public void Unregister(ProductManager pm)
        {
            pm.NewProduct -= NewProductMsg;
        }

        public void TakeProduct()
        {
            while (true)
                foreach (var a in _producer.BuyProduct(1))
                {
                    if (_products.Count == 5)
                    {
                        Console.WriteLine("Всё, дохавал");
                        return;
                    }
                    _products.Add(a);
                    Console.WriteLine("Схавал " + a.Id.ToString() + ". Осталось " + (5 - _products.Count).ToString());
                }
        }
    }
}
