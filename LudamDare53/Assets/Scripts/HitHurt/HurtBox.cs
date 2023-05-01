using System;
using System.Reflection;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.HitHurt
{
    public class HurtBox : MonoBehaviour, IHurtBox
    {
        [SerializeField] private float hitPoints = 10;

        [SerializeField] private TextMeshProUGUI hitPointsText;

        [SerializeField] private GameObject damageText;

        public event Action<float> OnHurt;

        public event Action HitPointsAreZero;

        [SerializeField] private bool destroyGameObjectWhenHitPointsAreZero = true;


        void Start()
        {
            UpdateHitPoints();
            if (destroyGameObjectWhenHitPointsAreZero)
            {
                HitPointsAreZero = Die;
            }
        }

        public float GetHitPoints()
        {
            return hitPoints;
        }

        public void TakeDamage(float damage)
        {
            Debug.Log(MethodBase.GetCurrentMethod().DeclaringType.Name + "::" + MethodBase.GetCurrentMethod());
            hitPoints -= damage;
            UpdateHitPoints();
            if (hitPoints <= 0)
            {
                if (damageText != null)
                {
                    Instantiate(damageText, transform.position, Quaternion.identity).GetComponent<HurtText>().SetText(damage.ToString());
                }
                if (OnHurt != null)
                {
                    OnHurt.Invoke(damage);
                }
                if (HitPointsAreZero != null)
                {
                    HitPointsAreZero.Invoke();
                }
            }
        }

        protected virtual void UpdateHitPoints()
        {

            if (hitPointsText != null)
            {
                hitPointsText.text = GetHitPoints().ToString();
            }
        }

        protected virtual void Die()
        {
            Destroy(gameObject);
        }
    }
}
