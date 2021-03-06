﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mvc2Ajax.Models;
using Mvc2Ajax.Services;
using Mvc2Ajax.ViewModels;

namespace Mvc2Ajax.Controllers
{
    [Route("api/player")]
    [ApiController]
    [Authorize(AuthenticationSchemes =
        JwtBearerDefaults.AuthenticationScheme)]
    public class PlayerApiController : ControllerBase
    {
        private readonly IPlayerRepository _repository;

        #region better

        [HttpGet]
        public IActionResult Get()
        {
            var user = User;
            return Ok(_repository.GetAll().Select(PlayerToPlayerDto));
        }

        //api/player/123
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            var player = _repository.GetAll().Where(r => r.Id == Guid.Parse(id)).Select(PlayerToPlayerDto).FirstOrDefault();
            if (player == null) return NotFound();
            return Ok(player);
        }



        [HttpPost]
        public IActionResult Create( [FromBody] PlayerApiCreationDto model)
        {
            var player = new Player
            {
                Id = Guid.NewGuid(),
                JerseyNumber = model.JerseyNumber,
                Name = model.Name,
                Position = model.Position
            };
            _repository.Add(player);
            return CreatedAtAction("Get", new {player.Id}, player);
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] PlayerApiUpdateDto model)
        {
            var player = _repository.GetAll().FirstOrDefault(r => r.Id == Guid.Parse(id));
            if (player == null) return NotFound();

            player.JerseyNumber = model.JerseyNumber;
            player.Name = model.Name;
            player.Position = model.Position;
            //    ...Save etc etc 


            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var player = _repository.GetAll().FirstOrDefault(r => r.Id == Guid.Parse(id));
            if (player == null) return NotFound();
            //delete from db
            return NoContent();
        }



        #endregion

        #region "bad"
        //[HttpGet]
        //public JsonResult Get()
        //{
        //    return new JsonResult(_repository.GetAll().Select(PlayerToPlayerDto));
        //}

        //[HttpGet]
        //public JsonResult GetId(string id)
        //{
        //    var player = _repository.GetAll().Where(r => r.Id == Guid.Parse(id)).Select(PlayerToPlayerDto).FirstOrDefault();
        //    var res = new JsonResult(player);
        //    if (player == null)
        //        res.StatusCode = 404;

        //    return res;
        //}

        #endregion

        public PlayerApiController(IPlayerRepository repository)
        {
            _repository = repository;
        }



        private PlayerApiDto PlayerToPlayerDto(Player arg)
        {
            return new PlayerApiDto
            {
                Id = arg.Id,
                JerseyNumber = arg.JerseyNumber,
                Name = arg.Name,
                Position = arg.Position
            };
        }
    }
}
