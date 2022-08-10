namespace Asteroids
{
    internal class AddHealthModifier : PlayerModifier
    {
        private int health;

        public AddHealthModifier(Player player, int health) : base(player)
        {
            this.health = health;
        }

        public override void Handle()
        {
            player.PlayerHealth.AddHealth(health);
            base.Handle();
        }
    }
}