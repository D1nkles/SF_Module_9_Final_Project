namespace Task_1
{
    public class UserInputException : Exception
    {
        public override string Message => "Вы ввели число, не соответсвующее никакому номеру команды.";
        public UserInputException() 
        {
            
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Exception[] exceptions = { new FormatException(), new OverflowException(), new UserInputException(), new KeyNotFoundException(), new NotImplementedException() };
            for (int i = 0; i < exceptions.Length;)
            {
                try
                {
                    throw exceptions[i];
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    i++;
                }
            }
        }
    }
}