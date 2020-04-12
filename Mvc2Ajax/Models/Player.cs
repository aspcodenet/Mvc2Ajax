using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc2Ajax.Models
{
    public class Player
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public int JerseyNumber { get; set; }

        public string Position { get; set;  }
    }
}
