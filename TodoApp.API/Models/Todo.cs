
using System;

namespace TodoApp.API.Models
{
    /// <summary>
    /// This class respresnts Todo table
    /// </summary>
    public class Todo
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        /// <returns></returns>
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsAccomplished { get; set; }
        public bool IsDeleted { get; set; }               
        public DateTime CreatedOn { get;set; }
        public Nullable<DateTime> LastUpdatedOn { get; set;}       
        
    }
}