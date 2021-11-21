using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BWG
{
    public interface ICharacterInputProvider
    {
        bool GetLeftDirection();
        bool GetRightDirection();
    }
}
