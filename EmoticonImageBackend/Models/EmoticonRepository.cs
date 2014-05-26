using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmoticonImageBackend.Models
{
    public class EmoticonRepository : IEmoticonRepository
    {
        public IEnumerable<string> TestGetAll()
        {

            using (var context = new EmoticonContext())
            {
                context.Pictures.Count();
            }

            return new string[] { "test1", "test2", "test3" };
        }
    }
}