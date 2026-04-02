namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {

                PhoneBook phone = new PhoneBook();
                //Console.WriteLine(phone["amira"]);
                //phone[0] = "amira";
                phone[1] = "amira";
                Console.WriteLine(phone[1]);


                Person p = new Person();
                p.FirstName = "Amira";
                p.LastName = "Nasser";
                p.Age = 21;
                Console.WriteLine(p.FullName);
                p.Password = " ";
                //p.Password = "Amira";
                //Console.WriteLine(p.Password);
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Hello, World!");
        }
    }
}
