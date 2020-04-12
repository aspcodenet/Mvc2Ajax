using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Mvc2Ajax.Models;
using Mvc2Ajax.Services;
using Mvc2Ajax.ViewModels;

namespace Mvc2Ajax.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IWebHostEnvironment _environment;

        public PlayerController(IPlayerRepository playerRepository, IWebHostEnvironment environment)
        {
            _playerRepository = playerRepository;
            _environment = environment;
        }
        public IActionResult Index()
        {
            var viewModel = new PlayerListViewModel();
            viewModel.Players = _playerRepository.GetAll().Select(PlayerToPlayerViewModel).ToList();
            return View(viewModel);
        }

        private PlayerListViewModel.PlayerViewModel PlayerToPlayerViewModel(Player arg)
        {
            return new PlayerListViewModel.PlayerViewModel
            {
                Id = arg.Id,
                JerseyNumber =  arg.JerseyNumber,
                Name =  arg.Name,
                Position = arg.Position,
                ImageUrl = Path.Combine(_environment.ContentRootPath,$"/images/{arg.Id}.jpg")   
            };
        }
    }
}