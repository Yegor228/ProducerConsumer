namespace ProducerConsumer
{
    public class Producer
    {
        private Product[] _stock;
        private int _state;

        public Producer()
        {
            _stock = new Product[3];
            _state = 0;

        }

        public int TakeState() => _state;


        public Product? PassiveCreateProduct()
        {
            if( _state < _stock.Length )
            {
                Product product = new Product();
                _stock[_state] = product;
                _state++;
                return product;
            }
            return null;
        }

        public Product[] GetStock() => _stock;

        public IEnumerable<Product> BuyProduct(int count)
        {
            if(count < _state)
            {
                _state -= count;
                for (int i = 0; i < count; i++)
                {
                    var tmp = _stock[_state];
                    _state--;
                    yield return tmp;
                }
            }
        }
    }
}
