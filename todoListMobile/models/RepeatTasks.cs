using System;

namespace TodoList
{
    class RepeatTasks
    {
        public int ID_RepeatTask { get; set; }
        public string Description { get; set; }
        public int Period { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public int User { get; set; }

    }
}
