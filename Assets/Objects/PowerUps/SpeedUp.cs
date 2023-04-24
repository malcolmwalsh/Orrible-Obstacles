namespace Assets.Objects.PowerUps
{
    public class SpeedUp : PowerUp
    {
        protected override void EnablePowerUp()
        {
            // Speed up
            _playerMove.IncreaseSpeed();
        }
    }
}
