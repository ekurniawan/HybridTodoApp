using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HybridTodoApp.Data
{
    public class TodoService
    {
        string file = string.Empty;

        public TodoService()
        {
            file = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "todos.json");
        }

        public void SaveItems(IEnumerable<TodoItem> items)
        {
            var json = JsonSerializer.Serialize(items);
            File.WriteAllText(file, json);
        }
    }
}
