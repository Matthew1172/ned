namespace ned_task.Models
{
    public interface MyUserServiceInterface
    {
        IEnumerable<MyUser>? GetMyUsers();
        void InsertMyUser(MyUser user);
        void UpdateMyUser(long id, MyUser user);
        MyUser GetMyUser(long id);
        void DeleteMyUser(long id);
    }
}
