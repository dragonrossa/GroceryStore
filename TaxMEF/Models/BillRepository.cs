using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxMEF.Models
{
    public interface IRepository
    {
        string HelloWorld();
        object GetTax(int tax);
    }
      

        [Export(typeof(IRepository))]
        public class BillRepository : IRepository
         {
       
        public string HelloWorld()
            {
                return "Hello world";
            }

        public object GetTax(int tax)
        {
            decimal realTax = Decimal.Divide(tax, 100);
            return realTax;
        }
    }
    
}
