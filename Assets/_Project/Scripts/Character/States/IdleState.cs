namespace BattleArena.Characters.States
{
    public class IdleState : ICharacterState
    {
        public void Enter(Character character)
        {
            character.AnimationManager.PlayAnimation(character.Weapon.weaponData.idleAnimationType);
        }

        public void Tick(Character character) { }
        public void Exit(Character character) { }
    }
}