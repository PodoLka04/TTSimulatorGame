using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _tilePrefab; // Префаб плитки
    [SerializeField] private Transform _container;   // Контейнер (перетащи GridContainer сюда)
    [SerializeField] private float _spacing = 100f; // Расстояние между плитками

    

    public void SpawnTiles()
    {
        // Очистка контейнера (если там что-то есть)
        foreach (Transform child in _container)
        {
            Destroy(child.gameObject);
        }

        // Спавн 9 плиток (3x3 сетка)
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                // 1. Вычисляем локальные координаты внутри контейнера
                Vector3 localPosition = new Vector3(
                    x * _spacing,
                    y * _spacing,
                    0
                );

                // 2. Спавним префаб внутри контейнера
                GameObject tile = Instantiate(_tilePrefab, _container);

                // 3. Устанавливаем локальную позицию
                tile.transform.localPosition = localPosition;
            }
        }
    }
}