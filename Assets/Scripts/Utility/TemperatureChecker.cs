using UnityEngine;
using UnityEngine.Events;

namespace TeamThree
{
    public class TemperatureChecker : MonoBehaviour
    {

        public UnityEvent OnTimeReached;
        private int CurrentMinute { get { return TimeManager.Instance.TotalMinutes; } }
        private int ETA;
        [Tooltip("This is the number of minutes the solution should heat for")]
        [SerializeField] private int TimeItTakesToComplete;
        private bool isHeating = false;
        private bool doneHeating = false;
        private void OnTriggerStay(Collider other)
        {
            BunsenBurner b = other.GetComponent<BunsenBurner>();
            if (b != null)
            {
                if (b.FireOn && !isHeating)
                {
                    ETA += TimeItTakesToComplete + CurrentMinute;
                    isHeating = true;
                }

                if (isHeating)
                {
                    if (CurrentMinute >= ETA)
                    {
                        if (doneHeating) return;
                        OnTimeReached?.Invoke();
                        GelElectrophoresisProcedure.Instance.NextStep();
                        doneHeating = true;
                    }
                }
            }
        }
        private void OnTriggerExit(Collider other)
        {
            BunsenBurner b = other.GetComponent<BunsenBurner>();
            if (b != null)
            {
                isHeating = false;
            }
        }
    }
}
