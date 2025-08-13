using UnityEngine;
using UnityEngine.Events;

namespace TeamThree
{
    public class SmallContainer : MonoBehaviour
    {
        [SerializeField] private GameObject objectToDrop;
        private Animator containerAnimator;
        private int turn = Animator.StringToHash("Turn");
        private bool actionTriggered = false;
        [SerializeField] private UnityEvent onTaskComplete;
        private void OnEnable()
        {
            containerAnimator = GetComponent<Animator>();
            actionTriggered = false;
        }
        public void Turn()
        {
            if (actionTriggered) return;
            containerAnimator.SetTrigger(turn);
            Invoke("NextTask", 1);
            actionTriggered = true;
        }
        void NextTask()
        {
            onTaskComplete?.Invoke();
            GelElectrophoresisProcedure.Instance.NextStep();
            this.gameObject.SetActive(false);
        }
        public void DropContent()
        {
            if(objectToDrop!=null)
                objectToDrop.SetActive(true);
        }
    }
}
