using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weapon
{
    public class Magazine 
    {
        private int capacity;  // Объявление закрытого поля "capacity", представляющего вместимость магазина.
        private int bulletCount;  // Объявление закрытого поля "bulletCount", представляющего количество патронов в магазине.
        private List<Bullet> bullets = new List<Bullet>();
        public Magazine(int capacity)  
        {
            this.capacity = capacity;  // Инициализация поля "capacity" значением параметра "capacity".
            bulletCount = 0;  // Инициализация поля "bulletCount" значением 0.
        }

        public Bullet ExtractBullet()  // Извлечение патрона из магазина.
        {
            if (bulletCount == 0)  // Проверка, если количество патронов равно 0, возвращается null.
            {
                return null;
            }
            var bullet = bullets.LastOrDefault();
           
            bulletCount--;  // Уменьшение количества патронов.
            return bullet;  // Создание нового объекта класса "Bullet" и его возвращение.
        }

        public void AddBullet(Bullet bullet)  // Добавление патрона в магазин.
        {
            if (bulletCount >= capacity)  // Проверка, если количество патронов превышает вместимость магазина, генерируется исключение.
            {
                throw new InvalidOperationException("Превышена емкость магазина");
            }
            bullets.Add(bullet);
            bulletCount++;  // Увеличение количества патронов.
        }

        public int GetBulletCount()  // Возвращающение количества патрон в магазин.
        {
            return bulletCount;  // Возвращение значения переменной "bulletCount".
        }
    }
}
