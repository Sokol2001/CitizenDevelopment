using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Model
{
    public class DataModel
    {
        private readonly List<DataModel> _hotels;

        public DataModel()
        {
            _hotels = new List<DataModel>();
        }

        public IEnumerable<DataModel> GetHotels()
        {
            return _hotels;
        }
    }
}
