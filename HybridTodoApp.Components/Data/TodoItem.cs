using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridTodoApp.Components.Data
{
    public class TodoItem
    {
        public string? Title { get; set; } = string.Empty;
        public bool IsDone { get; set; } = false;
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string? LocationName { get; set; }
    }
}
