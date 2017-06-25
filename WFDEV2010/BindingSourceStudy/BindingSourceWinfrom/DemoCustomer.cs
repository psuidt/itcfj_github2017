using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingSourceWinfrom
{
 public   class DemoCustomer
    {
        // These fields hold the values for the public properties.
        private Guid idValue = Guid.NewGuid();
        private string customerName = String.Empty;
        private string companyNameValue = String.Empty;
        private string phoneNumberValue = String.Empty;

        // The constructor is private to enforce the factory pattern.
        private DemoCustomer()
        {
            customerName = "no data";
            companyNameValue = "no data";
            phoneNumberValue = "no data";
        }

        // This is the public factory method.
        public static DemoCustomer CreateNewCustomer()
        {
            return new DemoCustomer();
        }

        // This property represents an ID, suitable
        // for use as a primary key in a database.
        public Guid ID
        {
            get
            {
                return this.idValue;
            }
        }

        public string CompanyName
        {
            get
            {
                return this.companyNameValue;
            }

            set
            {
                this.companyNameValue = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return this.phoneNumberValue;
            }

            set
            {
                this.phoneNumberValue = value;
            }
        }
    }
}
