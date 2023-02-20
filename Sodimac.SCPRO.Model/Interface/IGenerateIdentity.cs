using System;

namespace Sodimac.SCPRO.Model.Interface
{
    public interface IGenerateIdentity<T>
    {
        Func<T> GetKey();
    }
}
