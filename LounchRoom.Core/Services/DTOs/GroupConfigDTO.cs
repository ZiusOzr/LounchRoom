using LounchRoom.Core.Services.DTOs;
using System;

namespace LounchRoom.Core.Services.Implementations
{
    internal class GroupConfigDTO
    {
        public string GroupId { get; set; }
        public string Address { get; set; }
        public Point Location { get; set; }
    }
}