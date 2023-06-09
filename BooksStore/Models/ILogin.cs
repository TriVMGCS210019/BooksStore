﻿using System.Collections.Generic;
using System.Threading.Tasks;
using BooksStore.Models;

namespace BooksStore.Repository
{
    public interface ILogin
    {
        Task<IEnumerable<UserLogin>> getuser();
        Task<UserLogin> AuthenticateUser(string username, string passcode);
    }
}