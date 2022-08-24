/*
 * 
 * User class that matches a row in the DB. 
 * 
 */

namespace ned_task.Models
{
    public class MyUser
    {
        public long Id { get; set; }
        public string fname { get; set; } = string.Empty;
        public string lname { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
    }
}
