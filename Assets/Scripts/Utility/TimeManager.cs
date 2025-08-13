using TMPro;
using UnityEngine;

namespace TeamThree
{
    public class TimeManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timeText;
        public int CurrentMinute = 0;
        public int CurrentHour = 0;
        private float seconds;

        private void Update()
        {
            UpdateTime();
        }
        void UpdateTime()
        {
            seconds += Time.deltaTime;
            if(seconds>=10)
            {
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

            timeText.text = $"{CurrentHour} : {CurrentMinute}";
        }

    }
}
