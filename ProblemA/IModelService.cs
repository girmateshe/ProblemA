using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProblemA
{
    public interface IModelService
    {
        IList<Diff> Difference<T>(T item1, T item2) where T : class;
        List<string> Equal<T>(T item1, T item2) where T : class;
        string GetHash<T, TA>(T item) where TA : HashAlgorithm, new() where T : class;
    }
}
