using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZwajApp.API.Models;

namespace ZwajApp.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _db;
        public AuthRepository(DataContext db)
        {
            _db = db;

        }
        public async Task<User> Login(string username, string password)

        {
            User user =await _db.Users.FirstOrDefaultAsync(x=>x.UserName==username);
            if(user==null) return null;

            // if(!VerifyPasswordHash(password,user.PasswordSalt,user.PasswordHash))
            // return null;
            return user;
         }

        private bool VerifyPasswordHash(string password, byte[] passwordSalt, byte[] passwordHash)
        {
         using ( var hmac =new System.Security.Cryptography.HMACSHA512(passwordSalt)){

 var OutHash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        for (int i = 0; i < OutHash.Length; i++)
        {
            if(OutHash[i]!=passwordHash[i]){
            return false;
            }
        }
                    return true;

            }



        }

        public async Task<User> Register(User user, string password)
        {
           byte[] passwordHash,PasswordSalt;

             CreatePasswordHash(password,out passwordHash,out PasswordSalt );
    //    user.PasswordSalt=PasswordSalt;
    //    user.PasswordHash=passwordHash;
        await _db.Users.AddAsync(user);
        await _db.SaveChangesAsync();
        return user;
       
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using ( var hmac =new System.Security.Cryptography.HMACSHA512()){

passwordSalt=hmac.Key;
passwordHash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            }

        }

        public  async Task<bool> UserExists(string username)
        {

             if( await _db.Users.AnyAsync(x=>x.UserName==username))
             return true;
             return false;


        }
    }
}