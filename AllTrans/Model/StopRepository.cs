using System;
using System.Collections.Generic;
using System.Text;

namespace AllTrans.Model
{
    internal interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Delete(int id);
    }
    public class UserRepository: IRepository<User>
    {
        private ApplicationContext db;
        public UserRepository(ApplicationContext context)
        {
            this.db = context;
        }
        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }
        public User Get(int id)
        {
            return db.Users.Find(id);
        }
        public void Create(User stop)
        {
            db.Users.Add(stop);
        }

        public void Delete(int id)
        {
            User stop = db.Users.Find(id);
            if (stop != null)
            {
                db.Users.Remove(stop);
            }
        }
    }
}
