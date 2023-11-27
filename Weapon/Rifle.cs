using System;

namespace Weapon
{
    public class Rifle
    {
        private Magazine magazine; // Поле для хранения магазина
        private bool isSafetyOn; // Поле для хранения состояния предохранителя
        private bool isChamberLoaded; // Поле для хранения состояния патронника
        private Bullet lastFiredBullet;

        public Rifle(Magazine magazine, bool isSafetyOn, bool isChamberLoaded)
        {
            this.magazine = magazine; // Инициализация поля магазина
            this.isSafetyOn = isSafetyOn; // Инициализация поля состояния предохранителя
            this.isChamberLoaded = isChamberLoaded; // Инициализация поля состояния патронника
        }

       

        public void Reload()
        {
            if (isSafetyOn) // Проверка, включен ли предохранитель
            {
                throw new InvalidOperationException("Предохранитель включен, перезарядка невозможна!"); // Бросить исключение, если предохранитель включен
            }
            if (magazine.GetBulletCount() == 0) // Проверка, есть ли патроны в магазине
            {
                throw new InvalidOperationException("Магазин пуст, перезарядка невозможна!"); // Бросить исключение, если магазин пуст
            }
            isChamberLoaded = true; // Пометить патронник как заряженный
        }

        public bool PullTrigger()
        {
            if (isSafetyOn || !isChamberLoaded) // Проверка, включен ли предохранитель или заряжен ли патронник
            {
                return false; // Вернуть false, если патронник не заряжен или включен предохранитель
            }
            magazine.ExtractBullet(); // Извлечь патрон из магазина
            lastFiredBullet = magazine.ExtractBullet();
            isChamberLoaded = false; // Пометить патронник как незаряженный
            return true; // Вернуть true, если выстрел произведен успешно
        }

        public Bullet LastFiredBullet
        {
            get { return lastFiredBullet; }
        }

        public void ToggleSafety()
        {
            isSafetyOn = !isSafetyOn;
        }
        public void ToggleMagazine(Magazine newMagazine)
        {
            this.magazine = newMagazine;
        }
        public bool IsSafetyOn()
        {
            return isSafetyOn;
        }

        public bool IsChamberLoaded()
        {
            return isChamberLoaded;
        }

        public Magazine GetMagazine()
        {
            return magazine;
        }

        public void LoadMagazine(Magazine magazine)
        {
            if (isSafetyOn)
            {
                throw new InvalidOperationException("Safety is on. Cannot load magazine.");
            }
            if (magazine.GetBulletCount() == 0)
            {
                throw new InvalidOperationException("Magazine is empty. Cannot load magazine.");
            }

            this.magazine = magazine;
            isChamberLoaded = true;
        }
    }
}
