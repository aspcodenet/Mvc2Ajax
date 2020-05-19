using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Mvc2Ajax.Models;

namespace Mvc2Ajax.Services
{
    class PlayerRepository : IPlayerRepository
    {
        private static List<Player> _players = new List<Player>();
        public PlayerRepository()
        {
            if(_players.Count() == 0)
                for (var i = 0; i < 100; i++)
                    _players.Add(new Player{Id = Guid.NewGuid(),JerseyNumber = i, Name = "Player"+i,Position = "dsd"});
        }

        public IEnumerable<Player> GetAll()
        {
            return _players;
        }

        public IEnumerable<Player> GetFrom(int startPos = 0)
        {
            return _players.Skip(startPos).Take(20);
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