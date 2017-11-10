using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBank.Models
{
    enum Accounts
    {
        Private = 0,
        Personal = 1,
        Corporate = 2
    }
    public class AccountTypes
    {
        public string[] GetAccountTypes()
        {
            string[] accounts = new string[] { "Personal", "Private", "Corporate" };
            return accounts;
        }
    }
}