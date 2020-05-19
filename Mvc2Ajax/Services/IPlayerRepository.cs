using System;
using System.Collections;
using System.Collections.Generic;
using Mvc2Ajax.Models;

namespace Mvc2Ajax.Services
{
    public interface IPlayerRepository
    {
        IEnumerable<Player> GetAll();
        Player Get(Guid id);
        void Add(Player player);
        IEnumerable<Player> GetFrom(int startPos = 0);

    }
}