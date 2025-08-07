using Believe.Games.Studios;
using UnityEngine.UI;
using UnityEngine;

namespace TeamSix
{
    public class Fridge : CustomInteractable
    {
        [Header("Components")]
        [SerializeField] private Animator fridgeAnimator;
        [SerializeField] private Text fridgeText;

        private bool fridgeDoorOpen = false;
        private int doorHash=Animator.StringToHash("Door");
        public override void Interact()
        {
            fridgeDoorOpen=!fridgeDoorOpen;
            
            fridgeAnimator.SetBool(doorHash,fridgeDoorOpen);
            string fridgeSound = fridgeDoorOpen ? "Fridge Open" : "Fridge Close";
            AudioManager.Instance.PlaySound(fridgeSound);
            string fridgeButtonText = fridgeDoorOpen ? "Close Fridge" : "Open Fridge";
            fridgeText.text = fridgeButtonText;
        }
    }
}