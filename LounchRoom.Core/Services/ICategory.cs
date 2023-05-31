using System;
using System.Collections.Generic;
using System.Text;

namespace LounchRoom.Core.Services
{
    public interface ICategory
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
    }
}
