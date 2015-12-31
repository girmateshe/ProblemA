using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProblemA
{
    public class ModelService : IModelService
    {
        public IList<Diff> Difference<T>(T item1, T item2) where T : class
        {
            if (item1 == null || item2 == null)
                return null;

            var type = typeof(T);
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance).ToList();

            var diff = new List<Diff>();
            properties.ForEach(pi =>
            {
                var value1 = pi.GetValue(item1, null);
                var value2 = pi.GetValue(item2, null);

                if (!value1.Equals(value2))
                {
                    diff.Add(new Diff
                    {
                        Name = pi.Name,
                        Values = new List<object> { value1, value2}
                    });
                }
            });

            return diff;
        }

        public List<string> Equal<T>(T item1, T item2) where T : class
        {
            if (item1 == null || item2 == null)
                return null;

            var type = typeof(T);
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance).ToList();

            var matches = new List<string>();
            properties.ForEach(pi =>
            {
                var value1 = pi.GetValue(item1, null);
                var value2 = pi.GetValue(item2, null);

                if (value1.Equals(value2))
                {
                    matches.Add(pi.Name);
                }
            });

            return matches;
        }

        public string GetHash<T, TA>(T item) where TA : HashAlgorithm, new() where T : class
         {
            var cryptoServiceProvider = new TA();

            var serializer = new DataContractSerializer(item.GetType());
            using (var memoryStream = new MemoryStream())
            {
                serializer.WriteObject(memoryStream, item);
                cryptoServiceProvider.ComputeHash(memoryStream.ToArray());
                return Convert.ToBase64String(cryptoServiceProvider.Hash);
            }
      }
    }
}
