
    namespace Practika.Models
    {
        public class CarImage
        {
            public int Id { get; set; }
            public int CarId { get; set; }
            public string ImagesPath { get; set; } = string.Empty; // в БД: images_path
        }
}