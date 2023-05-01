using System.Collections;
using System.Reflection;
using UnityEngine;

namespace Assets.Scripts.HitHurt
{
    public class HitBox : MonoBehaviour
    {
        [SerializeField] protected float damage;

        [SerializeField] protected float rateOfFireInSeconds;

        [SerializeField] private AudioSource hitSound;

        /// <summary>
        /// Stores how many hits can occur before destroying the game object containing this component.
        /// </summary>
        [SerializeField] protected uint numberOfHitsRemainingBeforeDestruction = 1;

        /// <summary>
        /// Whether or not to track how many hits occurred.
        /// </summary>
        [SerializeField] protected bool CanCauseInfiniteHits = true;

        protected bool canDamage;

        private void Awake()
        {
            canDamage = true;
        }

        public virtual float GetDamage()
        {
            return damage;
        }

        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log(MethodBase.GetCurrentMethod().DeclaringType.Name + "::" + MethodBase.GetCurrentMethod());
            TryDamageObject(other);
        }

        protected virtual void TryDamageObject(Collider2D other)
        {
            if (canDamage)
            {
                if (!other.gameObject.CompareTag(gameObject.tag))
                {
                    if (other.gameObject.CompareTag(Tags.Collectible))
                    {
                        return;
                    }
                    if (hitSound != null)
                    {
                        hitSound.Play();
                    }
                    canDamage = false;
                    HitOccurred();
                    StartCoroutine(RateOfFireDamageReset());
                    other.GetComponent<IHurtBox>()?.TakeDamage(GetDamage());
                }
            }
        }

        protected virtual void HitOccurred()
        {
            // If the hit box has a limited number of hits, decrement how many remain.
            if (CanCauseInfiniteHits)
            {
                return;
            }
            else
            {
                numberOfHitsRemainingBeforeDestruction--;
            }

            // If there are no hits remaining for the hit box, destroy it.
            if (numberOfHitsRemainingBeforeDestruction == 0)
            {
                Destroy(gameObject);
            }
        }

        protected virtual IEnumerator RateOfFireDamageReset()
        {
            yield return new WaitForSeconds(rateOfFireInSeconds);
            canDamage = true;
        }
    }
}
