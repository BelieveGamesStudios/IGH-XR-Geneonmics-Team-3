using UnityEngine;

namespace TeamThree
{
    public class PlayerMovement : MonoBehaviour
    {
        public static PlayerMovement Singleton;
        [Header("Components")]
        private Animator playerAnimator;

        [Header("Movement Variables")]
        //[SerializeField] private Transform cam;
        [SerializeField] private Vector3 currentPosition;
         
        [Header("Animation Hashes")]
        private int motion = Animator.StringToHash("Motion");
        private int interact = Animator.StringToHash("Interact");
        private void Awake()
        {
            if (Singleton == null)
                Singleton = this;
        }
        private void OnEnable()
        {
            //cam = Camera.main.transform;
            currentPosition = transform.position;
            playerAnimator = GetComponent<Animator>();
        }
        private void Update()
        {
            PlayAnimation();
        }
        void PlayAnimation()
        {
            if (playerAnimator == null) return;
            float speed = ((transform.position - currentPosition).magnitude) / Time.deltaTime;
            if (speed >= 0.1f)
                playerAnimator.SetFloat(motion, 1);
            else
                playerAnimator.SetFloat(motion, 0);
            currentPosition = transform.position;

        }
        public void Interact()
        {
            playerAnimator.SetTrigger(interact);
        }
    }
}
