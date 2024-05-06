using Task_1;

namespace Task_2
{
    public delegate List<string> SortDel(List<string> _surnames, int _sortType);

    class SortEvent
    {
        public event SortDel _sortEvent;
        
        public List<string> DoSort(List<string> _surnames, int _sortType)
        {
            return _surnames = _sortEvent.Invoke(_surnames, _sortType);
        }
    }

    class Sort
    {
        public static List<string> SortSurnames(List<string> _surnames, int _sortType)
        {
            if (_sortType == 1)
            {
                //Сортировка встроенным в классе List<> методом.
                //_surnames = _surnames.Order().ToList();

                //Самостоятельно написанная сортировка.
                for (int i = 0; i < _surnames.Count; i++)
                {
                    string baseElement = _surnames[i];
                    char baseFirstLetter = baseElement.First();
                    for (int j = i + 1; j < _surnames.Count; j++)
                    {
                        string nextElement = _surnames[j];
                        char nextFirstLetter = nextElement.First();
                        string tempElement;
                        if (baseFirstLetter > nextFirstLetter)
                        {
                            tempElement = _surnames[i];
                            _surnames[i] = _surnames[j];
                            _surnames[j] = tempElement;
                            baseElement = _surnames[i];
                            baseFirstLetter = baseElement.First();
                        }
                    }
                }
                return _surnames;
            }
            else if (_sortType == 2)
            {
                //Сортировка встроенным в классе List<> методом.
                //_surnames = _surnames.OrderDescending().ToList();

                //Самостоятельно написанная сортировка.
                for (int i = 0; i < _surnames.Count; i++)
                {
                    string baseElement = _surnames[i];
                    char baseFirstLetter = baseElement.First();
                    for (int j = i + 1; j < _surnames.Count; j++)
                    {
                        string nextElement = _surnames[j];
                        char nextFirstLetter = nextElement.First();
                        string tempElement;
                        if (baseFirstLetter < nextFirstLetter)
                        {
                            tempElement = _surnames[i];
                            _surnames[i] = _surnames[j];
                            _surnames[j] = tempElement;
                            baseElement = _surnames[i];
                            baseFirstLetter = baseElement.First();
                        }
                    }
                }
                return _surnames;
            }
            else return null;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            int commandNum;
            bool errOccured = false;
            List<string> _surnames = new List<string>() { "Фролов", "Никифоров", "Астафьева", "Демидов", "Ермакова" };
            SortEvent sortEvent = new SortEvent();
            sortEvent._sortEvent += Sort.SortSurnames;
            Console.Write("Введите число, соответсвующее команде:\n" +
                          "1 - Сортировка списка от А до Я.\n" +
                          "2 - Сортировка списка от Я до А.\n" +
                          "========================================================\n" +
                          "Ожидание ввода: ");

            try
            {
                commandNum = int.Parse(Console.ReadLine());
                if (commandNum < 1 || commandNum > 2)
                {
                    throw new UserInputException();
                }
                else
                {
                    _surnames = sortEvent.DoSort(_surnames, commandNum);
                }
            }

            catch (FormatException formEx)
            {
                Console.WriteLine("Вы ввели не число!");
                errOccured = true;
            }

            catch (UserInputException inputEx)
            {
                Console.WriteLine(inputEx.Message);
                errOccured = true;
            }

            finally
            {
                if (!errOccured)
                {
                    Console.Write("Отсортированыый список: ");
                    foreach (string surname in _surnames)
                    {
                        Console.Write(surname + " ");
                    }
                }
                else
                {
                    Console.WriteLine("Перезапустите приложение и попробуйте снова!");
                }
            }
            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу, чтобы закрыть приложение...");
            Console.ReadKey();
        }
    }
}