using TMPro;
using UnityEngine;

namespace Assets.Scripts.HitHurt
{
    public class HurtText : MonoBehaviour
    {
        [SerializeField] private float speed = 1f;

        private TextMeshPro damageText;

        public HurtText Initialize(string textContent, float? textSpeed = null)
        {
            if (textSpeed != null && textSpeed.HasValue)
            {
                this.speed = textSpeed.Value;
            }
            SetText(textContent);
            return this;
        }

        public void SetText(string value)
        {
            if (damageText != null)
            {
                damageText.text = value;
            }
        }

        void FixedUpdate()
        {
            transform.Translate(new Vector3(0, speed * Time.fixedDeltaTime, 0));
        }
    }
}