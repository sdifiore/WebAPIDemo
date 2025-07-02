namespace WebAPIDemo.Models.Repositories
{
    public static class ShirtRepository
    {
        private static readonly List<Shirt> shirts =
        [
            new Shirt { ShirtId = 1, Brand = "T-Shirt", Color = "Blue", Gender = "Men", Size = 10, Price = 30 },
            new Shirt { ShirtId = 3, Brand = "T-Shirt", Color = "Black", Gender = "Men", Size = 12, Price = 35 },
            new Shirt { ShirtId = 3, Brand = "Z-Shirt", Color = "Pink", Gender = "Women", Size = 8, Price = 28 },
            new Shirt { ShirtId = 4, Brand = "Z-Shirt", Color = "Yellow", Gender = "Women", Size = 9, Price = 30 },
        ];

        public static IEnumerable<Shirt> GetAllShirts()
        {
            return shirts;
        }

        public static bool ShirtExists(int id)
        {
            return shirts.Any(s => s.ShirtId == id);
        }

        public static Shirt? GetShirtById(int id)
        {
            return shirts.FirstOrDefault(s => s.ShirtId == id);
        }

        public static Shirt? GetShirtByProperties(string? brand, string? gender, string? color, int? size)
        {
            return shirts.FirstOrDefault(s =>
                !string.IsNullOrWhiteSpace(brand) &&
                !string.IsNullOrWhiteSpace(s.Brand) &&
                s.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase) &&
                !string.IsNullOrWhiteSpace(gender) &&
                !string.IsNullOrWhiteSpace(s.Gender) &&
                s.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase) &&
                !string.IsNullOrWhiteSpace(color) &&
                !string.IsNullOrWhiteSpace(s.Color) &&
                s.Color.Equals(color, StringComparison.OrdinalIgnoreCase) &&
                size.HasValue &&
                s.Size.HasValue &&
                size.Value == s.Size.Value);
        }

        public static void AddShirt(Shirt shirt)
        {
            int maxId = shirts.Max(s => s.ShirtId);
            shirt.ShirtId = maxId + 1;

            shirts.Add(shirt);
        }

        public static void UpdateShirt(Shirt shirt)
        {
            Shirt shirtToUpdate = shirts.First(s => s.ShirtId == shirt.ShirtId);
            shirtToUpdate.Brand = shirt.Brand;
            shirtToUpdate.Color = shirt.Color;
            shirtToUpdate.Price = shirt.Price;
            shirtToUpdate.Size = shirt.Size;
            shirtToUpdate.Gender = shirt.Gender;
        }
    }
}