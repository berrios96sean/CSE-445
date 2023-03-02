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
        // Use thread name 
        private String senderID;
        private int cardNum;
        // Use thread name 
        private String receiverID;
        private int amount;
        #endregion

        #region Constructors 

        public OrderClass()
        {

        }

        // Setting the variables in a constructor since variables are private
        public OrderClass(String senderID, int cardNum, String receiverID, int amount)
        {
            this.senderID = senderID;
            this.cardNum = cardNum;
            this.receiverID = receiverID;
            this.amount = amount; 
        }
        #endregion

        #region Public Methods 

        public String GetSenderId()
        {
            return this.senderID; 
        }

        public int GetCardNum()
        {
            return this.cardNum;
        }

        public String GetReceiverID()
        {
            return this.receiverID; 
        }

        public int GetAmount()
        {
            return this.amount; 
        }
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
