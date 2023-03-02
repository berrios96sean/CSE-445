using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2Berrios_Sean
{

    #region Delegates for Events 
    
    public delegate void priceCutEvent(Int32 price);
    public delegate void orderProcessedEvent();
    public delegate void orderReceivedEvent();
    public delegate void priceModelEvent(); 
    
    #endregion

    #region Airline class
    class Airline
    {

    }

    #endregion

    #region Pricing Model Class

    class PricingModel
    {
        Random rand = new Random(); 

    }

    #endregion

    #region Order Processing Class

    class OrderProcessing
    {

    }

    #endregion

    #region Travel Agency 

    class TravelAgency
    {

    }

    #endregion

    #region Order Class

    class OrderClass
    {
        #region Private Variables 
        private int senderID;
        private int cardNum;
        private int receiverID;
        private int amount;
        #endregion
    }

    #endregion

    #region Multi Cell Buffer 

    class MultiCellBuffer
    {

    }

    #endregion

    #region Encoder Class

    class Encoder
    {

    }

    #endregion

    #region Decoder Class 

    class Decoder
    {

    }

    #endregion

    #region Main Program 

    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    #endregion


}
