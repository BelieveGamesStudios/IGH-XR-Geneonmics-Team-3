using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TeamThree
{

    [RequireComponent(typeof(MaterialCustomization))]
    public class ProtectiveGear : CustomInteractable
    {
        [Tooltip("The representation of the gear that hasn't been worn")]
        [SerializeField] private Transform gear;
        [Tooltip("The object we want to enable on the player")]
        [SerializeField] private GameObject partToEnable;

        [Tooltip("The time it takes to get to the player position")]
        [Range(0.1f, 1)]
        [SerializeField] private float lerpTime = 0.5f;
        [Tooltip("The time it takes to get to the player position")]
        [Range(0, 2)]
        [SerializeField] private float yOffset = 0.2f;

        [Tooltip("We want to disable this so the player can't wear a protective gear twice")]
        [SerializeField] private Button interactButton;
        [Tooltip("The text we'll change when the user wears the gear")]
        [SerializeField] private TextMeshProUGUI buttonText;

        public override void Interact()
        {
            PlayerMovement.Singleton.Interact();
            StartCoroutine("MoveTowardsPlayer");
        }
        IEnumerator MoveTowardsPlayer()
        {
            float timeElapsed = 0;
            while (timeElapsed <= .7f)
            {
                gear.position = Vector3.Lerp(gear.position, PlayerMovement.Singleton.transform.position + new Vector3(0, yOffset, 0), lerpTime);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            buttonText.text = "Already worn";
            interactButton.interactable = false;
            if(partToEnable!=null)
                partToEnable.SetActive(true);
            gear.gameObject.SetActive(false);
            SessionManager.Instance.ShowNext();
        }
    }
}
