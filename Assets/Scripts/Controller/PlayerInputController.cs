using UnityEngine;

namespace Asteroids
{
    internal class PlayerInputController : IFixedExecute
    {
        private readonly Player _player;
        private readonly Camera _camera;

        public PlayerInputController(Player player, Camera camera)
        {
            _player = player;
            _camera = camera;
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
        }
    }
}
