using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc2Ajax.ViewModels
{
    public class PlayerListViewModel
    {
        public List<PlayerViewModel> Players { get; set; } = new List<PlayerViewModel>();

        public class PlayerViewModel
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public int JerseyNumber  { get; set; }
            public string Position { get; set; }
            public string ImageUrl { get; set; }

            public int Goals { get; set; }
            public int Assists { get; set; }
        }


        public string Team { get; set; }
    }
}
