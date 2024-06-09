﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FinalProject14231.Infrastructure.Data
{
    public class ApplicationDbContextInitialiser
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ApplicationDbContextInitialiser> _logger;

        public ApplicationDbContextInitialiser(ApplicationDbContext context, ILogger<ApplicationDbContextInitialiser> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task InitializeAsync()
        {
            try
            {
                if (_context.Database.IsSqlite())
                {
                    await _context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initializing the database.");
                throw;
            }
        }
    }
}
