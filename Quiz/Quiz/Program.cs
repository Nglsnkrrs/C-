namespace Quiz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Add_user add = new Add_user();
            Work_Quiz quiz = new Work_Quiz();
            Admin admin = new Admin();
            string login, password, dateOfBirth;
            while (true)
            {
                Console.WriteLine("Меню");
                Console.WriteLine("1. Регистрация");
                Console.WriteLine("2. Вход");
                Console.WriteLine("3. Профиль администратора");
                Console.WriteLine("4. Назад");
                Console.Write("Ваш выбор: ");
                int choice = Convert.ToInt32(Console.ReadLine());


                switch (choice)
                {
                    case 1:
                        Console.Write("Введите логин: ");
                        login = Console.ReadLine();
                        Console.Write("Введите пароль: ");
                        password = Console.ReadLine();
                        Console.Write("Введите дату рождения (ДД.ММ.ГГ): ");
                        dateOfBirth = Console.ReadLine();
                        add.Register(login, password, dateOfBirth);
                        break;
                    case 2:
                        Console.Write("Введите логин: ");
                        login = Console.ReadLine();
                        Console.Write("Введите пароль: ");
                        password = Console.ReadLine();
                        Console.Write("Введите дату рождения (ДД.ММ.ГГ): ");
                        dateOfBirth = Console.ReadLine();
                        if (add.UserLogin(login, password, dateOfBirth))
                        {
                            while (true)
                            {
                                Console.WriteLine("1. Запустить викторину");
                                Console.WriteLine("2. Результаты тестов");
                                Console.WriteLine("3. Топ 20");
                                Console.WriteLine("4. Настройки");
                                Console.WriteLine("5. Назад");
                                int res = Convert.ToInt32(Console.ReadLine());

                                switch (res)
                                {
                                    case 1: quiz.RunTheQuiz(login); break;
                                    case 2: quiz.YourResultTest(login); break;
                                    case 3:
                                        Console.Write("Введите название теста: ");
                                        string top = Console.ReadLine();
                                        quiz.TopResult(top); break;
                                    case 4: 
                                        quiz.ChangeDateBandPassword(login); break;
                                    case 5: return;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Выполняется регистрация пользователя");
                            add.Register(login, password, dateOfBirth);
                        }
                        break;
                        case 3:
                            admin.AdminProf();
                        break;
                        case 4: return;

                }
            }

        }
    }
}
