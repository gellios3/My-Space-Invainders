using UnityEngine;

namespace Views.MainGame
{
    public class BoundaryView : MonoBehaviour
    {
        private void OnTriggerExit(Collider other)
        {
            Destroy(other.gameObject);
        }
    }
}