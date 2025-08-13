using TMPro;
using Unity.IntegerTime;
using UnityEngine;

namespace TeamThree
{
    public class TimeManager : MonoBehaviour
    {
        public static TimeManager Instance;
        [SerializeField] private TextMeshProUGUI timeText;
        public int CurrentMinute = 0;
        public int CurrentHour = 0;
        [Tooltip("Total Minutes is used to track the number of minutes to wait for a process to finish since it doesn't reset")]
        public int TotalMinutes = 0;
        private float seconds;


        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        }
        private void Update()
        {
            UpdateTime();
        }
        void UpdateTime()
        {
            seconds += Time.deltaTime;
            if(seconds>=10)
            {
                TotalMinutes += 1;
                CurrentMinute += 1;
                if(CurrentMinute>=60)
                {
                    CurrentHour += 1;
                    if(CurrentHour>=24)
                    {
                        CurrentHour = 0;
                    }
                    CurrentMinute = 0;
                }
                seconds = 0;
            }
            if (CurrentMinute <= 9)
                if (CurrentHour <= 9)
                    timeText.text = $"0{CurrentHour} : 0{CurrentMinute}";
                else
                    timeText.text = $"{CurrentHour} : 0{CurrentMinute}";
            else if (CurrentMinute >= 10)
                if (CurrentHour <= 9)
                    timeText.text = $"0{CurrentHour} : {CurrentMinute}";
                else
                    timeText.text = $"{CurrentHour} : {CurrentMinute}";
            else
                timeText.text = $"{CurrentHour} : {CurrentMinute}";
            
        }

    }
}
