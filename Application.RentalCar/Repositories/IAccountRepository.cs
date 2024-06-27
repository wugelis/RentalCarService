﻿using Application.RentalCar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RentalCar.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAccountRepository
    {
        /// <summary>
        /// 建立帳號
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        int CreateAccount(AccountViewModel account);
        /// <summary>
        /// 編輯帳號
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        int EditAccount(AccountViewModel account);
        /// <summary>
        /// 刪除帳號
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteAccount(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        AccountViewModel? GetAccount(string userId);
    }
}
