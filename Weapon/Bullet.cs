using System;

namespace Weapon
{
    public class Bullet
    {
        public bool IsUsed { get; private set; }  // Объявление публичного свойства "IsUsed" с доступом для чтения и приватным доступом для записи.

        public Bullet()  // Объявление конструктора класса "Bullet" без параметров.
        {
            IsUsed = false;  // Установка значения свойства "IsUsed" в false.
        }

        public void Use()  // Объявление публичного метода "Use", который отмечает пулю как использованную.
        {
            if (IsUsed)  // Проверка, если пуля уже использована, генерируется исключение.
            {
                throw new InvalidOperationException("Пуля уже использована");
            }
            IsUsed = true;  // Установка значения свойства "IsUsed" в true.
        }
    }
}