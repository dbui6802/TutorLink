using DataLayer.Entities;
using System;
using System.Collections.Generic;
using TutorLinkAPI.ViewModel;

namespace TutorLinkAPI.BusinessLogics.IServices
{
    public interface IAccountService
    {
        //Account AddNewAccount(string username, string password, string fullname, string email, string phone, string address, UserGenders gender);
        Task<AccountViewModel> AddNewAccount(AddAccountViewModel accountViewModel);
        Task<AccountGoogleViewModel> AddNewAccountGoogle(AccountGoogleViewModel accountViewModel);
        Task<Account> GetAccountByEmail(string email);
        IEnumerable<Account> GetAllAccounts();
        Account GetAccountById(Guid accountId);
        void UpdateAccount(Guid id, string username, string password, string fullname, string email, string phone, string address, string? avatarUrl, UserGenders gender);
        void DeleteAccount(Guid accountId);
        Account GetAccountEntityByUsername(string username);
        Account GetAccountEntityByUserId(Guid userId);
    }
}
