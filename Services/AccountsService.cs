using System;
using allspice.Models;
using allspice.Repositories;

namespace allspice.Services
{
  public class AccountsService
  {
    private readonly AccountsRepository _repo;
    public AccountsService(AccountsRepository repo)
    {
      _repo = repo;
    }
    internal Account GetOrCreateAccount(Account userInfo)
    {
      Account account = _repo.GetById(userInfo.Id);
      if (account == null)
      {
        return _repo.Create(userInfo);
      }
      return account;
    }
  }
}