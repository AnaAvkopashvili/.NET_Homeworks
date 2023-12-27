namespace HW_day_18_Exceptions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                IBAN iban = new IBAN("GE00TBxxxxxxxxxxxxxxxx");
                User user1 = new User("AnaAvkopashvili", iban, 1234);
                IBAN iban2 = new IBAN("GE00TBxxxxxxxxxxxxxxxxxxxxx");
            }
            catch (IbanValidateException ex)
            {
                Console.WriteLine(ex.Message);
            }
            DebitIban debitiban = new DebitIban("GE00TBxxxxxxxxxxxxxxxx");
            CreditIban creditiban = new CreditIban("GE00TBxxxxxxxxxxxxxxxx");

            creditiban.deposit(2000);
            Console.WriteLine("Balance on credit card: " + creditiban.available);
            creditiban.withdraw(3000);
            Console.WriteLine("Balance on credit card: " + creditiban.available);

            try
            {
                debitiban.deposit(10);
                Console.WriteLine("Balance on debit card: " + debitiban.available);
                debitiban.withdraw(100);
            }
            catch (AmountValidateException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Balance on debit card: " + debitiban.available);
        }
    }
}