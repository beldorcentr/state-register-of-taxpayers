using System;
using System.ComponentModel;

namespace Bdc.StateRegisterOfTaxpayers.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // BDC 190638734
            // missing 700046451
            // url with ip http://194.158.199.69/grp/getData?unp={unp}

            var stateRegisterOfTaxpayerService = new StateRegisterOfTaxpayerService();

            Taxpayer payer;

            try
            {
                payer = stateRegisterOfTaxpayerService.GetTaxpayer("190638734").Result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return;
            }

            if (payer == null)
            {
                Console.WriteLine("payer not found");
                return;
            }

            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(payer))
            {
                Console.WriteLine($"{descriptor.Name}={descriptor.GetValue(payer)}");
            }
        }
    }
}
