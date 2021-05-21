using Platformer.Core;
using Platformer.Mechanics;

namespace Platformer.Gameplay.PlayerEvents
{
    /// <summary>
    /// Fired when a player enters a trigger with a DeathZone component.
    /// </summary>
    /// <typeparam name="PlayerEnteredDeathZone"></typeparam>
    public class PlayerEnteredDeathZone : Simulation.Event<PlayerEnteredDeathZone>
    {
        public DeathZone deathzone;

        public override void Execute()
        {
            Simulation.Schedule<PlayerDeath>(0);
        }
    }
}