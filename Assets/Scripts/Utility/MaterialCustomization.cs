using UnityEngine;

namespace TeamThree
{
    public class MaterialCustomization : MonoBehaviour
    {
        [SerializeField] private Material gearMaterial;
        [SerializeField] private Color[] allowedColors;
        private void Start()
        {
            SetColor(0);
        }
        public void SetColor(int colorIndex)
        {
            if (allowedColors == null || allowedColors.Length < 1) return;
            gearMaterial.color = allowedColors[colorIndex];
        }

    }
}
