﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBank.Models
{
    public class AccountTypes
    {
        public string[] GetAccountTypes()
        {
            string[] accounts = new string[] { "Personal", "Private", "Corporate" };
            return accounts;
        }
    }
}