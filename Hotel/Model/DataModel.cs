﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitizenDevelopment.Model
{
    public class DataModel
    {
        public int Id { get; set; }
        public string ApplicationName { get; set; }
        public string UserName { get; set; }
        public string Comment { get; set; }

        /*private readonly List<DataModel> _hotels;

        public DataModel()
        {
            _hotels = new List<DataModel>();
        }

        public IEnumerable<DataModel> GetHotels()
        {
            return _hotels;
        }*/
    }
}
