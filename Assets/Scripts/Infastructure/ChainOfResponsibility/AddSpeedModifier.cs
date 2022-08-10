namespace Asteroids
{
    internal class AddSpeedModifier : PlayerModifier
    {
        private int speed;

        public AddSpeedModifier(Player player, int speed):base(player)
        {
            this.speed = speed;
        }

        public override void Handle()
        {
            player.PlayerMovement.AddSpeed(speed);
            base.Handle();
        }
    }
}