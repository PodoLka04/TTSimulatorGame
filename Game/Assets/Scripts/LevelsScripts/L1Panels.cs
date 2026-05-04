using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using YG;
using System.Collections;


public class L1Panels : MonoBehaviour
{
    [SerializeField] private GameObject panel1;
    [SerializeField] private GameObject text;
    [SerializeField] private GameObject button;
    [SerializeField] private AudioSource YaySounds;

    private bool isAnimationPlaying; // Флаг для отслеживания анимации

    private void Start()
    {
        panel1.transform.localScale = Vector3.zero;
        text.transform.localScale = Vector3.zero;

    }

    private void Update()
    {
        if (Data.Instance.Is1LevelComp && !isAnimationPlaying)
        {
            PlayUnlockAnimation();
        }
    }

    private void PlayUnlockAnimation()
    {
        isAnimationPlaying = true;
        Data.Instance.Is1LevelComp = false;


        YaySounds.Play();
        panel1.SetActive(true);
        text.SetActive(true);

        panel1.transform.localScale = Vector3.zero;
        text.transform.localScale = Vector3.zero;

        panel1.transform.DOKill();
        text.transform.DOKill();

        Sequence unlockSequence = DOTween.Sequence();
        unlockSequence
            .Append(panel1.transform.DOScale(1, 1.5f).SetEase(Ease.OutBack))
            .AppendInterval(1f)
            .Join(text.transform.DOScale(1, 1.5f).SetEase(Ease.OutBack))
            .OnComplete(() => {
                Data.Instance.Is1LevelComp = false;
                isAnimationPlaying = false; // Сбрасываем флаг
            });
    }

    public void ClLevel1()
    {
        StartCoroutine(LoadSceneWithDelay());
    }

    private IEnumerator LoadSceneWithDelay()
    {
        

        // Ждем 0.5 секунды (можно уменьшить до 0.1-0.2 если нужно быстрее)
        yield return new WaitForSeconds(0.5f);

        // Загружаем сцену
        SceneManager.LoadScene("SampleScene");
    }









    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += Reward;//хз че это
    }
    private void OnDisable()
    {
        YandexGame.RewardVideoEvent -= Reward;//хз че это
    }

    public void Reward(int id)
    {
        Data.Instance.Is1LevelComp = true;
    }

    public void ADVbutt()
    {
        YandexGame.RewVideoShow(1);
        button.SetActive(false);

    }





    public void uioi()
    {
        YandexGame.FullscreenShow();
    }

}