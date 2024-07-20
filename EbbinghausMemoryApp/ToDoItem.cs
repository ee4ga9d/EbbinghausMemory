using System;

/******************************************************************************
 * 作者:      ee4ga9d@gmail.com
 * 日期:      2024-07-18
 * 描述:      待办事项。
 * 版本:      1.0
 * 版权:      x.com/0EE4GA9d © 2024
 ******************************************************************************/
namespace EbbinghausMemoryApp
{
    public class ToDoItem
    {

        public int Id { get; set; }
        public DateTime ReviewDateTime { get; set; }
        public string Description { get; set; }
        public string Experience { get; set; }
        public bool IsCompleted { get; set; }

        public ToDoItem() { }
        public ToDoItem(int id, string description, bool isCompleted)
        {
            Id = id;
            Description = description;
            IsCompleted = isCompleted;
        }

        public override string ToString()
        {
            return this.Description;
            //  return base.ToString();
        }
    }
}
