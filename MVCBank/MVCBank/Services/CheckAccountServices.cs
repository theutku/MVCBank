using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCBank.Models;

namespace MVCBank.Services
{
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

        public static bool isAdmin(string userId)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var isUserAdmin = db.Users.Any(user => user.Id == userId && user.UserRole == "Admin");

            return isUserAdmin ? true : false;
        }

    }
}