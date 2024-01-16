using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SoundManager : MonoBehaviour
{
    #region Singleton
    public static SoundManager instance;
    private void Awake()
    {
        if (instance != null && instance != this) Destroy(this.gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }
    #endregion

    [SerializeField] AudioSource RocketSource;
    [SerializeField] AudioSource EffectSource;
    [SerializeField] AudioSource MusicSource;

    [SerializeField] AudioClip mainMenuMusic;

    [Header("----------- ROCKET SOUNDS -----------")]
    [SerializeField] AudioClip rocketBooster;
    [SerializeField] AudioClip rocketFreeFall;
    [SerializeField] AudioClip rocketExplode;
    [Header("----------- EFFECT SOUNDS -----------")]
    [SerializeField] AudioClip coinSound;
    [SerializeField] AudioClip fuelSound;
    [SerializeField] AudioClip fuelBlastSound;
    [SerializeField] AudioClip buttonPressed;
    [SerializeField] AudioClip popper;

    private void Start()
    {
        MusicSource.Play();
    }

    void PlaySoundFX(string clip, float volume)
    {
        if (clip != null)
        {
            switch (clip)
            {
                case "coin":
                    EffectSource.pitch = 1f;
                    EffectSource.volume = volume;
                    EffectSource.PlayOneShot(coinSound);
                    break;

                case "fuel":
                    EffectSource.pitch = 1f;
                    EffectSource.volume = volume;
                    EffectSource.PlayOneShot(fuelSound);
                    break;

                case "fuel_blast":
                    EffectSource.pitch = 1f;
                    EffectSource.volume = volume;
                    EffectSource.PlayOneShot(fuelBlastSound);
                    break;

                case "button":
                    EffectSource.pitch = .9f;
                    EffectSource.volume = volume;
                    EffectSource.PlayOneShot(buttonPressed);
                    break;

                case "popper":
                    EffectSource.pitch = 1f;
                    EffectSource.volume = volume;
                    EffectSource.PlayOneShot(popper);
                    break;
                default:
                    break;
            }
        }
        else return;
    }

    #region Rocket Sound Functions
    public void ExplodeSoundFX()
    {
        RocketSource.loop = false;
        RocketSource.Stop();
        RocketSource.volume = .2f;
        RocketSource.clip = rocketExplode;
        RocketSource.Play();
    }

    public void FinalStageSoundFX()
    {
        RocketSource.clip = rocketBooster;
        RocketSource.volume = .9f;
        RocketSource.DOPitch(2f, 5f);
    }

    public void FinalTargetSoundFX()
    {
        RocketSource.DOPitch(3f, 1f).SetEase(Ease.Linear);
    }

    public void OpenRocketSoundVolume()
    {
        RocketSource.volume = 0f;
        RocketSource.Play();
    }

    public void MuteRocketSound()
    {
        RocketSource.volume = 0f;
    }

    public void PlayRocketSoundFX_Boost()
    {
        RocketSource.clip = rocketBooster;
        RocketSource.DOPitch(1f, .2f);
        RocketSource.DOFade(.75f, .2f);
        RocketSource.Play();
    }

    public void PlayRocketSoundFX_Fall()
    {
        RocketSource.clip = rocketBooster;
        RocketSource.DOPitch(.7f, .2f);
        RocketSource.DOFade(.5f, .2f);
        RocketSource.Play();
    }
    #endregion

    #region Effect Sound Functions
    public void PlayPopperFX()
    {
        PlaySoundFX("popper", .2f);
    }

    public void PlayButtonPressedFX()
    {
        PlaySoundFX("button", .3f);
    }

    public void PlayCoinSoundFX()
    {
        PlaySoundFX("coin", .5f);
    }

    public void PlayFuelSoundFX()
    {
        PlaySoundFX("fuel", 1f);
        PlaySoundFX("fuel_blast", .1f);
    }

    public void MuteEffectSource()
    {
        EffectSource.volume = 0f;
    }
    #endregion

    #region Music Sound Functions
    public void DecreaseVolume_Music(float _val)
    {
        if (_val >= 0f)
        {
            MusicSource.DOFade(_val, .5f);
            //MusicSource.Stop();
            //MusicSource.Play();
        }
    }

    public void IncreaseVolume_Music(float _val)
    {
        if (_val >= 0f && _val > MusicSource.volume)
        {
            MusicSource.DOFade(_val, .5f);
            //MusicSource.Stop();
            //MusicSource.Play();
        }
    }
    #endregion

}
