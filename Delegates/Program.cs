using System;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            var photoProcessor = new PhotoProcessor();
            var filters = new PhotoFilters();
            var transform = new Transformations();

            PhotoProcessor.PhotoFilterHandler filterHandler = filters.ApplyBrightness;
            filterHandler += filters.ApplyContrast;
            filterHandler += filters.Resize;
            filterHandler += transform.Crop;

            photoProcessor.Process(filterHandler);

            Console.ReadLine();
        }
    }

    public class Transformations
    {
        public void Crop(Photo photo)
        {
            Console.WriteLine("Cropping...");
        }
    }

    public class PhotoProcessor
    {
        public delegate void PhotoFilterHandler(Photo photo);

        public void Process(PhotoFilterHandler filterHandler)
        {
            var photo = new Photo();

            filterHandler(photo);

            photo.Save();
        }
    }

    public class PhotoFilters
    {
        public void ApplyBrightness(Photo photo)
        {
            Console.WriteLine("Apply brightness");
        }

        public void ApplyContrast(Photo photo)
        {
            Console.WriteLine("Apply contrast");
        }

        public void Resize(Photo photo)
        {
            Console.WriteLine("Resize photo");
        }

    }

    public class Photo
    {
        public void Save()
        {
            // Saving logic...
        }
    }
}
