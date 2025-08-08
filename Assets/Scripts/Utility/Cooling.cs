using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace TeamThree
{
    public class Cooling : MonoBehaviour
    {
        [SerializeField] private ItemTemperature temperatureUI;


        private void OnTriggerEnter(Collider other)
        {
            var existingTemp = other.GetComponentInChildren<ItemTemperature>();
            if (existingTemp != null) return;


            var item = other.GetComponent<XRGrabInteractable>();
            if(item!=null)
            {
               ItemTemperature coolAgent = Instantiate(temperatureUI, item.transform);
                Transform coolAgentTransform = coolAgent.transform;
                coolAgentTransform.localPosition = new Vector3(0,0,-0.1f);
            }
        }
    }
}
