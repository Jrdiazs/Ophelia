using Ophelia.Models;
using System;

namespace Ophelia.Data
{
    public class TypeDocumentRepository : RepositoryGeneric<TypeDocument>, ITypeDocumentRepository, IDisposable
    {
        public TypeDocumentRepository()
        { }
    }

    public interface ITypeDocumentRepository : IRepositoryGeneric<TypeDocument>, IDisposable
    { }
}