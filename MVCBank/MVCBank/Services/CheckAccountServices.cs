using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCBank.Models;

namespace MVCBank.Services
{
    public enum AccountTypes
    {
        Private,
        Personal,
        Corporate,
        Admin
    }
    public class CheckAccountServices
    {
        private ApplicationDbContext db;

        public CheckAccountServices(ApplicationDbContext dbContext)
        {
            this.db = dbContext;
        }

        public void CreateCheckAccount(string firstName, string lastName, string userId, decimal initialBalance)
        {
            var accountNum = ("123MVC" + db.CheckAccounts.Count().ToString()).PadLeft(10, '0');
            var checkAccount = new CheckAccount { FirstName = firstName, LastName = lastName, AccountNumber = accountNum, Balance = initialBalance, ApplicationUserId = userId };
            this.db.CheckAccounts.Add(checkAccount);
            this.db.SaveChanges();
        }

        public static bool isOfAccountType(string userId, AccountTypes accountType)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            bool isOfGivenAccountType = db.Users.Any(user => user.Id == userId && user.UserRole == accountType.ToString());

            return isOfGivenAccountType;
        }


    }
}