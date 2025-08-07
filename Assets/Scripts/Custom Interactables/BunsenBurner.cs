using UnityEngine;

namespace TeamSix
{
    public class BunsenBurner : CustomInteractable
    {
        private bool fireOn = false;
        private ParticleSystem fire;
        private AudioSource fireSource;

        public override void Interact()
        {
            fireOn = !fireOn;


            if (fireOn)
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
        }

    }
}
