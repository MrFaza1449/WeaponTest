using Weapon;
using Xunit;

namespace WeaponTest
{
    public class MagazineTests
    {
        
        [Fact] // Проверка, возвращает ли извлечение патрона null, когда магазин пуст.
        public void MagazineIsEmpty_ExtractBullet_ReturnsNull()
        {
            // Arrange
            var magazine = new Magazine(1);  // Создание магазина с вместимостью 1.

            // Act
            var extractedBullet = magazine.ExtractBullet(); // Извлечение патрона из магазина.

            // Assert
            Assert.Null(extractedBullet); // Проверка, что извлеченный патрон равен null.
        }

        
        [Fact] // Проверка, увеличивается ли количество патронов при добавлении нового патрона в пустой магазин.
        public void MagazineIsEmpty_AddBullet_BulletCountIncreases()
        {
            // Arrange
            var magazine = new Magazine(1); // Создание магазина с вместимостью 1.
            var bullet = new Bullet(); // Создание нового патрона.

            // Act
            magazine.AddBullet(bullet); // Добавление патрона в магазин.

            // Assert
            Assert.Equal(1, magazine.GetBulletCount()); // Проверка, что количество патронов увеличилось до 1.
        }

        
        [Fact] // Проверка, уменьшается ли количество патронов при извлечении патрона из частично заполненного магазина.
        public void MagazineIsPartiallyFilled_ExtractBullet_BulletCountDecreases()
        {
            // Arrange
            var magazine = new Magazine(2); // Создание магазина с вместимостью 2.
            magazine.AddBullet(new Bullet()); // Добавление первого патрона в магазин.
            magazine.AddBullet(new Bullet()); // Добавление второго патрона в магазин.

            // Act
            magazine.ExtractBullet(); // Извлечение патрона из магазина.

            // Assert
            Assert.Equal(1, magazine.GetBulletCount()); // Проверка, что количество патронов уменьшилось до 1.
        }

        
        [Fact] // Проверка, вызывает ли добавление патрона в полный магазин исключение.
        public void MagazineIsFull_AddBullet_ThrowsException()
        {
            // Arrange
            var magazine = new Magazine(1); // Создание магазина с вместимостью 1.
            magazine.AddBullet(new Bullet()); // Добавление патрона в магазин.

            // Act & Assert
            Assert.Throws<System.InvalidOperationException>(() => magazine.AddBullet(new Bullet())); // Проверка, что при попытке добавить патрон в полный магазин генерируется исключение.
        }
    }
}
