namespace ned_task.Exceptions
{
    public class MyUserNotFound : Exception
    {
        public MyUserNotFound(long? id)
            : base(String.Format("User with id: {0} could not be found.", id))
        {

        }
    }
}
