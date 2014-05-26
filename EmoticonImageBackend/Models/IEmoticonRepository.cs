using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmoticonImageBackend.Models
{
    public interface IEmoticonRepository
    {
        IEnumerable<string> TestGetAll();
    }
}