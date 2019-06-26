using System;
using System.Collections.Generic;
using System.Text;

namespace UnauthorizedException
{
    public interface IPathResolver
    {
        string GetRealPath(string path);
    }
}
