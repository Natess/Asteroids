using UnityEngine;

namespace Asteroids
{
    internal class PlayerInputController : IExecute, IFixedExecute
    {
        private readonly Player _player;
        private readonly Camera _camera;
        private readonly TimeRewindController _timeRewindController;

        public PlayerInputController(Player player, Camera camera, TimeRewindController timeRewindController)
        {
            _player = player;
            _camera = camera;
            _timeRewindController = timeRewindController;
        }
        public void FixedUpdate()
        {
            _player.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            var direction = Input.mousePosition - _camera.WorldToScreenPoint(_player.transform.position);
            _player.Rotation(direction);

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _player.AddAcceleration();
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _player.RemoveAcceleration();
            }

            if (Input.GetButton("Fire1"))
            {
                _player.Fire();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _player.UnlockWeapon();
            }
        }

        public void Update()
        { 
            if(Input.GetKeyDown(KeyCode.Space))
            {
                _player.UnlockWeapon();
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                _timeRewindController.StartRewind();
            }
            if (Input.GetKeyUp(KeyCode.Q))
            {
                _timeRewindController.StopRewind();
            }
        }
    }
}
