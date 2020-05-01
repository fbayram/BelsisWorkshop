using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelsisWorkshop.Api
{
    public class Ticket : ITicket
    {
        public string Adi { get; set; }
        public string Ip { get; set; }
    }

    public interface ITicket
    {
        string Adi { get; set; }
        string Ip { get; set; }
    }
}
