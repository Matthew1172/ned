using Microsoft.EntityFrameworkCore;
using ned_task.Exceptions;

namespace ned_task.Models
{
    public class MyUserService : MyUserServiceInterface
    {
        //context hold the DB context of users in the database.
        //When we perform CRUD operations on users in the DB context, and then call SaveChanges(), it is reflected in the DB.
        private MyUserContext _context;

        public MyUserService(MyUserContext context)
        {
            _context = context;
        }

        public void DeleteMyUser(long id)
        {
            //no DB connection, return null for now, or throw exception
            if (_context == null) return;
            try
            {
                //Since type MyUser cannot be null, If Find() returns null, assign an empty User and check the email.
                MyUser u = _context.MyUsers.Find(id)?? new MyUser();
                //If the email is empty, then throw user not found error.
                if (u.email.Length < 1)
                {
                    throw new MyUserNotFound(u.Id);
                }
                //user was found, remove it and save changes to DB
                _context.MyUsers.Remove(u);
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

        public IEnumerable<MyUser>? GetMyUsers()
        {
            if (_context == null) return null;
            try
            {
                //return a list of users from the DB context.
                return _context.MyUsers.ToList();
            }
            catch
            {
                throw;
            }
        }

        public void InsertMyUser(MyUser user)
        {
            //tried to enter a blank user. Return null for now, but could add an exception here and display the message on frontend.
            if (user.email.Length < 1 || user.fname.Length < 1 || user.lname.Length < 1) return;

            if (_context == null) return;
            try
            {
                //Add the new user and save changes to DB
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
                //find the user. Turn the context into a set and iterate through it and find all those users whose id equals the currently selected user id,
                //and return the first element of the result.
                var local = _context.Set<MyUser>().Local.Where(entry => entry.Id.Equals(id)).First();
                // check if we found the user
                if (local is not null)
                {
                    //stop keeping track of the user that is in the DB context. After save changes is called, this user will be deleted.
                    _context.Entry(local).State = EntityState.Detached;
                }
                else
                {
                    throw new MyUserNotFound(id);
                }
                //Since the primary key in local == user, we can change the state of the newly changed user to be modified, so that it can be added to the DB.
                //Set the user in the DB context to modified state so that when we save changes it updates the DB
                _context.Entry(user).State = EntityState.Modified;
                //We changed the user in the DB context so now when we save changes it will update it in the DB
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
