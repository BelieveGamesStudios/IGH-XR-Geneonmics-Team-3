using UnityEngine;
using UnityEngine.AI;

namespace TeamThree
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class LabAssistant : MonoBehaviour
    {
        [Header("Component")]
        private Animator animator;
        private AudioSource dialogueSource;
        private NavMeshAgent agent;


        [Header("Player Tracking")]
        [Range(0.01f, 4)]
        [SerializeField] private float followDistance = 3f; // Distance at which the assistant will follow the player
        private Transform player;


        [Header("Dialogue")]
        [SerializeField] private Dialogue[] dialogues;
        [Range(0, 15)]
        [SerializeField] private float dialogueDelay;
        private float nextTimeToTalk;

        [Header("Animator Hashes")]
        private int motion = Animator.StringToHash("Motion");
        private int talk = Animator.StringToHash("Talk");
        private void OnEnable()
        {
            animator = GetComponent<Animator>();
            agent = GetComponent<NavMeshAgent>();
            dialogueSource = GetComponent<AudioSource>();
            player = Camera.main.transform;
            PlayDialogue("Welcome Message");
        }
        private void Update()
        {
            FollowPlayer();
            if (!dialogueSource.isPlaying)
                animator.SetBool(talk, false);
        }
        public void PlayDialogue(string dialogueTag)
        {
            if (Time.time < nextTimeToTalk) return;
            foreach (var dialogue in dialogues)
            {
                if (dialogue.Title == dialogueTag)
                {
                    if (dialogueSource != null && dialogue.AudioClip != null)
                    {
                        dialogueSource.clip = dialogue.AudioClip;
                        dialogueSource.Play();
                        animator.SetBool(talk, true);
                        nextTimeToTalk = Time.time + dialogueDelay;

                    }
                    return;
                }
            }
            Debug.LogWarning("Dialogue with tag '" + dialogueTag + "' not found.");
            nextTimeToTalk = Time.time + dialogueDelay;
        }
        public void ShutUp()
        {
            if (dialogueSource != null && dialogueSource.isPlaying)
            {
                dialogueSource.Stop();
            }
            animator.SetBool(talk, false);
        }
        void FollowPlayer()
        {

            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            if (distanceToPlayer >= followDistance)
            {
                animator.SetFloat(motion, Mathf.Lerp(animator.GetFloat(motion), 1, 10 * Time.deltaTime));
                agent.SetDestination(player.position);
                agent.isStopped = false;
            }
            else
            {
                animator.SetFloat(motion, Mathf.Lerp(animator.GetFloat(motion), 0, 10 * Time.deltaTime));
                LookAtPlayer();
                agent.isStopped = true;
            }
        }
        void LookAtPlayer()
        {
            Vector3 toPlayer = Camera.main.transform.position - transform.position;
            toPlayer = toPlayer.normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(toPlayer.x, 0, toPlayer.z));
            transform.rotation = lookRotation;
        }
        private void OnAnimatorMove()
        {
            float speed = 0;
            speed = (animator.deltaPosition / Time.deltaTime).magnitude;
            if (float.IsNaN(speed) == true)
                speed = 0;
            agent.speed = speed;
        }
    }
    [System.Serializable]
    public class Dialogue
    {
        public string Title;
        public AudioClip AudioClip;
    }
}
