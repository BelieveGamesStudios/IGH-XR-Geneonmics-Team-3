using UnityEngine;

namespace TeamThree
{
    [RequireComponent(typeof(BoxCollider))]
    public class ContainerMouth : MonoBehaviour
    {
        private void OnEnable()
        {
            GetComponent<BoxCollider>().isTrigger = true;
        }
        private void OnTriggerEnter(Collider other)
        {
            SmallContainer smallContainer = other.GetComponent<SmallContainer>();
            if (smallContainer != null)
            {
                smallContainer.Turn();
            }
        }
    }

}