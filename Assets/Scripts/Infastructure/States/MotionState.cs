using UnityEngine;

namespace Asteroids
{
    public sealed class MotionState : State
    {
        private Player player;
        private StateMachine stateMachine;
        private float verticalInput;
        private float horizontalInput;

        public MotionState(Player player, StateMachine stateMachine)
        {
            this.player = player;
            this.stateMachine = stateMachine;
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void HandleInput()
        {
            base.HandleInput();
            verticalInput = Input.GetAxis("Vertical");
            horizontalInput = Input.GetAxis("Horizontal");
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            player.Move(horizontalInput, verticalInput);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (verticalInput == 0f || horizontalInput == 0f)
            {
                Debug.Log("Standing");
                stateMachine.ChangeState(player.standing);
            }
        }
    }

}