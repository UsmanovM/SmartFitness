using System;

namespace SmartFitness.BL.Model
{
    /// <summary>
    /// Пол.
    /// </summary>
    [Serializable]
    public class Gender
    {
        /// <summary>
        /// Название пола.
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// Создать новый пол.
        /// </summary>
        /// <param name="name">Имя пола.</param>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя не корректно");
                //throw new ArgumentNullException("Имя не корректно", nameof(name));
            }

            Name = name;
        }


        public override string ToString()
        {
            return Name;
        }

    }
}
