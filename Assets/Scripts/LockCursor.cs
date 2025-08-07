using UnityEngine;

namespace TeamSix
{
    public class LockCursor : MonoBehaviour
    {
        [SerializeField]private bool showCursor = false;

        private void Update()
        {
            if (showCursor)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
               Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
