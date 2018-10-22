using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Bdc.StateRegisterOfTaxpayers.ConsoleTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // BDC 190638734
            // missing 700046451
            // url with ip http://194.158.199.69/grp/getData?unp={unp}

            var stateRegisterOfTaxpayerService = new StateRegisterOfTaxpayerService();

            Taxpayer payer;

            try
            {
                payer = await stateRegisterOfTaxpayerService.GetTaxpayerAsync("190638734");
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
