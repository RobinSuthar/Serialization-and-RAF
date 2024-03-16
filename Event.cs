using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization_and_RAF
{
    [Serializable]
    public class Event
    { 
        //Two attributes
        public int EventNumber { get; set; }
        public string Location { get; set; }



        public Event()
        {

        }

        //For displat the info.
        public override string ToString()
        {
            return 
                $"{EventNumber}" +
                $" {Location}";
        }
    }
}
