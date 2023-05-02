namespace coustmers_Ass
{
    class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string PhoneNum { get; set; }
        public string City { get; set; }
    }

    class CustomerDetails
    {
        List<Customer> list;
        public int CustomerId = 1;

        public CustomerDetails()
        {
            list = new List<Customer>()
                {
                    new Customer { Id = CustomerId++, FirstName = "manoj", LastName = "pilla", Email = "manoj@gmail.com", Age = 21, PhoneNum = "9876543210", City = "PVP"},
                    new Customer { Id = CustomerId++, FirstName = "manu", LastName = "sir", Email = "manu@gmail.com", Age = 22, PhoneNum = "0123456789", City = "VZM"}
                };
        }

        public void AddCustomer()
        {
            Console.WriteLine("Enter Customer First Name");
            string fistname = Console.ReadLine();
            Console.WriteLine("Enter customer Last Name");
            string lastname = Console.ReadLine();
            Console.WriteLine("Enter Customer Email Id");
            string emailid = Console.ReadLine();
            Console.WriteLine("Enter Customer Age");
            int age = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Enter Customer Phone Number");
            string phn = Console.ReadLine();
            Console.WriteLine("Enter Customer City");
            string city = Console.ReadLine();
            int id = CustomerId++;
            list.Add(new Customer() { Id = id, FirstName = fistname, LastName = lastname, Email = emailid, Age = age, PhoneNum = phn, City = city });
            Console.WriteLine("Customer Added and Customer Id is Generated");
        }

        public Customer GetCustomer(int id)
        {
            foreach (Customer c in list)
            {
                if (c.Id == id)
                    return c;
            }
            return null;
        }

        public List<Customer> GetAllCustomers()
        {
            return list;
        }

        public bool DeleteCustomer(int id)
        {
            foreach (Customer c in list)
            {
                if (c.Id == id)
                {
                    list.Remove(c);
                    return true;
                }
            }
            return false;
        }

        public void UpdateCustomer(int id)
        {
            foreach (Customer c in list)
            {
                if (c.Id == id)
                {
                    Console.WriteLine("Enter updated customer First Name");
                    c.FirstName = Console.ReadLine();
                    Console.WriteLine("Enter updated customer Last Name");
                    c.LastName = Console.ReadLine();
                    Console.WriteLine("Enter upated customer email id");
                    c.Email = Console.ReadLine();
                    Console.WriteLine("Enter updated customer age");
                    c.Age = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("Enter updated customer Phone Number");
                    c.PhoneNum = Console.ReadLine();
                    Console.WriteLine("Enter updated customer City");
                    c.City = Console.ReadLine();

                    Console.WriteLine("Customer Details Updated Successfully");
                }
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerDetails details = new CustomerDetails();
            string res = null;
            do
            {
                Console.WriteLine("Welcome to customer management");
                Console.WriteLine("1. Add customer");
                Console.WriteLine("2. Get customer By Id");
                Console.WriteLine("3. Get All customers");
                Console.WriteLine("4. Delete customer By Id");
                Console.WriteLine("5. Update customer By Id");
                Console.WriteLine("Enter Your choice: ");
                int choice = Convert.ToInt16(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            details.AddCustomer();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Enter Customer Id");
                            int id = Convert.ToInt16(Console.ReadLine());
                            Customer? c = details.GetCustomer(id);
                            if (c == null)
                            {
                                Console.WriteLine("Customer not exists");
                            }
                            else
                            {
                                Console.WriteLine($"Customer Details of id {c.Id} :");
                                Console.WriteLine($"First Name: {c.FirstName}\nLast Name: {c.LastName}\nEmail: {c.Email}\nAge: {c.Age}\nPhone Number: {c.PhoneNum}\nCity: {c.City}");
                            }
                            break;
                        }
                    case 3:
                        {                        
                            foreach (var c in details.GetAllCustomers())
                            {
                                Console.WriteLine($"{c.Id}\t{c.FirstName}\t{c.LastName}\t{c.Email}\t{c.Age}\t{c.PhoneNum}\t{c.City}");

                            }
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Enter Customer Id");
                            int id = Convert.ToInt16(Console.ReadLine());
                            if (details.DeleteCustomer(id))
                            {
                                Console.WriteLine("Customer Deleted Successfully");
                            }
                            else
                            {
                                Console.WriteLine("Customer not exist");
                            }
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Enter Customer Id");
                            int id = Convert.ToInt16(Console.ReadLine());
                            details.UpdateCustomer(id);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid Choice");
                            break;
                        }
                }
                Console.WriteLine("Do you wish to continue? [y/n] ");
                res = Console.ReadLine();
            } while (res.ToLower() == "y");
        }
    }   
}