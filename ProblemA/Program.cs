using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProblemA
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var address1 = new Address { Street = "", City = "Kirkland", ZipCode = "98034"};
            var address2 = new Address { Street = "", City = "Bellevue", ZipCode = "98035"};
            var address3 = new Address { Street = "", City = "Bothel", ZipCode = "98036"};
            var address4 = new Address { Street = "", City = "Seattle", ZipCode = "98037"};

            var dog1 = new Dog
            {
                Id = 1,
                Name = "Bella",
                Gender = "Female",
                Age = 1,
                IsInsured = true,
                Address = new List<Address> { address1, address2}
            };

            var dog2 = new Dog { Id = 2, Name = "Lucy", Gender = "Female", Age = 1, IsInsured = false };
            dog2.Address.Add(address2);
            var dog3 = new Dog { Id = 3, Name = "Charlie", Gender = "Male", Age = 2, IsInsured = false };
            dog3.Address.Add(address3);
            var dog4 = new Dog { Id = 4, Name = "Buddy", Gender = "Male", Age = 4, IsInsured = true };
            dog4.Address.Add(address1);
            dog4.Address.Add(address4);

            var service = new ModelService();
            var matches = service.Equal<Dog>(dog1, dog1);

            var diff = service.Difference<Dog>(dog1, dog2);

            var shaHash = service.GetHash<Dog, SHA1CryptoServiceProvider>(dog1);
            var md5Hash = service.GetHash<Dog, MD5CryptoServiceProvider>(dog1);


            var ser = new ModelService<Dog>();
            var mat = ser.Equal(dog1, dog1);

            var d = ser.Difference(dog1, dog2);

            var sha = ser.GetHash<SHA1CryptoServiceProvider>(dog1);
            var md5 = ser.GetHash<MD5CryptoServiceProvider>(dog1);

            Console.ReadLine();

            /*
            Console.WriteLine("========= Similarity ==========");
            Console.WriteLine("DogID - 1 Vs DogID - 2");
            var similarity = service.Similarity(dog1, dog2);
            RenderList(similarity, "Similarity");
            Console.WriteLine("DogID - 1 Vs DogID - 3");
            similarity = service.Similarity(dog1, dog3);
            RenderList(similarity, "Similarity");
            Console.WriteLine("DogID - 1 Vs DogID - 4");
            similarity = service.Similarity(dog1, dog4);
            RenderList(similarity, "Similarity");
            Console.WriteLine("DogID - 1 Vs DogID - 1");
            similarity = service.Similarity(dog1, dog1);
            RenderList(similarity, "Similarity");

            Console.WriteLine();
            Console.WriteLine("========= Difference ==========");
            Console.WriteLine("DogID - 1 Vs DogID - 2");
            var diff = service.Difference(dog1, dog2);
            RenderList(diff, "Difference");
            Console.WriteLine("DogID - 1 Vs DogID - 3");
            diff = service.Difference(dog1, dog3);
            RenderList(diff, "Difference");
            Console.WriteLine("DogID - 1 Vs DogID - 4");
            diff = service.Difference(dog1, dog4);
            RenderList(diff, "Difference");
            Console.WriteLine("DogID - 1 Vs DogID - 1");
            diff = service.Difference(dog1, dog1);
            RenderList(diff, "Difference");
            Console.ReadLine();*/
        }
        private static void RenderList(List<string> list, string type)
        {
            if (list.Count == 0)
            {
               Console.WriteLine("No " + type);
            }
            foreach(var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("--------------------------");
        }
        
    }
}
