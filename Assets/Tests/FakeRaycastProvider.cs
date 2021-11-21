using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BWG.Test
{
    public class FakeRaycastProvider : IRaycastProvider
    {
        public Vector2 GetPositionOnScreen(Vector3 worldPos)
        {
            return default;
        }

        public Pose GetRaycastResult(Vector3 origin)
        {
            return default;
        }
    }
}
