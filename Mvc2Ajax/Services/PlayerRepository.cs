using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Mvc2Ajax.Models;

namespace Mvc2Ajax.Services
{
    class PlayerRepository : IPlayerRepository
    {
        private static List<Player> _players = new List<Player>
        {
            new Player
            {
                Id = Guid.Parse("c5962ffe-b877-43c9-a8d1-f2c998ecc3ea"),
                JerseyNumber = 13,
                Name = "Mats Sundin",
                Position = "Forward"
            },
            new Player
            {
                Id = Guid.Parse("b7096dcd-3dff-41e4-99e3-46e27137a0a7"),
                JerseyNumber = 21,
                Name = "Peter Forsberg",
                Position = "Forward"
            },
            new Player
            {
                Id = Guid.Parse("a92acf63-6d69-4f53-8c50-40d446c8b858"),
                JerseyNumber = 5,
                Name = "Niklas Lidström",
                Position = "Back"
            }
        };

        public IEnumerable<Player> GetAll()
        {
            return _players;
        }

        public Player Get(Guid id)
        {
            return GetAll().FirstOrDefault(p=>p.Id == id);
        }

        public void Add(Player player)
        {
            _players.Add(player);
        }
    }
}