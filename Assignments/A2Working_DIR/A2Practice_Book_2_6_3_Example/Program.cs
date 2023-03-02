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

    #region Chicken Farm Class
    public class ChickenFarm
    {
        static Random rng = new Random();
        // Initialize an event for the delegate method 
        public static event priceCutEvent priceCut;
        private static Int32 chickenPrice = 10;

        #region Methods for Chicken Farm Class
        public Int32 getPrice()
        {
            return chickenPrice;
        }
        
        public static void changePrice(Int32 price)
        {
            if (price < chickenPrice)
            {
                // if there is at least one subscriber 
                if (priceCut != null)
                {
                    // change price for subscribers 
                    priceCut(price);
                }
            }
            chickenPrice = price; 
        }
        
        public void farmerFunc()
        {
            for (Int32 i = 0; i < 50; i++)
            {
                Thread.Sleep(500);
                Int32 p = rng.Next(5, 10);
                Console.WriteLine("New Price is: {0}", p);
                ChickenFarm.changePrice(p);
            }
        }
        #endregion
    }
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
