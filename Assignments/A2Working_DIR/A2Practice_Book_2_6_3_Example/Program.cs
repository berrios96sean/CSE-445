using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading; 
using System.Threading.Tasks;

namespace A2Practice_Book_2_6_3_Example
{

    // Define a delegate that represents the signature of methods that can handle a price cut event with an Int32 parameter.
    // This allows us to reference any number of methods that match this signature and handle price cut events with different price cuts,
    // without needing to define multiple event handlers with similar but slightly different signatures.
    public delegate void priceCutEvent(Int32 pr); 
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
