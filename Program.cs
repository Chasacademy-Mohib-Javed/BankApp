namespace bankapp
{
    class Program
    {
        public class Users
        {

            // skapar strings, int och double för användernamnet, pinkoden och saldon//

            int pin;
            String forename;
            String surname;
            double balance;
            String menu;
            double amount;


            public Users(int pin, string forename, string surname, double balance, string menu, double amount)
            {
                
                this.balance = balance;
                this.pin = pin;
                this.forename = forename;
                this.surname = surname;
                this.menu = menu;
                this.amount = amount;
            }

            public double getAmount()
            {
                return amount;
            }

            public int getPinCode()
            {
                return pin;
            }

            public String getFirstName()
            {
                return forename;
            }
            public String getLastName()
            {
                return surname;
            }
            public double getBalance()
            {

                return balance;

            }
            public String getAccountType()
            {
                return menu;
            }

            public void setAmount(double newAmount)
            {
                amount = newAmount;
            }
            public void setaccountType(String newaccountType)
            {
                menu = newaccountType;
            }
            public void setBalance(double newBalance)
            {
                balance = newBalance;
            }
            public void setpinCode(int newpinCode)
            {
                pin = newpinCode;
            }
            public void setfirstName(String newfirstName)
            {
                forename = newfirstName;
            }
            public void setlastName(String newlastName)
            {
                surname = newlastName;
            }

            public void Transfer(Users receiver, double amount)
            {
                if (balance < amount)
                {
                    Console.WriteLine("Error:303 (not enough balance)");
                    return;
                }

                balance -= amount;
                receiver.balance += amount;

                Console.WriteLine("Transfer succeeded !");
                Console.WriteLine("");
            }

            static void Main(string[] args)
            {
                // nedåt skapas en meny så att man väljer olika alternativ efter man har loggat in// 

                void printOptions()
                {
                    Console.WriteLine("Chose an option");
                    Console.WriteLine("1. Deposit  ");
                    Console.WriteLine("2. withdraw ");
                    Console.WriteLine("3. transfer between accounts");
                    Console.WriteLine("4. check acount and balance ");
                    Console.WriteLine("5. Log ut");

                }

                // Funktionen gör så att man kan lägga pengar på kontot//



                void deposit(Users currentUser)
                {
                    Console.WriteLine(" How much would you like to deposit ");
                    double deposit = Double.Parse(Console.ReadLine());
                    currentUser.setBalance(currentUser.getBalance() + deposit);
                    Console.WriteLine("New balance: " + currentUser.getBalance());
                }



                // funktionen gör så att man kan ta ut pengar från kontot//

                void withdraw(Users currentUser)
                {
                    Console.WriteLine("how much would you like to withdraw: ");
                    double withdraw = Double.Parse(Console.ReadLine());
                    if (currentUser.getBalance() < withdraw)
                    {
                        Console.WriteLine("Error:303 (not enough balance) :(");

                    }
                    else
                    {
                        currentUser.setBalance(currentUser.getBalance() - withdraw);
                        Console.WriteLine("withdraw succeeded");
                      
                        Console.WriteLine("Current balance: " + currentUser.getBalance());
                    }
                }

                // Visar vad saldo är på kontot//

                void balance(Users currentUser)
                {
                    Console.WriteLine("PersonKonto --> " + " Giltig saldo: " + currentUser.getBalance());
                }

                // Skapar array med namnet och pin koden//

                string[] Names = { "Mohib", "Caius", "Bosko", "Musse", "Krille" };
                int[] pinCodes = { 1234, 3454, 0404, 8484, 2121 };

                // skapar en lista med personer, deras konto och hur mycket pengar var och en har//

                List<Users> Bankusers = new List<Users>();

                Bankusers.Add(new Users(1234, "Mohib", "Javed", 34324, "PersonKonto", 0));
                Bankusers.Add(new Users(3454, "Caius", "Matei", 4575, "PersonKonto", 0));
                Bankusers.Add(new Users(0404, "Bosko", "Derikonja", 7577, "PersonKonto", 0));
                Bankusers.Add(new Users(8484, "Musse", "Musse", 90902, "PersonKonto", 0));
                Bankusers.Add(new Users(2121, "Krille", "Boss", 23992, "PersonKonto", 0));




                Console.WriteLine(" welcome to the ATM");

                Console.WriteLine("Enter username:");
                String forename = "";

                Users activeUser;

                // kollar om namnet finns inne i listan som skapades övanför, om det inte finns så skrivs det att det existerar inte//




                while (true)
                {
                    try
                    {
                        forename = Console.ReadLine();
                        activeUser = Bankusers.FirstOrDefault(a => a.forename == forename);
                        if (activeUser != null) { break; }
                        else { Console.WriteLine("Name dose not exist! "); }
                    }
                    catch { Console.WriteLine("Name dose not exist! "); }

                }
                Console.WriteLine("Enter Pin: ");
                int userPin = 0;

                // samma sak gäller för pin koden//


                while (true)
                {
                    try
                    {
                        userPin = int.Parse(Console.ReadLine());

                        if (activeUser.getPinCode() == userPin) { break; }
                        else { Console.WriteLine("Invalid Pin, try again"); }
                    }
                    catch { Console.WriteLine("Invalid Pin, try again"); }

                }

                // om godkänd och användaren kommer in så får hen en meny med olika alternativ//

                Console.WriteLine("welcome " + activeUser.getFirstName());
                Console.WriteLine("");
                int option = 0;
                do
                {
                    printOptions();
                    try
                    {
                        option = int.Parse(Console.ReadLine());
                    }
                    catch { }
                    if (option == 1)
                    {
                        deposit(activeUser);
                    }
                    else if (option == 2) { withdraw(activeUser); }
                    else if (option == 4) { balance(activeUser); }
                    else if (option == 3)
                    {
                        foreach (var item in Names)
                        {
                            Console.WriteLine(item.ToString());
                        }

                        Console.WriteLine("");
                        Console.WriteLine("Enter the recipient's name:");
                        string recipientName = Console.ReadLine();
                        Users recipient = Bankusers.FirstOrDefault(a => a.forename == recipientName);

                        if (recipient == null)
                        {
                            Console.WriteLine("recipient dose not exist");
                        }
                        else
                        {
                            Console.WriteLine("Enter the amount to transfer:");
                            double transferAmount = double.Parse(Console.ReadLine());
                            activeUser.Transfer(recipient, transferAmount);
                        }
                    }


                    else if (option == 5) { break; }
                    else { option = 0; }
                }
                while (option != 5);
                Console.WriteLine("See you soon!");


            }
        }
    }
}
