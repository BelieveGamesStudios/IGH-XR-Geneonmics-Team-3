using Believe.Games.Studios;
using UnityEngine;

namespace TeamSix
{
    [RequireComponent(typeof(AudioSource))]
    public class Glassware : CustomInteractable
    {
        private AudioSource clinkSource;
        private void OnEnable()
        {
            clinkSource = GetComponent<AudioSource>();
        }
        private void OnCollisionEnter(Collision collision)
        {
            clinkSource.Play();
        }
        public override void Interact()
        {
            AudioManager.Instance.PlaySound("Interact");
        }
    }
}
