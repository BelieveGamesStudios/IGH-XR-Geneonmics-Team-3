using TMPro;
using UnityEngine;

namespace TeamThree
{
    public class BunsenBurner : CustomInteractable
    {
        public bool FireOn = false;
        private ParticleSystem fire;
        private AudioSource fireSource;
        [SerializeField] private TextMeshProUGUI temperatureText;
        [SerializeField] private float heatingRate=0.01f;
        [SerializeField]private MeshRenderer meshRenderer;
        private Material triggerMaterial;
       
        public override void Interact()
        {
            FireOn = !FireOn;


            if (FireOn)
            {
                fire.Play();
                fireSource.Play();
            }
            else
            {
                fire.Stop();
                fireSource.Stop();
            }

        }

        private void OnEnable()
        {
            fireSource = GetComponent<AudioSource>();
            fire = GetComponentInChildren<ParticleSystem>();
            fire.Stop();
            fireSource.Stop();

            triggerMaterial = meshRenderer.material;
        }
        private void OnTriggerStay(Collider other)
        {
            ObjectTemperature objectTemp = other.GetComponentInChildren<ObjectTemperature>();
            if(objectTemp!=null)
            {
                var color = Color.green;
                color.a = 0.2f;
                triggerMaterial.color = color;

                if (FireOn)
                    objectTemp.currentTemperature += heatingRate;


                temperatureText.text = objectTemp.currentTemperature.ToString("F1")+ "°C";
            }
        }
        private void OnTriggerExit(Collider other)
        {
            ObjectTemperature objectTemp = other.GetComponentInChildren<ObjectTemperature>();
            if(objectTemp!=null)
            {
                var color = Color.green;
                color.a = 0.2f;
                triggerMaterial.color = color;
                temperatureText.text = "--°C";
            }
        }

    }
}
