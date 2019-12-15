using SmartFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;

namespace SmartFitness.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователь приложения.
        /// </summary>
        public List<User> Users { get; }    // не set; 

        public User CurrentUser { get; set; }

        public bool IsNewUser { get; set; } = false;

        /// <summary>
        /// Создание нового контроллера пользователя приложения.
        /// </summary>
        /// <param name="userName">Имя пользователя.</param>
        public UserController(string userName)
        {

            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException("Имя пользователя не может быть пустым");
            }

            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            } 

        }


        /// <summary>
        /// Получить сохраненный список пользователей.
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsersData()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                //List<User> users = formatter.Deserialize(fs) as List<User>;

                if (fs.Length > 0 && formatter.Deserialize(fs) is List<User> users)
                {
                    return users;
                    //throw new ArgumentNullException("Пользователь не может быть null"); //nameof
                }
                else
                {
                    return new List<User>();
                }
                

                //User = user ?? throw new ArgumentNullException("Пользователь не может быть null"); //nameof
            }
           
        }


        public void SetNewUserData(string genderName, DateTime birthDay, double weight = 1, double height = 1)
        {
            //TODO:  Проверка

            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDay = birthDay;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }

        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Users);
            }
        }



    }
}
