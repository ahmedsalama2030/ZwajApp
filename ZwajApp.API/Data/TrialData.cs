using System.Collections.Generic;
using Newtonsoft.Json;
using ZwajApp.API.Models;

namespace ZwajApp.API.Data
{
    public class TrialData
    {
        private readonly DataContext _dataContext;
        public TrialData(DataContext dataContext)
        {
            _dataContext = dataContext;

        }
 
          public void TrialUsers(){
           var userData=System.IO.File.ReadAllText("Data/UserTrialData.json");
          var users=JsonConvert.DeserializeObject<List<User>>(userData);
          foreach (var user in users)
          {
              byte[] passwordHash, passwordSalt;
CreatePasswordHash("password",out passwordHash,out passwordSalt);

user.PasswordHash=passwordHash;
user.PasswordSalt=passwordSalt;
user.UserName=user.UserName.ToLower();
_dataContext.Add(user);
          }

          _dataContext.SaveChanges();



          }
 private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using ( var hmac =new System.Security.Cryptography.HMACSHA512()){

passwordSalt=hmac.Key;
passwordHash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            }

        }
    }
}