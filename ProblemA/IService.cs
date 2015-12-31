using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProblemA
{
    public interface IService<in T> where T : class 
    {
        IList<Diff> Difference(T item1, T item2);
        List<string> Equal(T item1, T item2);
        string GetHash<TA>(T item) where TA : HashAlgorithm, new();
    }
}
