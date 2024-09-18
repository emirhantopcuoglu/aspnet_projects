namespace TaskTracker.Models
{
    public class Repository
    {
        private List<ToDoTask> _tasks = new List<ToDoTask>();

        public Repository()
        {
            _tasks.Add(new ToDoTask()
            {
                Id = 1,
                Description = "İlk yapılacak iş.",
                Status = "Yapılacak",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });
        }

        public List<ToDoTask> GetTasks()
        {
            return _tasks;
        }

        public ToDoTask GetTaskById(int id)
        {
            return _tasks.FirstOrDefault(x => x.Id == id);
        }

        public void AddTask(ToDoTask task)
        {
            task.Id = _tasks.Count + 1;
            task.Description = "";
            task.Status = "";
            task.CreatedAt = DateTime.Now;
            task.UpdatedAt = DateTime.Now;
            _tasks.Add(task);
        }

        public void UpdateTask(ToDoTask task)
        {
            var existingTask = GetTaskById(task.Id);
            if (existingTask != null)
            {
                existingTask.Description = task.Description;
                existingTask.Status = task.Description;
                existingTask.UpdatedAt = DateTime.Now;
            }
        }

        public void DeleteTask(int id)
        {
            var task = GetTaskById(id);
            if(task != null)
                _tasks.Remove(task);
        }
    }
}