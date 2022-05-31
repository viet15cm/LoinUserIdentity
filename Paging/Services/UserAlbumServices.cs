using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Paging.DbContextLayer;
using Paging.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paging.Services
{
    public class UserAlbumServices
    {
        public readonly UserDbContext _context;

        public readonly ILogger<UserAlbumServices> _logger;

        public  UserAlbumServices(UserDbContext context , ILogger<UserAlbumServices> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task AddUserAlBum(UserAlbum userAlbum)
        {
            try
            {
                if(userAlbum != null)
                {
                    await _context.AddAsync(userAlbum);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation($"Them Thanh cong");
                }
            }
            catch (Exception)
            {
                _logger.LogInformation($"Them khong thanh cong");
                throw;
                
            }
        }


        

        
    }
}
