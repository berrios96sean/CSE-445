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

    // Implemented 
    #region Pricing Model Class


    class PricingModel
    {
        #region Private Variables 
        // using dictionary to hardcode price for day of the week in the constructor
        // Defining prices in constructor, may need to come back to this to see if there is a smoother way
        private Dictionary<DayOfWeek, int> pricesByDay;
        #endregion

        #region Constructors 

        // Default constructor will hardcode the prices for the days of the week when called need to include this in its description when called 
        /// <summary>
        /// Creates a pricing model that initializes hardcoded prices for each day of the week
        /// </summary>
        public PricingModel()
        {
            pricesByDay = new Dictionary<DayOfWeek, int>
            {
                    {DayOfWeek.Monday, 100},
                    {DayOfWeek.Tuesday,110},
                    {DayOfWeek.Wednesday,120},
                    {DayOfWeek.Thursday,115},
                    {DayOfWeek.Friday,135},
                    {DayOfWeek.Saturday,105},
                    {DayOfWeek.Sunday,95}
            };
        }

        #endregion

        #region Public Methods 

        public double GetPrice(DayOfWeek day, int seats)
        {

            double _price = pricesByDay[day];
            double price = _price;


            // Based on seat availability create hard price adjustments 
            if (seats < 10)
            {
                // create a +20% adjustment
                price *= 1.20; 
            }
            else if (seats < 50 && seats > 10)
            {
                // create a -10% adjustment 
                price *= 0.90;
            }
            else
            {
                // apply a random adjustment between -15% to +15%
                Random rand = new Random();
                double fact = rand.NextDouble() * 0.3 + 0.85;
                price *= fact;
            }

            return price; 

        }

        #endregion

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

    // Implemented -- TESTED
    #region Order Class

    class OrderClass
    {
        #region Private Variables 
        // Use thread name 
        private String senderID;
        private int cardNum;
        // Use thread name 
        private String receiverID;
        private double amount;
        #endregion

        #region Constructors 

        public OrderClass()
        {

        }

        // Setting the variables in a constructor since variables are private
        public OrderClass(String senderID, int cardNum, String receiverID, double amount)
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

        public double GetAmount()
        {
            return this.amount; 
        }
        #endregion
    }

    #endregion

    // Implemented 
    #region Multi Cell Buffer 

    class MultiCellBuffer
    {

        #region Private Variables 
        private String[] cells;
        private int cellsUsed;
        private int size;
        private int nextIn;
        private int nextOut;
        #endregion

        #region Constructors
        
        public MultiCellBuffer()
        {

        }

        public MultiCellBuffer(int size)
        {
            this.size = size;
            this.cells = new string[size];
            this.cellsUsed = 0;
            this.nextIn = 0;
            this.nextOut = 0;
        }
        #endregion

        #region Public Methods 

        // making boolean to ensure cell was set. 
        public bool SetOneCell(String data)
        {
            // setting lock on class to prevent race conditions 
            lock (this)
            {
                // ensure not all cells for the buffer are being used 
                if (cellsUsed == size)
                {
                    return false; 
                }

                cells[nextIn] = data; 
                // Create a circular buffer 
                if (nextIn == size -1)
                {
                    nextIn = 0; 
                }
                else
                {
                    nextIn++; 
                }
                cellsUsed++;

                return true; 
            }
        }

        public String GetOneCell(String receiverID)
        {
            // setting lock on class to prevent race conditions
            lock (this)
            {
                // initialize variable to hold the encoded string 
                String data = null;

                // there are no cells being used 
                if (cellsUsed == 0)
                {
                    return "All cells are empty"; 
                }

                for(int i = 0; i < size; i++)
                {
                    if (cells[nextOut] != null && cells[nextOut].Contains(receiverID))
                    {
                        data = cells[nextOut];
                        cells[nextOut] = null; 
                        if (nextOut == size - 1)
                        {
                            nextOut = 0; 
                        }
                        else
                        {
                            nextOut++;
                        }
                        cellsUsed--;
                        break; 
                    }

                    if (nextOut == size -1)
                    {
                        nextOut = 0; 
                    }
                    else
                    {
                        nextOut++;
                    }

                }

                return data; 

            }
        }
        #endregion
    }

    #endregion

    // Implemented -- TESTED 
    #region Encoder Class

    class Encoder
    {
        #region Public Methods 

        public String encode(OrderClass order)
        {
            try
            {
                String str = String.Format("{0},{1},{2},{3}", order.GetSenderId(), order.GetCardNum(), order.GetReceiverID(), order.GetAmount());
                byte[] byteArray = Encoding.UTF8.GetBytes(str);
                String encodedString = Convert.ToBase64String(byteArray);
                return encodedString;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: "+ e.Message);
            }
            return null; 
        }
        #endregion
    }

    #endregion

    // Implemented -- TESTED 
    #region Decoder Class 

    class Decoder
    {
        public OrderClass decodeString(String encodedString)
        {
            try
            {
                byte[] byteArray = Convert.FromBase64String(encodedString);
                String decodedString = Encoding.UTF8.GetString(byteArray);
                //Console.WriteLine("Decoded String = {0}",decodedString);
                String[] splitString = decodedString.Split(',');

                OrderClass decodedOrder = new OrderClass(splitString[0], int.Parse(splitString[1]), splitString[2], double.Parse(splitString[3]));
                return decodedOrder;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: "+ e.Message);
            }
            return null; 
        }
    }

    #endregion

    #region Main Program 

    class Program
    {
        static void Main(string[] args)
        {
            testDecoderEncoder();
        }

        // to make code neater and for debugging the testing methods are designed to ensure functionality of each class as I am integrating 
        #region Test Methods 
       
        public static void testDecoderEncoder()
        {
            OrderClass test = new OrderClass("Simon", 12345, "Bob", 345.43);
            Encoder enc = new Encoder();
            Decoder dcr = new Decoder();

            String encoded = enc.encode(test);
            Console.WriteLine("Encoded String = {0}", encoded);

            OrderClass newOrder = dcr.decodeString(encoded);

            Console.WriteLine("New Instace = sender: {0} \n card: {1} \n receiver: {2} \n amount: {3}", newOrder.GetSenderId(), newOrder.GetCardNum(), newOrder.GetReceiverID(), newOrder.GetAmount());

        }

        public static void testMultiCellBuffer()
        {

        }
        
        #endregion
    }

    #endregion


}
