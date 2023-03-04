using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        /// <summary>
        /// Get price based on day of the week and seat availibity. Will randomly generate seat prices only when more than 
        /// 50 seats are available. 
        /// </summary>
        /// <param name="day"></param>
        /// <param name="seats"></param>
        /// <returns></returns>
        public double GetPrice(DayOfWeek day, int seats)
        {

            double _price = pricesByDay[day];
            double price = _price;


            // Based on seat availability create hard price adjustments 
            if (seats < 30)
            {
                // create a +20% adjustment
                price *= 1.20; 
            }
            else if (seats < 60 && seats > 30)
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

    // In Progress
    #region Travel Agency 

    class TravelAgency
    {

        #region Private Variables 
        private String idNum;
        private String recID;
        // Using orders variable to track number of orders processed. 
        private static int orders = 0;
        private MultiCellBuffer buffer;
        private PricingModel pm;
        #endregion

        #region Constructors 

        /// <summary>
        /// Default Constructor -- Not yet sure if I will need this 
        /// </summary>
        public TravelAgency()
        {

        }

        /// <summary>
        /// Constructor to Initialize a TravelAgency
        /// </summary>
        /// <param name="idNum"></param>
        /// <param name="buffer"></param>
        /// <param name="pm"></param>
        public TravelAgency(String idNum, MultiCellBuffer buffer, PricingModel pm, String recID)
        {
            this.idNum = idNum;
            this.buffer = buffer;
            this.pm = pm;
            this.recID = recID; 
        }
        #endregion

        #region Public Methods 

        /// <summary>
        /// Gets the order count for this Travel Agent only. Will need to add all agents count together to get total. 
        /// </summary>
        /// <returns></returns>
        public static int GetOrderCount()
        {
            return orders;
        }

        /// <summary>
        /// Start the Travel Agency Thread when Called. 
        /// </summary>
        /// <param name="low">Minimum amount of orders to be randomly generated</param>
        /// <param name="high">Maximum amount of orders to be randomly generated</param>
        public void Run(int low, int high)
        {
            
            int maxOrders = new Random().Next(low, high);
            // Defining a stopping condition 
            while (orders < maxOrders)
            {
                Thread.Sleep(500);
                
                // Generate Random Info to Create an Pricing Model Class object 
                // Generate a random day of week to help with testing 
                int getDayInt = new Random().Next(0, 7);
                DayOfWeek dayOfWeek = (DayOfWeek) getDayInt;
                // seats will always be more than 1 so in a sence unlimited
                int seats = new Random().Next(1, 100);
                // Initialize a Pricing Model Class
                PricingModel pm = new PricingModel();
                double price = pm.GetPrice(dayOfWeek, seats);

                // Generate random info required for a Order Class Object 
                // Generate Random number betwen 5000 and 7000 for credit card number 
                int cardNum = new Random().Next(5000, 7000);

                // Create Order Class object 
                OrderClass order = new OrderClass(idNum, cardNum, this.recID, seats);

                // Encode Order Class object into a Sting 
                Encoder enc = new Encoder();
                String encodedOrder = enc.encode(order);

                Boolean sendToBuffer = buffer.SetOneCell(encodedOrder); 

                if (sendToBuffer == true)
                {
                    orders++;
                    Console.WriteLine("Travel Agency {0}: sent order with following information \n Airline: {1} \n Card No: {2} \n Seats: {3} \n Time: {4} ",
                                        idNum,order.GetReceiverID(),order.GetCardNum(), order.GetAmount(), DateTime.Now.ToString("h:mm:ss tt"));
                }
                else
                {
                    Console.WriteLine("Travel Agency {0}: Failed to send Order to Airline: {1}", idNum, order.GetReceiverID());
                }
            }
        }
        #endregion
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
        // Changing this implementation, originally thought it was a price amount. 
        // May need to make other changes 
        private int amountOfSeats;
        #endregion

        #region Constructors 

        /// <summary>
        /// Default constructor to create an empty OrderClass to make assignable if needed later on. 
        /// </summary>
        public OrderClass()
        {

        }

        /// <summary>
        /// Constructor to initialize the OrderClass, only making it possible to assign values in here since members
        /// are private to avoid bad coding practices. 
        /// </summary>
        /// <param name="senderID"></param>
        /// <param name="cardNum"></param>
        /// <param name="receiverID"></param>
        /// <param name="amount"></param>
        public OrderClass(String senderID, int cardNum, String receiverID, int amount)
        {
            this.senderID = senderID;
            this.cardNum = cardNum;
            this.receiverID = receiverID;
            this.amountOfSeats = amount; 
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
            return this.amountOfSeats; 
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

                OrderClass decodedOrder = new OrderClass(splitString[0], int.Parse(splitString[1]), splitString[2], int.Parse(splitString[3]));
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
            OrderClass test = new OrderClass("Simon", 12345, "Bob", 10);
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
