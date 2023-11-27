using Weapon;
using Xunit;

namespace WeaponTest
{
    public class BulletTest
    {
        [Fact]
        public void BulletAlreadyUsed_ThrowsException()
        {
            // Arrange
            var bullet = new Bullet();
            bullet.Use(); // Устанавливаем пулю в качестве использованной

            // Act & Assert
            Assert.Throws<System.InvalidOperationException>(() => bullet.Use()); // Ожидаем исключение при повторной попытке использования
        }
    }
}