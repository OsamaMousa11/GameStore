namespace GameStore
{
    public  class DataSeeder
    {

        private readonly AppDbContext _context;


        public DataSeeder(AppDbContext context)
        {
            _context = context;
        }
        public  void Seed()
        {
            
            _context.Database.EnsureCreated();

            if (!_context.Categories.Any())
            {
                var categorys = new[]
                {
                new Category { Id = 1, Name = "Sports" },
                new Category { Id = 2, Name = "Action" },
                new Category { Id = 3, Name = "Adventure" },
                new Category { Id = 4, Name = "Racing" },
                new Category { Id = 5, Name = "Fighting" },
                new Category { Id = 6, Name = "Film" }
                };

                _context.Categories.AddRange(categorys);
                _context.SaveChanges();
            }

            if (!_context.Devices.Any())
            {
                var Devices = new[]
                {
                new Device { Id = 1, Name = "PlayStation", Icon = "bi bi-playstation" },
                new Device { Id = 2, Name = "Xbox", Icon = "bi bi-xbox" },
                new Device { Id = 3, Name = "Nintendo Switch", Icon = "bi bi-nintendo-switch" },
                new Device { Id = 4, Name = "PC", Icon = "bi bi-pc-display" }
                };

                _context.Devices.AddRange(Devices);
                _context.SaveChanges();
            }


        }
    }
}
