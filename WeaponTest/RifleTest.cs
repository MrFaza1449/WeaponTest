using System;
using Weapon;
using Xunit;

namespace WeaponTest
{
    public class RifleTests
    {
        [Fact]
        public void RifleReload_WithSafetyOn_ThrowsException() // Перезарядка винтовки при включенном предохранителе выбрасывает исключение
        {
            // Подготовка: создание объектов магазина и винтовки с установленным предохранителем
            var magazine = new Magazine(1);
            var rifle = new Rifle(magazine, true, false);

            // Действие и проверка утверждения, что исключение будет брошено при перезарядке
            Assert.Throws<InvalidOperationException>(() => rifle.Reload());
        }

        [Fact]
        public void RifleReload_MagazineEmpty_ThrowsException() // Пустой магазин винтовки при перезарядке выбрасывает исключение
        {
            // Подготовка: создание пустого магазина и винтовки
            var magazine = new Magazine(0);
            var rifle = new Rifle(magazine, false, false);

            // Действие и проверка утверждения, что исключение будет брошено при перезарядке
            Assert.Throws<InvalidOperationException>(() => rifle.Reload());
        }

        [Fact]
        public void RifleReload_MagazineNotEmpty_Success()
        {
            // Подготовка: создание магазина с одним патроном и винтовки
            var magazine = new Magazine(1);
            magazine.AddBullet(new Bullet()); // Добавление патронов в магазин
            var rifle = new Rifle(magazine, false, false);

            // Действие: перезарядка
            rifle.Reload();

            // Проверка утверждения, что патрон успешно помещен в патронник
            Assert.True(rifle.IsChamberLoaded());
        }

        [Fact]
        public void RifleTriggerPull_WithSafetyOn_NoShotFired() //Нажатие на спусковой крючок винтовки при включенном предохранителе без выстрела
        {
            // Подготовка: создание винтовки с установленным предохранителем
            var magazine = new Magazine(1);
            var rifle = new Rifle(magazine, true, false);

            // Действие: нажатие на спусковой крючок
            var result = rifle.PullTrigger();

            // Проверка утверждения, что выстрел не произошел
            Assert.False(result);
        }

        [Fact]
        public void RifleTriggerPull_WithoutReload_NoShotFired() // Нажатие на спусковой крючок винтовки без перезарядки без выстрела
        {
            // Подготовка: создание винтовки без перезарядки
            var magazine = new Magazine(1);
            var rifle = new Rifle(magazine, false, false);

            // Действие: нажатие на спусковой крючок
            var result = rifle.PullTrigger();

            // Проверка утверждения, что выстрел не произошел
            Assert.False(result);
        }

        [Fact]
        public void RifleTriggerPull_AfterReload_ReturnsUsedBullet()
        {
            // Подготовка: создание магазина с одним патроном и винтовки с перезарядкой
            var magazine = new Magazine(1);
            magazine.AddBullet(new Bullet());
            var rifle = new Rifle(magazine, false, false);
            rifle.Reload();

            // Действие: нажатие на спусковой крючок
            var result = rifle.PullTrigger();

            // Проверка утверждения, что патрон успешно использован
            Assert.True(result);
        }

        [Fact]
        public void RifleTohhleSafety_ON()
        {
            var magazine = new Magazine(1);
            var rifle = new Rifle(magazine, false, true);

            rifle.ToggleSafety();

            Assert.True(rifle.IsSafetyOn());
        }

        [Fact]
        public void RifleTohhleSafety_Off()
        {
            var magazine = new Magazine(1);
            var rifle = new Rifle(magazine, true, false);

            rifle.ToggleSafety();

            Assert.False(rifle.IsSafetyOn());
        }

        [Fact]
        public void RifleToggleMagazine()
        {
            var magazine1 = new Magazine(1);
            var magazine2 = new Magazine(1);
            var rifle = new Rifle(magazine1, false, false);

            rifle.ToggleMagazine(magazine2);

            Assert.Same(magazine2, rifle.GetMagazine());
        }

        [Fact]
        public void Rifle_ShouldReturnFiredBullet()
        {
            // Arrange
            var magazine = new Magazine(1);     
            var bullet = new Bullet();          
            magazine.AddBullet(bullet);          
            var rifle = new Rifle(magazine, false, false);  

            // Act
            rifle.Reload();                      
            rifle.PullTrigger();               

            // Assert
            Assert.Null(rifle.LastFiredBullet);  
        }
    }
}
