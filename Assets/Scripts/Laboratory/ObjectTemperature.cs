using UnityEngine;

namespace TeamThree
{
    public class ObjectTemperature : MonoBehaviour
    {
        public float currentTemperature = 20;

        [SerializeField] private GameObject steam;
        [SerializeField] private float boilingPoint = 100;
        public bool Heating = false;
        private void Update()
        {
            if (Heating == false)
                if(currentTemperature>=10)
                    currentTemperature -= 0.01f;

            if (currentTemperature >= boilingPoint && !steam.activeInHierarchy)
                steam.SetActive(true);
            else if (currentTemperature < boilingPoint && steam.activeInHierarchy)
                steam.SetActive(false);
        }
        private void OnTriggerStay(Collider other)
        {
            BunsenBurner b = other.GetComponent<BunsenBurner>();
            if(b!=null &&b.FireOn)
            {
                Heating = true;
                print("Present");
            }
            else
            {
                Heating = false;
                print("Absent");
            }
            
        }
        private void OnTriggerExit(Collider other)
        {
            BunsenBurner b = other.GetComponent<BunsenBurner>();
            if (b != null && b.FireOn)
            {
                Heating = false;
                print("Absent");
            }

        }
    }
}
