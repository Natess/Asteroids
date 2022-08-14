using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Asteroids
{
    public sealed class StandingState : State
    {
        private Player player;
        private StateMachine stateMachine;
        private float verticalInput;
        private float horizontalInput;

        public StandingState(Player player, StateMachine stateMachine)
        {
            this.player = player;
            this.stateMachine = stateMachine;
        }

        public override void Enter()
        {
            base.Enter();
            horizontalInput = verticalInput = 0.0f;
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
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (verticalInput != 0f || horizontalInput != 0f)
            {
                Debug.Log("Motion");
                stateMachine.ChangeState(player.motion);
            }
        }

    }

}
