using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tile : MonoBehaviour
{
    public Vector2Int GridPosition { get; set; }

    [SerializeField] private Image tileImage; // Заменили TMP_Text на Image
    // Убери using TMPro если больше не используешь TextMeshPro

    public void Initialize(Vector2Int gridPos, Sprite imageSprite) // Заменили string на Sprite
    {
        GridPosition = gridPos;
        tileImage.sprite = imageSprite; // Устанавливаем спрайт вместо текста

        // Обработчик клика без изменений
        GetComponent<Button>().onClick.AddListener(() =>
        {
            GameManager.Instance.OnTileClicked(GridPosition);
        });
    }
}