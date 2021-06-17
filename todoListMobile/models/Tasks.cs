namespace TodoList
{
    public class Tasks
    {
        public int NumberOfRows { get; set; }
        public long ID_Task { get; set; }
        public string Description { get; set; }
        public long DealStatus { get; set; }
        public string User { get; set; }
        public object DateDeadline { get; set; }
        public object Date { get; set; }
        public int numberOfRows { get; internal set; }
        public string nameDay { get; set; }
    }
}
