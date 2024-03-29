﻿using Microsoft.EntityFrameworkCore;

namespace Gotham.web.Models
{
    public class GothamwebContext : DbContext
    {
        public GothamwebContext (DbContextOptions<GothamwebContext> options)
            : base(options)
        {
        }

        public DbSet<Gotham.domain.Nouvelle> Nouvelle { get; set; }
        public DbSet<Gotham.domain.Capsule> Capsule { get; set; }
    }
}
