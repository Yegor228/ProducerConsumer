using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducerConsumer
{
    public class ProductManager
    {

        public event EventHandler<NewProductEventArgs> NewProduct;
        private Producer _producer;
        private int _state;

        public Producer TakeProducer() => _producer;

        protected void OnNewProduct(NewProductEventArgs e)
        {
            EventHandler<NewProductEventArgs> temp = NewProduct;
            if (temp != null) temp(this, e);
        }

        public ProductManager(Producer producer)
        {
            try
            {
                if (producer == null) 
                    throw new ArgumentNullException();
            }
            catch
            {
                throw;
            }
            _producer = producer;
            Task.Run(() => NewProductState());
        }

        private void NewProductState()
        {
            while(true)
            {
                Thread.Sleep(1000);
                _state = _producer.TakeState();
                Product tmp;
                if (_state < 3)
                {
                    tmp = _producer.PassiveCreateProduct();
                    if(tmp != null)
                    {
                        NewProductEventArgs e = new NewProductEventArgs(tmp);
                        OnNewProduct(e);
                    }        
                }
                _state++;
            }
        }
    }
}
