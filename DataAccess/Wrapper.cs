using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    //a class that wraps all data in the JSON we get
    public class Wrapper<T>
    {
        public List<T> data { get; set; }
        public long timestamp { get; set; }
    }
}
