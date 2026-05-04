using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class video3 : MonoBehaviour
{
    // Start is called before the first frame update
    // 1. Ссылки на компоненты (перетягиваем в инспекторе)
    public VideoPlayer vid; // Сам видеоплеер
    public GameObject vidGO; // Объект, который показывает видео (например, экран)
    //bool vidB = false; // Флажок "надо включить видео"

    public bool vidB;
    [SerializeField] private AudioSource S3;


    public void Start()
    {
        vidGO.SetActive(false);
    }

    // 2. Метод, который вызываем при нажатии кнопки "Смотреть"
    public void StartVid1()
    {
        if (Data.Instance.Key3)
            vidB = true; // Поднимаем флажок
    }

    // 3. FixedUpdate - работает каждый кадр (но для видео лучше Update)
    void Update()
    {

        // Если флажок поднят (кто-то нажал кнопку)
        if (vidB) //чтобы видео не перскочило
        {
            // Включаем экран
            vidGO.SetActive(true);

            // Включаем видеоплеер
            vid.enabled = true;



            // Говорим откуда брать видео (StreamingAssets/реклама1.mp4)
            vid.url = System.IO.Path.Combine(Application.streamingAssetsPath, "vid3" + ".mp4");

            // Дважды запускаем (лишнее, хватит одного Play)
            //if (Data.Instance.GoVideo)
            //{
            vid.Play();
            S3.Play();

            //    Data.Instance.GoVideo = false;
            //}
            // Опускаем флажок
            vidB = false;
        }



        // Если видео закончилось
        if (!vid.isPlaying)
        {
            // Выключаем всё
            vid.enabled = false;
            vidGO.SetActive(false);
        }

    }
}
