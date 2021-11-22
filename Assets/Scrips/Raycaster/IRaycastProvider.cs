using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BWG
{
    public interface IRaycastProvider
    {
        Pose GetRaycastResult(Vector3 viewportPos);
        Vector2 GetPositionOnScreen(Vector3 worldPos);
    }
}
