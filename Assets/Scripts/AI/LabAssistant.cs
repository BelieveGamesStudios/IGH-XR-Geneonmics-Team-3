using UnityEngine;
using UnityEngine.AI;

namespace TeamSix
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class LabAssistant : MonoBehaviour
    {
        [Header("Component")]
        private AudioSource dialogueSource;
        private NavMeshAgent agent;



        [Header("Dialogue")]
        [SerializeField] private Dialogue[] dialogues;
        private void OnEnable()
        {
            agent=GetComponent<NavMeshAgent>();
            dialogueSource = GetComponent<AudioSource>();
            PlayDialogue("Welcome Message");
        }
        public void PlayDialogue(string dialogueTag)
        {
            foreach (var dialogue in dialogues)
            {
                if (dialogue.Title == dialogueTag)
                {
                    if (dialogueSource != null && dialogue.AudioClip != null)
                    {
                        dialogueSource.clip = dialogue.AudioClip;
                        dialogueSource.Play();
                    }
                    else
                    {
                        Debug.LogWarning("AudioSource or AudioClip is missing for dialogue: " + dialogueTag);
                    }
                    return;
                }
            }
            Debug.LogWarning("Dialogue with tag '" + dialogueTag + "' not found.");
        }
    }
    [System.Serializable]
    public class Dialogue
    {
        public string Title;
        public AudioClip AudioClip;
    }
}
