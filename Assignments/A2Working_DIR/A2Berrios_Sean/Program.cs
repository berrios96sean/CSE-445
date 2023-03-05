using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace A2Berrios_Sean
{

    #region Delegates for Events 
    
    public delegate void priceCutEventHandler(int price, String airlineID);
    
    #endregion

    #region Airline class
    class Airline
    {

        #region Private Variables 
        private double price;
        private String id;
        private MultiCellBuffer buffer;
        private int priceAdjustments;
        private int ordersAccepted;
        private int ordersRejected; 
        #endregion

        #region Constructors 

        public Airline()
        {

        }

        public Airline(String id, MultiCellBuffer buffer)
        {
            this.id = id;
            this.buffer = buffer;
            this.priceAdjustments = 0;
        }
        #endregion

        #region Public Methods 

        public void Run()
        {
            
            while (true)
            {
                Thread.Sleep(500);
               // Decoder dcr = new Decoder();
                String test = this.buffer.GetOneCell(id);
                if (test == null )
                {
                    Console.WriteLine("Airline: {0} not found in buffer",id);
                    break; 
                }
                else
                {
                    //Console.WriteLine("not Null");
                    getOrders(test); 
                    //Console.WriteLine(test);
                }
                //OrderClass test1 = dcr.decodeString(test);
                //Console.WriteLine("yo"); 
                //Console.WriteLine(test1.GetSenderId());
                //Console.WriteLine("YO");
                //getOrders(); 
            }
        }


        public void getOrders(String encOrder)
        {
            
            while(true)
            {
                encOrder = buffer.GetOneCell(id);

                // if no order continue listening for orders 
                if (encOrder == null)
                {
                    continue; 
                }
                if (encOrder != null)
                {
                    // Decode string for order 
                    Decoder dcr = new Decoder();
                    OrderClass order = new OrderClass();
                    //Console.WriteLine(encOrder);
                    //Console.WriteLine("Decoding at line: 89");
                    order = dcr.decodeString(encOrder);
                    //Console.WriteLine(order.GetSenderId());
                    // Get order variables
                    int cardNum = order.GetCardNum();
                    int seats = order.GetAmount();
                    PricingModel pm = new PricingModel();
                    int getDayInt = new Random().Next(0, 7);
                    DayOfWeek dayOfWeek = (DayOfWeek)getDayInt;
                    this.price = pm.GetPrice(dayOfWeek, seats);

                    //
                    OrderProcessing op = new OrderProcessing(cardNum, this.price, seats);
                    Boolean processOrder = op.processOrder();

                    if (processOrder)
                    {
                        ordersAccepted++;
                        Console.WriteLine("Airline {0}: Processed order with following information -- Travel Agency: {1} - Card No: {2} - Seats: {3} - Time: {4} ",
                                        id, order.GetSenderId(), order.GetCardNum(), order.GetAmount(), DateTime.Now.ToString("h:mm:ss tt"));
                    }
                    else
                    {
                        ordersRejected++;
                        Console.WriteLine("Airline {0}: Could Not Process Order from Travel Agency: {1}", id, order.GetSenderId());
                    }

                    
                }
                

            }
        }

        public int GetAcceptedOrders()
        {
            return this.ordersAccepted;
        }

        public int GetRejectedOrders()
        {
            return this.ordersRejected;
        }

        #endregion

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

    // Implemented
    #region Order Processing Class

    class OrderProcessing
    {
        // TODOs 
        /*
         * check card number is between 5000 and 7000 
         * calculate total unitPrice*Seats+ tax Tax is 5% 
         * if order is declined or processed notify the Airline 
         * to keep track 
         */
        #region Private Variables 
        private double tax = 0.05;
        private OrderClass order;
        private double price;
        private int seats;
        private int cardNum; 
        #endregion

        #region Constructors 

        public OrderProcessing()
        {

        }

        public OrderProcessing(int cardNum, double price, int seats)
        {
            this.cardNum = cardNum;
            this.price = price;
            this.seats = seats; 
        }
        #endregion

        #region Public Methods 

        public bool processOrder()
        {
            if (cardNum < 5000 || cardNum > 7000)
            {
                Console.WriteLine("Order Rejected: CC Invalid");
                return false; 
            }

            double taxed = (price * seats) * tax;
            double total = (price * seats) + taxed;

            return true;
            Console.WriteLine("Order Processed");
        }
        #endregion

    }

    #endregion

    // Implemented -- TESTED
    #region Travel Agency 

    class TravelAgency
    {

        #region Private Variables 
        private String idNum;
        // Using orders variable to track number of orders processed. 
        private static int orders = 0;
        private MultiCellBuffer buffer;
        private PricingModel pm;
        private double price;
        private bool finish = false; 
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
        public TravelAgency(String idNum, MultiCellBuffer buffer, PricingModel pm)
        {
            this.idNum = idNum;
            this.buffer = buffer;
            this.pm = pm; 
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
        public void Run()
        {
            
            int maxOrders = new Random().Next(8, 10);
            // Defining a stopping condition 
            while (orders < maxOrders)
            {
                Thread.Sleep(500);
                int airlineNum = new Random().Next(1, 3);
                String airlineID = "Airline " + airlineNum;
                int getDayInt = new Random().Next(0, 7);
                DayOfWeek dayOfWeek = (DayOfWeek)getDayInt;
                int seats = new Random().Next(1, 100);
                this.price = pm.GetPrice(dayOfWeek, seats);
                
                

                sendOrder(seats,price,airlineID);

                if(orders == maxOrders)
                {
                    this.finish = true; 
                }

               // Thread.Sleep(500);
            }
        }

        public void sendOrder(int seats, double price, String airlineID)
        {


            // Initialize a Pricing Model Class
            PricingModel pm = new PricingModel();

            // Generate Random number betwen 5000 and 7000 for credit card number 
            int cardNum = new Random().Next(5000, 7000);

            // Create Order Class object 
            OrderClass order = new OrderClass(idNum, cardNum, airlineID, seats);

            // Encode Order Class object into a Sting 
            Encoder enc = new Encoder();
            //Console.WriteLine("Encoding at line: 355");
            String encodedOrder = enc.encode(order);

            Boolean sendToBuffer = buffer.SetOneCell(encodedOrder);

            if (sendToBuffer == true)
            {
                orders++;
                Console.WriteLine("Travel Agency {0}: sent order with following information -- Airline: |{1}| - Card No: {2} - Seats: {3} - Time: {4} ",
                                    idNum, order.GetReceiverID(), order.GetCardNum(), order.GetAmount(), DateTime.Now.ToString("h:mm:ss tt"));
            }
            else
            {
                Console.WriteLine("Travel Agency {0}: Failed to send Order to Airline: {1}", idNum, order.GetReceiverID());
            }
        }

        public void priceCutEvent(int newPrice, String airlineID)
        {
            if (newPrice < this.price)
            {
                int seats = new Random().Next(1, 100);
                sendOrder(seats, newPrice, airlineID);
            }
        }

        public bool isFinished()
        {
            return this.finish; 
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
                    
                    return null; 
                }

                for (int i = 0; i < size; i++)
                {
                    Decoder dcr = new Decoder(); 
                    String str = cells[nextOut];
                    OrderClass order = new OrderClass(); 
                    if (str != null)
                    {
                        //Console.WriteLine("Decoding at line: 534");
                        order = dcr.decodeString(str);
                        //Console.WriteLine(order.GetReceiverID());
                    }


                    if (cells[nextOut] != null && order.GetReceiverID() == receiverID)
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

        public bool IsEmpty()
        {
            if (cellsUsed == 0)
            {
                return true; 
            }
            else
            {
                return false; 
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
                if (encodedString == null)
                {
                    //Console.WriteLine("String is Null");
                    return null; 
                }
                byte[] byteArray = Convert.FromBase64String(encodedString);
                String decodedString = Encoding.UTF8.GetString(byteArray);
                //Console.WriteLine("Decoded String = {0}",decodedString);
                String[] splitString = decodedString.Split(',');

                OrderClass decodedOrder = new OrderClass(splitString[0], int.Parse(splitString[1]), splitString[2], int.Parse(splitString[3]));
                //Console.WriteLine(decodedOrder.GetSenderId());
                return decodedOrder;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception at line: 632");
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
            //testDecoderEncoder();
            testTravelAgency();

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

           //Console.WriteLine("Deoding at line: 671");
            OrderClass newOrder = dcr.decodeString(encoded);

            Console.WriteLine("New Instace = sender: {0} \n card: {1} \n receiver: {2} \n amount: {3}", newOrder.GetSenderId(), newOrder.GetCardNum(), newOrder.GetReceiverID(), newOrder.GetAmount());

        }

        public static void testMultiCellBuffer()
        {

        }

        public static void testTravelAgency()
        {
            int airlineNum = new Random().Next(1,3);
            MultiCellBuffer buffer = new MultiCellBuffer(5);
            PricingModel pm = new PricingModel();
            TravelAgency ta1 = new TravelAgency("Travel Agency 1", buffer, pm);  
            Thread ta1Thread = new Thread(new ThreadStart(ta1.Run));
            TravelAgency ta2 = new TravelAgency("Travel Agency 2", buffer, pm);
            Thread ta2Thread = new Thread(new ThreadStart(ta2.Run));
            Airline a1 = new Airline("Airline 1", buffer);
            Thread a1Thread = new Thread(new ThreadStart(a1.Run));
            Airline a2 = new Airline("Airline 2", buffer);
            Thread a2Thread = new Thread(new ThreadStart(a2.Run));
            Airline a3 = new Airline("Airline 3", buffer);
            Thread a3Thread = new Thread(new ThreadStart(a3.Run));

            ta1Thread.Start();
            ta2Thread.Start();
            //a1.Start();
            a1Thread.Start();
            a2Thread.Start();
            a3Thread.Start();




            ta1Thread.Join();
            ta2Thread.Join();
            a1Thread.Join();
            a2Thread.Join();
            a3Thread.Join();

        }
        
        #endregion
    }

    #endregion


}
