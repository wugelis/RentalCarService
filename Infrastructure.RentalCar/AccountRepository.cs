using Application.RentalCar.Repositories;
using Application.RentalCar.ViewModels;
using Common.RentalCar.Crypto;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RentalCar
{
    /// <summary>
    /// 
    /// </summary>
    public class AccountRepository : IAccountRepository
    {
        private readonly SaleCarDbContext _context;

        public AccountRepository(SaleCarDbContext context) 
        {
            _context = context;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int CreateAccount(AccountViewModel account)
        {
            int result = 0;

            Account accountEnt = new Account()
            {
                UserId = account.UserId,
                Password = StringEncryptor.EncryptString(account.Password!),
                Aid = account.Aid,
                ChtName = account.ChtName,
                MobilePhone = account.MobilePhone
            };

            _context.Accounts.Add(accountEnt);

            try
            {
                result = _context.SaveChanges();
            }
            catch(Exception ex)
            {
                Trace.TraceError($"新增帳號發生錯誤, SysInfo={ex.Message}");
            }

            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int DeleteAccount(int id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int EditAccount(AccountViewModel account)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public AccountViewModel? GetAccount(string userId)
        {
            //var account = _context.Accounts
            //    .Where(c => c.UserId == userId)
            //    .Select(c => new AccountViewModel()
            //    {
            //        UserId = c.UserId,
            //        Password = c.Password,
            //        Aid = c.Aid,
            //        ChtName = c.ChtName,
            //        MobilePhone = c.MobilePhone
            //    })
            //    .FirstOrDefault();

            var account = (from a in _context.Accounts
                          where a.UserId == userId
                          select new AccountViewModel()
                          {
                              UserId = a.UserId,
                              Password = a.Password,
                              Aid = a.Aid,
                              ChtName = a.ChtName,
                              MobilePhone = a.MobilePhone
                          })
                          .FirstOrDefault();

            return account;
        }
    }
}
