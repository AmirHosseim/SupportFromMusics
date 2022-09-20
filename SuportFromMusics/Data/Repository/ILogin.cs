namespace Suport.Data.Repository
{
    public interface ILogin
    {
        string Password(string pass);
    }

    public class Login : ILogin
    {
        public string Password(string SecuritPass) 
        {
            string OrginalPass = "";

            for(int i = 0; i < SecuritPass.Length; i++)
            {
                OrginalPass += (char)(SecuritPass[i] + (SecuritPass.Length) - i);
            }

            return OrginalPass;
        }
    }
}
