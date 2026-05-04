using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class Data : MonoBehaviour
{
    public static Data Instance { get; private set; }

    [SerializeField] public bool Is1LevelComp = false;

    [SerializeField] public bool Key1 = false;
    [SerializeField] public bool Key2 = false;
    [SerializeField] public bool Key3 = false;
    [SerializeField] public bool Key4 = false;
    [SerializeField] public bool Key5 = false;
    [SerializeField] public bool Key6 = false;
    [SerializeField] public bool Key7 = false;
    [SerializeField] public bool Key8 = false;
    [SerializeField] public bool Key9 = false;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Сохраняем объект между сценами
        }
        else
        {
            Destroy(gameObject); // Удаляем дубликаты
        }
    }


    private void Start()
    {
        if (YandexGame.SDKEnabled == true)
        {
            LoadSaveCloud();
        }
        //-------------------------------------------------------------------среда сохранения каждые 2 секунды---------------------------------------------------
        StartCoroutine(SaveCoroutine());
    }

    public void LoadSaveCloud()//функцию вызываю при старте игры
    {
        Data.Instance.Key1 = YandexGame.savesData.key1;
        Data.Instance.Key2 = YandexGame.savesData.key2;
        Data.Instance.Key3 = YandexGame.savesData.key3;
        Data.Instance.Key4 = YandexGame.savesData.key4;
        Data.Instance.Key5 = YandexGame.savesData.key5;
        Data.Instance.Key6 = YandexGame.savesData.key6;
        Data.Instance.Key7 = YandexGame.savesData.key7;
        Data.Instance.Key8 = YandexGame.savesData.key8;
        Data.Instance.Key9 = YandexGame.savesData.key9;
    }

    public void MySafe()//функцию вызываю каждые 2 секунды
    {
        YandexGame.savesData.key1 = Data.Instance.Key1;
        YandexGame.savesData.key2 = Data.Instance.Key2;
        YandexGame.savesData.key3 = Data.Instance.Key3;
        YandexGame.savesData.key4 = Data.Instance.Key4;
        YandexGame.savesData.key5 = Data.Instance.Key5;
        YandexGame.savesData.key6 = Data.Instance.Key6;
        YandexGame.savesData.key7 = Data.Instance.Key7;
        YandexGame.savesData.key8 = Data.Instance.Key8;
        YandexGame.savesData.key9 = Data.Instance.Key9;

        YandexGame.SaveProgress();
    }
    private IEnumerator SaveCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f); // Ждем 2 секунды

            MySafe(); // Вызываем метод сохранения каждые 2 сек
        }
    }


    private void OnEnable()
    {
        YandexGame.GetDataEvent += LoadSaveCloud;//хз че это
    }
    private void OnDisable()
    {
        YandexGame.GetDataEvent -= LoadSaveCloud;
    }
}
