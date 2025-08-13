using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace TeamThree
{
    public class GelElectrophoresisProcedure : MonoBehaviour
    {
        public static GelElectrophoresisProcedure Instance;


        [Header("Procedure")]
        public Procedure CurrentProcedure;
        public Procedure gelPreparation;
        public Procedure[] SamplesPreparation;
        private bool hasPreparedGel = false;

        [Header("UI")]
        [SerializeField] private GameObject gelPreparationUI;
        [SerializeField] private GameObject samplePreparationUI;
        [SerializeField] private TextMeshProUGUI procedureText;
        [SerializeField] private TextMeshProUGUI currentStepText;
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        }
        public void StartProcedure(int sampleToPrepare)
        {
            if (!hasPreparedGel)
                CurrentProcedure = gelPreparation;
            else
                CurrentProcedure = SamplesPreparation[sampleToPrepare];



            foreach (var item in CurrentProcedure.ProcedureStep)
            {
                if(item.StepApparatus!=null)
                    item.StepApparatus.SetActive(false);
            }

            gelPreparationUI.SetActive(false);
            samplePreparationUI.SetActive(false);
            procedureText.text = CurrentProcedure.ProcedureName;
            DisplayDetails();
        }
        public void NextStep()
        {
            var step = CurrentProcedure.ProcedureStep[CurrentProcedure.CurrentStep];
            if(step.StepApparatus!=null)
                step.StepApparatus.SetActive(false);
            if (CurrentProcedure.CurrentStep >= CurrentProcedure.ProcedureStep.Length - 1)
            {
                EndProcedure();
                return;
            }
            CurrentProcedure.CurrentStep++;
            DisplayDetails();
        }
        void DisplayDetails()
        {
            var step = CurrentProcedure.ProcedureStep[CurrentProcedure.CurrentStep];
            currentStepText.text = step.StepDescription;
            if(step.StepApparatus!=null)
                step.StepApparatus.SetActive(true);
        }
        void EndProcedure()
        {
            samplePreparationUI.SetActive(true);
            procedureText.text = "none";
            currentStepText.text = "Start a sample on the lab table";
        }
    }
    [System.Serializable]
    public class Procedure
    {
        //Each procedure like preparing samples and all can be written here
        public string ProcedureName;
        public Step[] ProcedureStep;
        [HideInInspector]public int CurrentStep = 0;
    }
    [System.Serializable]
    public class Step
    {
        [TextArea(2,2)]
        public string StepDescription;
        public GameObject StepApparatus;
    }

}
