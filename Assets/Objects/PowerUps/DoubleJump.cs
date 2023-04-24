namespace Assets.Objects.PowerUps
{
    public class DoubleJump : PowerUp
    {
        protected override void EnablePowerUp()
        {
            // Enable double jump
            _playerMove.EnableDoubleJump();
        }
        
    }
}
