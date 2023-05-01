using UnityEngine;

namespace Assets.Scripts.Audio
{
    public class SoundEffectPlayer : MonoBehaviour, ISoundEffectPlayer
    {
        [SerializeField] protected AudioClip soundEffectAudioClip;

        [SerializeField] protected AudioSource soundEffectAudioSource;

        [SerializeField] protected float soundEffectMinimumPitch = 1f;

        [SerializeField] protected float soundEffectMaximumPitch = 1f;

        private float averagePitch;

        protected virtual void Awake()
        {
            ValidatePitchRange();
        }

        protected virtual void Start()
        {
            soundEffectAudioSource = GetComponent<AudioSource>();
            if (soundEffectAudioSource == null && soundEffectAudioClip != null)
            {
                soundEffectAudioSource = gameObject.AddComponent<AudioSource>();
                soundEffectAudioSource.clip = soundEffectAudioClip;
                soundEffectAudioSource.volume = 1.0f;
                soundEffectAudioSource.loop = false;
                soundEffectAudioSource.playOnAwake = false;
            }
        }

        public void PlaySoundEffect(bool shouldRandomizePitch = true)
        {
            if (soundEffectAudioClip == null || soundEffectAudioSource == null)
            {
                return;
            }

            ValidatePitchRange();

            float originalPitch = soundEffectAudioSource.pitch;
            if (shouldRandomizePitch)
            {
                soundEffectAudioSource.pitch = Random.Range(soundEffectMinimumPitch, soundEffectMaximumPitch);
            }
            else
            {
                soundEffectAudioSource.pitch = averagePitch;
            }
            soundEffectAudioSource.PlayOneShot(soundEffectAudioClip);
            soundEffectAudioSource.pitch = originalPitch;
        }

        private void ValidatePitchRange()
        {
            if (soundEffectMinimumPitch < -3f)
            {
                soundEffectMinimumPitch = -3f;
            }
            if (soundEffectMinimumPitch > 3f)
            {
                soundEffectMinimumPitch = 3f;
            }
            if (soundEffectMaximumPitch < -3f)
            {
                soundEffectMaximumPitch = -3f;
            }
            if (soundEffectMaximumPitch > 3f)
            {
                soundEffectMaximumPitch = 3f;
            }
            if (soundEffectMaximumPitch < soundEffectMinimumPitch)
            {
                soundEffectMaximumPitch = soundEffectMinimumPitch;
            }
            averagePitch = (soundEffectMaximumPitch + soundEffectMinimumPitch) / 2f;
        }
    }
}
