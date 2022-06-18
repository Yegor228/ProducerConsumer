namespace ProducerConsumer
{
    public class NewProductEventArgs : EventArgs
    { 
        private readonly int t_productId;

        public NewProductEventArgs(Product product)
        {
            t_productId = product.Id;
        }

        public int ProductId => t_productId;
    
    }
}
