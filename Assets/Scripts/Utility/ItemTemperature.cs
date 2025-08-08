using TMPro;
using UnityEngine;

namespace TeamThree
{
    [RequireComponent(typeof(BoxCollider))]
    public class ItemTemperature : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI temperatureText;

        [SerializeField] private float temperatureChangeRate=1f;
        private float currentTemperature;
        private bool inFridge = false;
        private void OnEnable()
        {
            currentTemperature = Random.Range(20, 40);
            GetComponent<BoxCollider>().isTrigger = true;
        }
        private void OnTriggerEnter(Collider other)
        {
            var fridge = other.GetComponent<Cooling>();
            if(fridge!=null)
            {
                inFridge = true;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            var fridge = other.GetComponent<Cooling>();
            if (fridge != null)
            {
                inFridge = false;
            }
        }
        private void Update()
        {
            UpdateTemps();
        }
        void UpdateTemps()
        {
            if (inFridge)
                currentTemperature -= temperatureChangeRate * Time.deltaTime;
            else
                currentTemperature += temperatureChangeRate * Time.deltaTime;

            temperatureText.text = currentTemperature.ToString("0") + "°C";
        }
    }
}
