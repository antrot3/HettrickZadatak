﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hattrick.Service.Models.Entities;

namespace Hattrick.Service.Repositiories
{
    public interface IProfileRepository
    {
        Profile GetProfileById(int Id);
        Profile GetFirstUser();
    }

    public class ProfileRepository : IProfileRepository
    {
        private readonly Hattrick.Service.Models.HattrickContext _context;
        public ProfileRepository()
        {
            _context = new Models.HattrickContext();
        }

        public Profile GetProfileById(int Id)
        {
            return _context.Profiles.Where(x => x.Id == Id).First();
        }
        public Profile GetFirstUser()
        {
            return _context.Profiles.First();
        }
    }
}