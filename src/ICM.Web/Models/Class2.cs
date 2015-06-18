using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ICM.Web.Models;

namespace ICM.Web.Models
{
    public class Search {
        public  Customer LastNameSearch(string lastName, List<Customer> customers)
        {
            int y = -1;
            for (var i=0;i<customers.Count;i++) {
                if (lastName.Equals(customers[i].LastName)) {
                    y = i;
                    break;
                }
            }

            if (y != -1)
            {
                return customers[y];
            }
            else
            {
                throw new ApplicationException("Customer not found.");
            }
        }
    }
}