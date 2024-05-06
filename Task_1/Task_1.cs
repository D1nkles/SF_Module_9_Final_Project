class UserInputException : Exception 
{
    
}

class Program 
{
    static void Main(string[] args) 
    {
        Exception[] exceptions = {new FormatException(), new OverflowException(), new UserInputException(), new KeyNotFoundException(), new NotImplementedException()};
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