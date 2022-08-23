using Microsoft.EntityFrameworkCore;

namespace ned_task.Models
{
    public class MyUserService : MyUserServiceInterface
    {
        private MyUserContext _context;

        public MyUserService(MyUserContext context)
        {
            _context = context;
        }

        public void DeleteMyUser(long id)
        {
            try
            {
                MyUser ord = _context.MyUsers.Find(id);
                _context.MyUsers.Remove(ord);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public MyUser GetMyUser(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MyUser> GetMyUsers()
        {
            try
            {
                return _context.MyUsers.ToList();
            }
            catch
            {
                throw;
            }
        }

        public void InsertMyUser(MyUser user)
        {
            if (_context == null) return;
            try
            {
                _context.MyUsers.Add(user);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateMyUser(long id, MyUser user)
        {
            if (_context == null) return;
            try
            {
                var local = _context.Set<MyUser>().Local.FirstOrDefault(entry => entry.Id.Equals(user.Id));
                // check if local is not null
                if (local is not null)
                {
                    // detach
                    _context.Entry(local).State = EntityState.Detached;
                }
                _context.Entry(user).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
