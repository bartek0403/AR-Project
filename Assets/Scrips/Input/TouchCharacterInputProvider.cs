using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BWG
{
    public class TouchCharacterInputProvider : ICharacterInputProvider
    {
        static readonly float cooldown = 0.5f;

        private float _lastInputSuccessTime;

        public bool GetLeftDirection()
        {
            if (Time.time > _lastInputSuccessTime + cooldown)
                if (Input.touchCount > 0)
                {
                    var touch = Input.GetTouch(0);
                    if (touch.position.x < Screen.width / 2)
                    {
                        _lastInputSuccessTime = Time.time;
                        return true;
                    }
                }
            return false;
        }

        public bool GetRightDirection()
        {
            if (Time.time > _lastInputSuccessTime + cooldown)
                if (Input.touchCount > 0)
                {
                    var touch = Input.GetTouch(0);
                    if (touch.position.x >= Screen.width / 2)
                    {
                        _lastInputSuccessTime = Time.time;
                        return true;
                    }
                }
            return false;
        }
    }
}
