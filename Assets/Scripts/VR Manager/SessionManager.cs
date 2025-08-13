using TMPro;
using UnityEngine;

namespace TeamThree
{

    /// <summary>
    ///  This class ensures the user puts on all protective gears before he's allowed to perform any experiment in the lab
    /// </summary>
    public class SessionManager : MonoBehaviour
    {
        public static SessionManager Instance;
       

        [SerializeField] private TODO[] protectiveGearWearing;
        private int currentThingToDo = 0;

        [Header("Components")]
        [SerializeField]private TextMeshProUGUI toDoText;

        [Header("Gel Preparation")]
        [SerializeField] private GameObject gelPreparationStand;
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        }
        private void Start()
        {
            foreach  (TODO prep in protectiveGearWearing)
            {
                if (prep.objectToInteractWith != null)
                    prep.objectToInteractWith.gameObject.SetActive(false);
            }
            gelPreparationStand.SetActive(false);
            DisplayTask();
        }
        void DisplayTask()
        {
            if (protectiveGearWearing[currentThingToDo].objectToInteractWith!=null)
                protectiveGearWearing[currentThingToDo].objectToInteractWith.gameObject.SetActive(true) ;
            toDoText.text = protectiveGearWearing[currentThingToDo].WhatToDoDescription;
        }
        public void ShowNext()
        {
            if (currentThingToDo >= protectiveGearWearing.Length - 1)
            {
                EnableExperiment();
                return;
            }
            currentThingToDo++;
            DisplayTask();
        }
        void EnableExperiment()
        {
            toDoText.text = "Approach the lab table to start gel Electrophoresis";
            gelPreparationStand.SetActive(true);
        }
    }
    [System.Serializable]
    public class TODO
    {
        [TextArea(2,2)]
        public string WhatToDoDescription;
        public CustomInteractable objectToInteractWith;
    }
}
