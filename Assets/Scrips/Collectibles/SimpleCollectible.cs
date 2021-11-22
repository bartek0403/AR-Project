using UnityEngine;

namespace BWG
{
    public class SimpleCollectible : MonoBehaviour, ICollectible
    {
        public virtual void Collect()
        {
            Destroy(gameObject);
        }
    }
}
