using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Asteroids
{
    public sealed class TimeRewindController : IFixedExecute
    {
        //[SerializeField] 
        private float _recordTime = 5f;
        private List<PointInTime> _pointsInTime;
        private Rigidbody2D _rb;
        private bool _isRewinding;

        public TimeRewindController(Rigidbody2D rigidbody, float recordTime)
        {
            _pointsInTime = new List<PointInTime>();
            _rb = rigidbody;
            _recordTime = recordTime;
        }

        //public void Update()
        //{
        //    if (Input.GetKeyDown(KeyCode.Q))
        //    {
        //        StartRewind();
        //    }
        //    if (Input.GetKeyUp(KeyCode.Q))
        //    {
        //        StopRewind();
        //    }
        //}

        public void FixedUpdate()
        {
            if (_isRewinding)
            {
                Rewind();
            }
            else
            {
                Record();
            }
        }

        private void Rewind()
        {
            PointInTime pointInTime = _pointsInTime[0];
            _rb.transform.position = pointInTime.Position;
            _rb.transform.rotation = pointInTime.Rotation;
            if (_pointsInTime.Count > 1)
            {
                _pointsInTime.RemoveAt(0);
            }
            else
            {
                StopRewind();
            }
        }
        private void Record()
        {
            if (_pointsInTime.Count > Mathf.Round(_recordTime / Time.fixedDeltaTime))
            {
                _pointsInTime.RemoveAt(_pointsInTime.Count - 1);
            }
            _pointsInTime.Insert(0, new PointInTime(_rb.transform.position,
                _rb.transform.rotation, _rb.velocity, _rb.angularVelocity));
        }


        public void StartRewind()
        {
            _isRewinding = true;
            _rb.isKinematic = true;
        }

        public void StopRewind()
        {
            _isRewinding = false;
            _rb.isKinematic = false;
            _rb.velocity = _pointsInTime[0].Velocity;
            _rb.angularVelocity = _pointsInTime[0].AngularVelocity;
        }
    }
}
