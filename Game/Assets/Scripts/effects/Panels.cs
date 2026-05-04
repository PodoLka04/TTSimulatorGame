using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;


public class Panels : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject LevelMenu;
    [SerializeField] private GameObject VideoMenu;

    [SerializeField] private Image darkOverlay;   // Затемнение (Чёрный UI Image)
    [SerializeField] private GameObject loadingScreen; // Экран загрузки
    public RectTransform loading_circle;

    [SerializeField] private GameObject Level1Button;
    [SerializeField] private GameObject Level2Button;
    [SerializeField] private GameObject Level3Button;
    [SerializeField] private GameObject Level4Button;
    [SerializeField] private GameObject Level5Button;
    [SerializeField] private GameObject Level6Button;
    [SerializeField] private GameObject Level7Button;
    [SerializeField] private GameObject Level8Button;
    [SerializeField] private GameObject Level9Button;




    void Start()
    {
        LevelMenu.SetActive(false);
        VideoMenu.SetActive(false);
        loadingScreen.SetActive(false);


        MainMenu.transform.localScale = Vector3.zero;
        MainMenu.transform.DOScale(1, 1.5f).SetEase(Ease.OutBack);

        
    }

    public void OpClLevelMenu()
    {
        LevelMenu.SetActive(!LevelMenu.activeSelf);
        MainMenu.SetActive(!MainMenu.activeSelf);

    }
    public void OpClVideoMenu()
    {
        VideoMenu.SetActive(!VideoMenu.activeSelf);
        MainMenu.SetActive(!MainMenu.activeSelf);
    }


    //--------------------

    public void uioi()
    {
        YandexGame.FullscreenShow();
    }

    //------------------------сохраения ниже(они переехали в data чтобы не ломаться)

  




    public void Enterlevel1()
    {

        // 2. Затемняем экран (0 → 0.8 прозрачности)
        darkOverlay.DOFade(1f, 1f).From(0);

        // 3. Увеличиваем телефон (эффект "погружения")
        Sequence mySequence = DOTween.Sequence();
        Level1Button.transform.SetAsLastSibling(); // Становится поверх всех

        // Добавляем анимации в последовательность ПАРАЛЛЕЛЬНО (через Join)
        mySequence.Join(Level1Button.transform.DOScale(5f, 1.5f).SetEase(Ease.InQuad));
        mySequence.Join(Level1Button.transform.DOMove(Vector3.zero, 1.5f).SetEase(Ease.InQuad));

        // Действие после завершения
        mySequence
            .OnComplete(() =>
    {
                // 4. Показываем экран загрузки
                loadingScreen.SetActive(true);
                loadingScreen.transform.localScale = Vector3.zero;
                loadingScreen.transform.DOScale(1, 0.5f)
                    .SetEase(Ease.OutBack);
                loading_circle.DORotate(new Vector3(0, 0, -360), 1.3f, RotateMode.LocalAxisAdd)
                .SetLoops(-1, LoopType.Restart)
                .SetEase(Ease.Linear);
            });
    }

    IEnumerator LoadSceneAfterDelay1()
    {
        // Ждём указанное количество секунд
        yield return new WaitForSeconds(5f);

        // Загружаем новую сцену
        SceneManager.LoadScene("Level1");
    }

    public void Load_to_NewScene1()
    {
        StartCoroutine(LoadSceneAfterDelay1());
    }


    //----------------------------------------------------------------------------------------------------------------------------------------------------
    //----------------------------------------------------------------------------------------------------------------------------------------------------

    public void Enterlevel2()
    {

        // 2. Затемняем экран (0 → 0.8 прозрачности)
        darkOverlay.DOFade(1f, 1f).From(0);

        // 3. Увеличиваем телефон (эффект "погружения")
        Sequence mySequence = DOTween.Sequence();
        Level2Button.transform.SetAsLastSibling(); // Становится поверх всех

        // Добавляем анимации в последовательность ПАРАЛЛЕЛЬНО (через Join)
        mySequence.Join(Level2Button.transform.DOScale(5f, 1.5f).SetEase(Ease.InQuad));
        mySequence.Join(Level2Button.transform.DOMove(Vector3.zero, 1.5f).SetEase(Ease.InQuad));

        // Действие после завершения
        mySequence
            .OnComplete(() =>
            {
                // 4. Показываем экран загрузки
                loadingScreen.SetActive(true);
                loadingScreen.transform.localScale = Vector3.zero;
                loadingScreen.transform.DOScale(1, 0.5f)
                    .SetEase(Ease.OutBack);
                loading_circle.DORotate(new Vector3(0, 0, -360), 1.3f, RotateMode.LocalAxisAdd)
                .SetLoops(-1, LoopType.Restart)
                .SetEase(Ease.Linear);
            });
    }

    IEnumerator LoadSceneAfterDelay2()
    {
        // Ждём указанное количество секунд
        yield return new WaitForSeconds(5f);

        // Загружаем новую сцену
        SceneManager.LoadScene("Level2");
    }

    public void Load_to_NewScene2()
    {
        StartCoroutine(LoadSceneAfterDelay2());
    }

    //----------------------------------------------------------------------------------------------------------------------------------------------------
    //----------------------------------------------------------------------------------------------------------------------------------------------------

    public void Enterlevel3()
    {

        // 2. Затемняем экран (0 → 0.8 прозрачности)
        darkOverlay.DOFade(1f, 1f).From(0);

        // 3. Увеличиваем телефон (эффект "погружения")
        Sequence mySequence = DOTween.Sequence();
        Level3Button.transform.SetAsLastSibling(); // Становится поверх всех

        // Добавляем анимации в последовательность ПАРАЛЛЕЛЬНО (через Join)
        mySequence.Join(Level3Button.transform.DOScale(5f, 1.5f).SetEase(Ease.InQuad));
        mySequence.Join(Level3Button.transform.DOMove(Vector3.zero, 1.5f).SetEase(Ease.InQuad));

        // Действие после завершения
        mySequence
            .OnComplete(() =>
            {
                // 4. Показываем экран загрузки
                loadingScreen.SetActive(true);
                loadingScreen.transform.localScale = Vector3.zero;
                loadingScreen.transform.DOScale(1, 0.5f)
                    .SetEase(Ease.OutBack);
                loading_circle.DORotate(new Vector3(0, 0, -360), 1.3f, RotateMode.LocalAxisAdd)
                .SetLoops(-1, LoopType.Restart)
                .SetEase(Ease.Linear);
            });
    }

    IEnumerator LoadSceneAfterDelay3()
    {
        // Ждём указанное количество секунд
        yield return new WaitForSeconds(5f);

        // Загружаем новую сцену
        SceneManager.LoadScene("Level3");
    }

    public void Load_to_NewScene3()
    {
        StartCoroutine(LoadSceneAfterDelay3());
    }


    //----------------------------------------------------------------------------------------------------------------------------------------------------
    //----------------------------------------------------------------------------------------------------------------------------------------------------
    public void Enterlevel4()
    {

        // 2. Затемняем экран (0 → 0.8 прозрачности)
        darkOverlay.DOFade(1f, 1f).From(0);

        // 3. Увеличиваем телефон (эффект "погружения")
        Sequence mySequence = DOTween.Sequence();
        Level4Button.transform.SetAsLastSibling(); // Становится поверх всех

        // Добавляем анимации в последовательность ПАРАЛЛЕЛЬНО (через Join)
        mySequence.Join(Level4Button.transform.DOScale(5f, 1.5f).SetEase(Ease.InQuad));
        mySequence.Join(Level4Button.transform.DOMove(Vector3.zero, 1.5f).SetEase(Ease.InQuad));

        // Действие после завершения
        mySequence
            .OnComplete(() =>
            {
                // 4. Показываем экран загрузки
                loadingScreen.SetActive(true);
                loadingScreen.transform.localScale = Vector3.zero;
                loadingScreen.transform.DOScale(1, 0.5f)
                    .SetEase(Ease.OutBack);
                loading_circle.DORotate(new Vector3(0, 0, -360), 1.3f, RotateMode.LocalAxisAdd)
                .SetLoops(-1, LoopType.Restart)
                .SetEase(Ease.Linear);
            });
    }

    IEnumerator LoadSceneAfterDelay4()
    {
        // Ждём указанное количество секунд
        yield return new WaitForSeconds(5f);

        // Загружаем новую сцену
        SceneManager.LoadScene("Level4");
    }

    public void Load_to_NewScene4()
    {
        StartCoroutine(LoadSceneAfterDelay4());
    }


    //----------------------------------------------------------------------------------------------------------------------------------------------------
    //----------------------------------------------------------------------------------------------------------------------------------------------------
    public void Enterlevel5()
    {

        // 2. Затемняем экран (0 → 0.8 прозрачности)
        darkOverlay.DOFade(1f, 1f).From(0);

        // 3. Увеличиваем телефон (эффект "погружения")
        Sequence mySequence = DOTween.Sequence();
        Level5Button.transform.SetAsLastSibling(); // Становится поверх всех

        // Добавляем анимации в последовательность ПАРАЛЛЕЛЬНО (через Join)
        mySequence.Join(Level5Button.transform.DOScale(5f, 1.5f).SetEase(Ease.InQuad));
        mySequence.Join(Level5Button.transform.DOMove(Vector3.zero, 1.5f).SetEase(Ease.InQuad));

        // Действие после завершения
        mySequence
            .OnComplete(() =>
            {
                // 4. Показываем экран загрузки
                loadingScreen.SetActive(true);
                loadingScreen.transform.localScale = Vector3.zero;
                loadingScreen.transform.DOScale(1, 0.5f)
                    .SetEase(Ease.OutBack);
                loading_circle.DORotate(new Vector3(0, 0, -360), 1.3f, RotateMode.LocalAxisAdd)
                .SetLoops(-1, LoopType.Restart)
                .SetEase(Ease.Linear);
            });
    }

    IEnumerator LoadSceneAfterDelay5()
    {
        // Ждём указанное количество секунд
        yield return new WaitForSeconds(5f);

        // Загружаем новую сцену
        SceneManager.LoadScene("Level5");
    }

    public void Load_to_NewScene5()
    {
        StartCoroutine(LoadSceneAfterDelay5());
    }

    //----------------------------------------------------------------------------------------------------------------------------------------------------
    //----------------------------------------------------------------------------------------------------------------------------------------------------

    public void Enterlevel6()
    {

        // 2. Затемняем экран (0 → 0.8 прозрачности)
        darkOverlay.DOFade(1f, 1f).From(0);

        // 3. Увеличиваем телефон (эффект "погружения")
        Sequence mySequence = DOTween.Sequence();
        Level6Button.transform.SetAsLastSibling(); // Становится поверх всех

        // Добавляем анимации в последовательность ПАРАЛЛЕЛЬНО (через Join)
        mySequence.Join(Level6Button.transform.DOScale(5f, 1.5f).SetEase(Ease.InQuad));
        mySequence.Join(Level6Button.transform.DOMove(Vector3.zero, 1.5f).SetEase(Ease.InQuad));

        // Действие после завершения
        mySequence
            .OnComplete(() =>
            {
                // 4. Показываем экран загрузки
                loadingScreen.SetActive(true);
                loadingScreen.transform.localScale = Vector3.zero;
                loadingScreen.transform.DOScale(1, 0.5f)
                    .SetEase(Ease.OutBack);
                loading_circle.DORotate(new Vector3(0, 0, -360), 1.3f, RotateMode.LocalAxisAdd)
                .SetLoops(-1, LoopType.Restart)
                .SetEase(Ease.Linear);
            });
    }

    IEnumerator LoadSceneAfterDelay6()
    {
        // Ждём указанное количество секунд
        yield return new WaitForSeconds(5f);

        // Загружаем новую сцену
        SceneManager.LoadScene("Level6");
    }

    public void Load_to_NewScene6()
    {
        StartCoroutine(LoadSceneAfterDelay6());
    }

    //----------------------------------------------------------------------------------------------------------------------------------------------------
    //----------------------------------------------------------------------------------------------------------------------------------------------------

    public void Enterlevel7()
    {

        // 2. Затемняем экран (0 → 0.8 прозрачности)
        darkOverlay.DOFade(1f, 1f).From(0);

        // 3. Увеличиваем телефон (эффект "погружения")
        Sequence mySequence = DOTween.Sequence();
        Level7Button.transform.SetAsLastSibling(); // Становится поверх всех

        // Добавляем анимации в последовательность ПАРАЛЛЕЛЬНО (через Join)
        mySequence.Join(Level7Button.transform.DOScale(5f, 1.5f).SetEase(Ease.InQuad));
        mySequence.Join(Level7Button.transform.DOMove(Vector3.zero, 1.5f).SetEase(Ease.InQuad));

        // Действие после завершения
        mySequence
            .OnComplete(() =>
            {
                // 4. Показываем экран загрузки
                loadingScreen.SetActive(true);
                loadingScreen.transform.localScale = Vector3.zero;
                loadingScreen.transform.DOScale(1, 0.5f)
                    .SetEase(Ease.OutBack);
                loading_circle.DORotate(new Vector3(0, 0, -360), 1.3f, RotateMode.LocalAxisAdd)
                .SetLoops(-1, LoopType.Restart)
                .SetEase(Ease.Linear);
            });
    }

    IEnumerator LoadSceneAfterDelay7()
    {
        // Ждём указанное количество секунд
        yield return new WaitForSeconds(5f);

        // Загружаем новую сцену
        SceneManager.LoadScene("Level7");
    }

    public void Load_to_NewScene7()
    {
        StartCoroutine(LoadSceneAfterDelay7());
    }


    //----------------------------------------------------------------------------------------------------------------------------------------------------
    //----------------------------------------------------------------------------------------------------------------------------------------------------

    public void Enterlevel8()
    {

        // 2. Затемняем экран (0 → 0.8 прозрачности)
        darkOverlay.DOFade(1f, 1f).From(0);

        // 3. Увеличиваем телефон (эффект "погружения")
        Sequence mySequence = DOTween.Sequence();
        Level8Button.transform.SetAsLastSibling(); // Становится поверх всех

        // Добавляем анимации в последовательность ПАРАЛЛЕЛЬНО (через Join)
        mySequence.Join(Level8Button.transform.DOScale(5f, 1.5f).SetEase(Ease.InQuad));
        mySequence.Join(Level8Button.transform.DOMove(Vector3.zero, 1.5f).SetEase(Ease.InQuad));

        // Действие после завершения
        mySequence
            .OnComplete(() =>
            {
                // 4. Показываем экран загрузки
                loadingScreen.SetActive(true);
                loadingScreen.transform.localScale = Vector3.zero;
                loadingScreen.transform.DOScale(1, 0.5f)
                    .SetEase(Ease.OutBack);
                loading_circle.DORotate(new Vector3(0, 0, -360), 1.3f, RotateMode.LocalAxisAdd)
                .SetLoops(-1, LoopType.Restart)
                .SetEase(Ease.Linear);
            });
    }

    IEnumerator LoadSceneAfterDelay8()
    {
        // Ждём указанное количество секунд
        yield return new WaitForSeconds(5f);

        // Загружаем новую сцену
        SceneManager.LoadScene("Level8");
    }

    public void Load_to_NewScene8()
    {
        StartCoroutine(LoadSceneAfterDelay8());
    }



    //----------------------------------------------------------------------------------------------------------------------------------------------------
    //----------------------------------------------------------------------------------------------------------------------------------------------------

    public void Enterlevel9()
    {

        // 2. Затемняем экран (0 → 0.8 прозрачности)
        darkOverlay.DOFade(1f, 1f).From(0);

        // 3. Увеличиваем телефон (эффект "погружения")
        Sequence mySequence = DOTween.Sequence();
        Level9Button.transform.SetAsLastSibling(); // Становится поверх всех

        // Добавляем анимации в последовательность ПАРАЛЛЕЛЬНО (через Join)
        mySequence.Join(Level9Button.transform.DOScale(5f, 1.5f).SetEase(Ease.InQuad));
        mySequence.Join(Level9Button.transform.DOMove(Vector3.zero, 1.5f).SetEase(Ease.InQuad));

        // Действие после завершения
        mySequence
            .OnComplete(() =>
            {
                // 4. Показываем экран загрузки
                loadingScreen.SetActive(true);
                loadingScreen.transform.localScale = Vector3.zero;
                loadingScreen.transform.DOScale(1, 0.5f)
                    .SetEase(Ease.OutBack);
                loading_circle.DORotate(new Vector3(0, 0, -360), 1.3f, RotateMode.LocalAxisAdd)
                .SetLoops(-1, LoopType.Restart)
                .SetEase(Ease.Linear);
            });
    }

    IEnumerator LoadSceneAfterDelay9()
    {
        // Ждём указанное количество секунд
        yield return new WaitForSeconds(5f);

        // Загружаем новую сцену
        SceneManager.LoadScene("Level9");
    }

    public void Load_to_NewScene9()
    {
        StartCoroutine(LoadSceneAfterDelay9());
    }
}
