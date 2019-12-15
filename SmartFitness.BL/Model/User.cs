using System;

namespace SmartFitness.BL.Model
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    [Serializable]
    public class User
    {
        #region Свойства
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }       //public string Name { get; }

        /// <summary>
        /// Пол.
        /// </summary>
        public Gender Gender { get; set; }       

        /// <summary>
        /// День рождение.
        /// </summary>
        public DateTime BirthDay { get; set; }   

        /// <summary>
        /// Вес.
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Рост.
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Возраст.
        /// </summary>
        public int Age { get { return DateTime.Now.Year - BirthDay.Year; } }

        #endregion

        /// <summary>
        /// Создать нового пользователя.
        /// </summary>
        /// <param name="name"> Имя. </param>
        /// <param name="gender"> Пол. </param>
        /// <param name="birthDay"> День рождение. </param>
        /// <param name="weight"> Вес. </param>
        /// <param name="height"> Рост. </param>
        public User(string name, 
                    Gender gender,
                    DateTime birthDay, 
                    double weight, 
                    double height)
        {
            #region Проверка условий ввода
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя указано некорректно.");
            }

            if (gender == null)
            {
                throw new ArgumentNullException("Пол указан некорректно.");
            }

            if (birthDay < DateTime.Parse("01.01.1900") && birthDay >= DateTime.Now)
            {
                throw new ArgumentException("Дата рождения указано некорректно.");
            }

            if (weight <= 0)
            {
                throw new ArgumentException("Вес указан некорректно.");
            }

            if (height <= 0)
            {
                throw new ArgumentException("Рост указан некорректно.");
            }
            #endregion

            Name = name;
            Gender = gender;
            BirthDay = birthDay;
            Weight = weight;
            Height = height;

        }

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя указано некорректно.");
            }

            Name = name;
        }

        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}
