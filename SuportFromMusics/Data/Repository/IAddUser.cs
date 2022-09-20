using SuportFromMusics.Data;

namespace Suport.Data.Repository
{
    public interface IAddUser
    {
        bool IsExistEmail(string email);
    }

    public class AddUser : IAddUser
    {
        private SuportContext _context;
        public AddUser(SuportContext context)
        {
            _context = context;
        }

        public bool IsExistEmail(string email)
        {
            var user = _context.user.SingleOrDefault(u => u.Email == email);

            if(user == null)
            {
                return false;
            }
            
            return true;
        }
    }

}
