using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BWG.Test
{
    public class FakeCharacterInputProvider : ICharacterInputProvider
    {
        private bool _leftDir, _rightDir;

        public bool GetLeftDirection()
        {
            var dir = _leftDir;
            _leftDir = false;
            return dir;
        }

        public bool GetRightDirection()
        {
            var dir = _rightDir;
            _rightDir = false;
            return dir;
        }

        public void SetFakeInput(bool leftDir, bool rightDir)
        {
            _leftDir = leftDir;
            _rightDir = rightDir;
        }
    }
}
