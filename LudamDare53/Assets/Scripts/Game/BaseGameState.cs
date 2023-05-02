using Assets.Script.Game;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Assets.Script.Districts
{
    public abstract class BaseGameState : MonoBehaviour, IGameState
    {
        [SerializeField] protected List<GameObject> DistrictStateGameObjects;

        [SerializeField] protected AudioSource OnEnterSoundEffect;

        [SerializeField] protected AudioSource OnExitSoundEffect;

        public virtual void OnEnter()
        {
            Debug.Log(MethodBase.GetCurrentMethod().DeclaringType.Name + "::" + MethodBase.GetCurrentMethod());
            SetDistrictStateGameObjectsActiveState(true);
            PlaySoundEffect(OnEnterSoundEffect);
        }

        public virtual void OnExit()
        {
            PlaySoundEffect(OnExitSoundEffect);
            SetDistrictStateGameObjectsActiveState(false);
        }

        protected virtual void SetDistrictStateGameObjectsActiveState(bool state)
        {
            if (DistrictStateGameObjects != null)
            {
                foreach (var gameObject in DistrictStateGameObjects)
                {
                    if (gameObject != null)
                    {
                        gameObject.SetActive(state);
                    }
                }
            }
        }

        protected virtual void PlaySoundEffect(AudioSource source)
        {
            if (source != null)
            {
                source.Play();
            }
        }
    }
}
