using Microsoft.EntityFrameworkCore;
using System;
using Project0.ConosoleApp;
using Project0.BusinessLogic;

namespace Project0.ConosoleApp
{
    public class StoreLogic
    {
        //make private fields for ID and Name pairings

        private int _id;
        private string _name;



        public int Id
        {
            get => _id;

            set
            {
                if (value <= 3 && value >= 1)
                {
                    _id = value;
                }
                else
                {
                    throw new ArgumentException("Please select from the options provided.", nameof(value));
                }
            }
        }

        public string Name
        {
            get => _name;

            set
            {
                if (value.Length == 0)
                {
                    //throw exception detailing name can't be empty
                    throw new ArgumentException("Need store name", nameof(value));
                }
                _name = value;
            }
        }


    }
    public class CustomerLogic
    {
        CustomerLogic customer = new CustomerLogic();
        DbContextOptions<mattproject0Context> options = new DbContextOptionsBuilder<mattproject0Context>()
            .UseSqlServer(SecretConfiguration.ConnectionString)
            .Options;

        //set private fields for instance of customer, name and id
        private int _id;

        public int Id
        {
            get => _id;

            set
            {
                if (value > 0)
                {
                    _id = value;
                }
                else
                {
                    throw new ArgumentException("Something went wrong.", nameof(value));
                }
            }
        }
        public object GetNewCustomer()
        {
            CustomerLogic customer = new CustomerLogic();
            DbContextOptions<mattproject0Context> options = new DbContextOptionsBuilder<mattproject0Context>()
                .UseSqlServer(SecretConfiguration.ConnectionString)
                .Options;


            string fName;
            string lName;
            //string fullName;
            //var custInfo = new List<BusinessLogic>();

            Console.WriteLine("Enter first name:");
            fName = Console.ReadLine().ToUpper();

            Console.WriteLine("Enter last name:");
            lName = Console.ReadLine().ToUpper();

            if (fName.Length == 0)
            {
                while (fName.Length == 0)
                {
                    Console.WriteLine("Please enter a valid first name");
                    fName = Console.ReadLine().ToUpper();
                    if (lName.Length == 0)
                    {
                        while (lName.Length == 0)
                        {
                            Console.WriteLine("Please enter a valid last name");
                            lName = Console.ReadLine().ToUpper();
                        }
                    }
                }
            }
            Console.WriteLine($"Welcome, {fName} {lName}!");

            var NewCustomer = new Customer { FirstName = fName, LastName = lName };

            return NewCustomer;
        }
        
        public void RetrieveCustomer()
        {
           customer


        }

                           
    }
    public class OrderLogic
    {
        DbContextOptions<mattproject0Context> options = new DbContextOptionsBuilder<mattproject0Context>()
            .UseSqlServer(SecretConfiguration.ConnectionString)
            .Options;

        public object NewOrder()
        {


            return Order;
        }


    }

}

   


////public static readonly DbContextOptions<mattproject0Context> options = new DbContextOptionsBuilder<mattproject0Context>()
//            .UseSqlServer(SecretConfiguration.ConnectionString)
//            .Options;