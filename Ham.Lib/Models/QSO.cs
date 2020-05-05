using Ham.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ham.Lib.Models
{
    public class QSO
    {
        public int ID { get; set; }
        public int ContactID { get; set; }
        public int StationID { get; set; }
        public int CallSignID { get; set; }
        public int FrequencyID { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual CallSign CallSign { get; set; }
        public virtual Station Station { get; set; }
        public virtual Frequency Frequency { get; set; }

    }
}
