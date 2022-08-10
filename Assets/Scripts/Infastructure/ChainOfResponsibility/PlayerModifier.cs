using System;

namespace Asteroids
{
    internal class PlayerModifier
    {
        protected Player player;
        protected PlayerModifier next;

        public PlayerModifier(Player player)
        {
            this.player = player;
        }

        internal void Add(PlayerModifier pm)
        {
            if(next != null)
            {
                next.Add(pm);
            }
            else
            {
                next = pm;
            }
        }

        public virtual void Handle() => next?.Handle();
    }
}