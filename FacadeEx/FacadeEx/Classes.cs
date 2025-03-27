using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeEx
{
    public class InsuranceFacade
    {
        private DriversLicense ssLicense;
        private Accident ssAccident;
        private Claim ssClaim;

        public InsuranceFacade()
        {
            ssLicense = new DriversLicense();
            ssAccident = new Accident();
            ssClaim = new Claim();
        }

        public void setRate(Driver driver)
        {
            bool discountRateEligible = true;
            Console.WriteLine("Checking discount rate for driver...");
            if (!ssLicense.HasValidLicense(driver))
            {
                discountRateEligible = false;
            }

            if (!ssAccident.HasNoAccidents(driver))
            {
                discountRateEligible = false;
            }

            if (!ssClaim.HasNoClaims(driver))
            {
                discountRateEligible = false;
            }

            //Couldn

            if (discountRateEligible)
            {
                Console.WriteLine("{0} is eligible for the discounted rate.", driver.DriverName);
            } else
            {
                Console.WriteLine("{0} is only eligible for the standard rate.", driver.DriverName);
            }
        }
    }

    class DriversLicense 
    {
        public bool HasValidLicense(Driver driver)
        {
            Console.WriteLine("Checking license information for {0}...", driver.LicenseNumber);

            return true;
        }
    }

    class Accident
    {
        public bool HasNoAccidents(Driver driver)
        {
            Console.WriteLine("Checking accident history for {0}...", driver.LicenseNumber);

            return true;
        }
    }

    class Claim
    {
        public bool HasNoClaims(Driver driver)
        {
            Console.WriteLine("Checking claim history for {0}...", driver.LicenseNumber);

            return true;
        }
    }

    public class Driver
    {
        public string LicenseNumber { get; set; }
        public string DriverName { get; set; }
        public Driver(string licenseNumber, string driverName)
        {
            this.LicenseNumber = licenseNumber;
            this.DriverName = driverName;
        }
    }
}
