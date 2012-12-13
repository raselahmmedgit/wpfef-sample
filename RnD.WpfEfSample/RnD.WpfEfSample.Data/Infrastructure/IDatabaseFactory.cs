using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RnD.WpfEfSample.Data
{
    public interface IDatabaseFactory : IDisposable
    {
        AppDbContext Get();
    }
}
