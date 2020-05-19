using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Mvc2Ajax.Models;
using Mvc2Ajax.Services;
using Mvc2Ajax.ViewModels;

namespace Mvc2Ajax.Controllers
{
    public class KnockoutController : Controller
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IWebHostEnvironment _environment;

        public KnockoutController(IPlayerRepository playerRepository, IWebHostEnvironment environment)
        {
            _playerRepository = playerRepository;
            _environment = environment;
        }
        // GET
        public IActionResult Index()
        {
            var model = _playerRepository.GetAll().Select(r => new PlayerListViewModel.PlayerViewModel
            {
                Id = r.Id,
                Assists = 40,
                Goals = 51,
                ImageUrl = Path.Combine(_environment.ContentRootPath, $"/images/{r.Id}.jpg"),
                JerseyNumber = r.JerseyNumber,
                Name = r.Name,
                Position = r.Position

            }).First();
            return View(model);
        }


        public IActionResult KnockoutList()
        {
            var viewModel = new PlayerListViewModel();
            viewModel.Players = _playerRepository.GetFrom(0).Select(PlayerToPlayerViewModel).ToList();
            return View(viewModel);
        }


        public IActionResult GetFrom(int startPos)
        {
            return Json( _playerRepository.GetFrom(startPos).Select(PlayerToPlayerViewModel).ToList());
        }


        private PlayerListViewModel.PlayerViewModel PlayerToPlayerViewModel(Player arg)
        {
            return new PlayerListViewModel.PlayerViewModel
            {
                Id = arg.Id,
                JerseyNumber = arg.JerseyNumber,
                Name = arg.Name,
                Position = arg.Position,
                ImageUrl = Path.Combine(_environment.ContentRootPath, $"/images/{arg.Id}.jpg")
            };
        }

    }
}