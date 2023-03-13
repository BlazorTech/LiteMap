using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTech.LiteMap
{
    public class LiteMapRegion
    {
        public required string Title { get; set; }
        public required string Path { get; set; }
        
        internal bool IsHovered { get; set; } = false;
    }
}
