using SmartFitness.BL.Controller;
using SmartFitness.BL.Model;
using System;

namespace SmartFitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует приложение SmartFitness!");

            Console.Write("Введите имя пользователя: ");
            var name = Console.ReadLine();

            var userController = new UserController(name);

            if (userController.IsNewUser)
            {

                Console.Write("Введите пол: ");
                var gender = Console.ReadLine();
                var birthDay = ParseDateTime();
                var weight = ParseDouble("вес");
                var height = ParseDouble("рост");

                userController.SetNewUserData(gender, birthDay, weight, height);

            }

            Console.WriteLine(userController.CurrentUser);

            Console.ReadLine();

        }

        private static DateTime ParseDateTime()
        {
            DateTime birthDay;
            while (true)
            {
                Console.Write("Введите дату рождения (dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDay))
                    break;
                else
                {
                    Console.WriteLine("Неверный формат даты рождения");
                }
            }
            return birthDay;
        }

        private static double ParseDouble(string name)
        {
            double value;
            while (true)
            {
                Console.Write("Введите " + name + ": ");
                if (double.TryParse(Console.ReadLine(), out value))
                    return value;
                else
                {
                    Console.WriteLine("Неверный формат (" + name + ")");
                }
            }
        }
    }
}
