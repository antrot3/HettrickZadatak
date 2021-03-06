﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hattrick.Service.Models;
using Hattrick.Service.Repositiories;

namespace HattrickTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISportGameRepository _sportGameRepository;
        private readonly ISportCategoryRepository _sportCategoryRepository;
        private readonly IProfileRepository _profileRepository;
        private HattrickContext _context = new HattrickContext();


        public HomeController()
        {
            _sportGameRepository = new SportGameRepository();
            _sportCategoryRepository = new SportCategoryRepository();
            _profileRepository = new ProfileRepository();
        }
        public ActionResult Index()
        {
            var sportCategories = _sportCategoryRepository.GetAllSportCategory().ToList();
            var sportCoeficients = GetCoeficients();
            ViewBag.Coeficient = sportCoeficients;
            ViewBag.Categorys = sportCategories;
            var profile = _profileRepository.getFirstUser();
            ViewBag.Profile = profile;
            var sportGames = _sportGameRepository.GetAllSportGames().ToList();
            return View(sportGames);
        }
        public List<string> GetCoeficients()
        {
            List<string> coeficients = new List<string>();
            coeficients.Add("1");
            coeficients.Add("X");
            coeficients.Add("2");
            coeficients.Add("12");
            coeficients.Add("1X");
            coeficients.Add("X2");
            return coeficients; 
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}