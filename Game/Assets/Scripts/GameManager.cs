using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections.Generic;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Settings")]
    public int gridSize = 4;
    public float tileSize = 100f;
    public float tileSpacing = 10f;
    public float moveDuration = 0.3f;
    [SerializeField]
    private int _shuffleMoves = 50;

    [Header("Image Settings")]
    [SerializeField] private Texture2D sourceImage; // Перетащите сюда вашу картинку в инспекторе AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
    [SerializeField] private bool preserveAspect = true; // Сохранять пропорции картинки AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA

    [Header("References")]
    public GameObject tileButtonPrefab;
    public Transform gameBoard;
    public TMP_Text movesText;
    public Button shuffleButton;

    private Tile[,] tiles;
    private Vector2Int emptyPos;
    private int movesCount = 0;
    private bool isGameWon = false;

    private void Awake() => Instance = this;

    private void Start()
    {
        shuffleButton.onClick.AddListener(ShuffleBoard);
        InitializeGame();
    }

    private void InitializeGame()
    {
        // Очищаем доску
        foreach (Transform child in gameBoard)
            Destroy(child.gameObject);

        // Инициализируем массив плиток
        tiles = new Tile[gridSize, gridSize];
        emptyPos = new Vector2Int(gridSize - 1, gridSize - 1);


        int segmentWidth = sourceImage.width / gridSize;//AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
        int segmentHeight = sourceImage.height / gridSize;//AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA


        // Создаем плитки
        for (int y = 0; y < gridSize; y++)
        {
            for (int x = 0; x < gridSize; x++)
            {
                // Пропускаем последнюю плитку (пустое место)
                if (x == gridSize - 1 && y == gridSize - 1)
                {
                    tiles[x, y] = null;
                    continue;
                }

                // Создаем кнопку-плитку
                GameObject tileObj = Instantiate(tileButtonPrefab, gameBoard);
                tileObj.name = $"Tile_{x}_{y}";

                // Настраиваем позицию
                RectTransform rect = tileObj.GetComponent<RectTransform>();
                rect.sizeDelta = new Vector2(tileSize, tileSize);
                rect.anchoredPosition = GetAnchoredPosition(x, y);

                Sprite tileSprite = CreateSpriteFromTexture(x, y, segmentWidth, segmentHeight);//AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA


                // Настраиваем Tile-компонент
                Tile tile = tileObj.GetComponent<Tile>();
                tile.Initialize(new Vector2Int(x, y), tileSprite);
                tiles[x, y] = tile;
            }
        }

        ShuffleBoard();
    }

    public void OnTileClicked(Vector2Int tilePos)
    {
        if (isGameWon) return;

        // Проверяем соседние клетки
        Vector2Int[] directions = { Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left };

        foreach (var dir in directions)
        {
            Vector2Int neighborPos = tilePos + dir;

            // Если соседняя клетка пустая
            if (neighborPos == emptyPos)
            {
                // Анимируем перемещение
                Tile clickedTile = tiles[tilePos.x, tilePos.y];
                RectTransform rect = clickedTile.GetComponent<RectTransform>();
                Vector2 targetPos = GetAnchoredPosition(neighborPos.x, neighborPos.y);

                rect.DOAnchorPos(targetPos, moveDuration).SetEase(Ease.OutQuad);

                // Обновляем данные в массиве
                SwapTiles(tilePos, neighborPos);
                emptyPos = tilePos;

                // Обновляем счетчик ходов
                movesCount++;
                UpdateMovesText();

                // Проверяем победу
                if (CheckWinCondition())
                {
                    Debug.Log("Победа!");
                    isGameWon = true;
                }

                break;
            }
        }
    }

    private void SwapTiles(Vector2Int pos1, Vector2Int pos2)
    {
        Tile temp = tiles[pos1.x, pos1.y];
        tiles[pos1.x, pos1.y] = tiles[pos2.x, pos2.y];
        tiles[pos2.x, pos2.y] = temp;

        if (tiles[pos1.x, pos1.y] != null)
            tiles[pos1.x, pos1.y].GridPosition = pos1;

        if (tiles[pos2.x, pos2.y] != null)
            tiles[pos2.x, pos2.y].GridPosition = pos2;
    }

    private Vector2 GetAnchoredPosition(int x, int y)
    {
        float posX = x * (tileSize + tileSpacing) - (gridSize * (tileSize + tileSpacing)) / 2 + tileSize / 2;
        float posY = y * (tileSize + tileSpacing) - (gridSize * (tileSize + tileSpacing)) / 2 + tileSize / 2;
        return new Vector2(posX, posY);
    }

    private void ShuffleBoard()
    {
        isGameWon = false;
        movesCount = 0;
        UpdateMovesText();

        StartCoroutine(ShuffleRoutine());
    }

    private IEnumerator ShuffleRoutine() // Убери <T>, если он был
    {
        /*Vector2Int[] directions = { Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left };

        for (int i = 0; i < 100; i++)
        {
            List<Vector2Int> possibleMoves = new List<Vector2Int>();

            foreach (var dir in directions)
            {
                Vector2Int movePos = emptyPos + dir;
                if (IsValidPosition(movePos))
                    possibleMoves.Add(movePos);
            }

            if (possibleMoves.Count > 0)
            {
                Vector2Int randomMove = possibleMoves[Random.Range(0, possibleMoves.Count)];
                Tile movingTile = tiles[randomMove.x, randomMove.y];
                RectTransform rect = movingTile.GetComponent<RectTransform>();

                rect.DOAnchorPos(GetAnchoredPosition(emptyPos.x, emptyPos.y), moveDuration / 2);
                SwapTiles(randomMove, emptyPos);
                emptyPos = randomMove;
            }

            yield return new WaitForSeconds(moveDuration / 2);
        }*/
        int movesMade = 0;

        while (movesMade < _shuffleMoves)
        {
            Vector2Int[] directions = { Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left };
            List<Vector2Int> possibleMoves = new List<Vector2Int>();

            // Собираем возможные ходы
            foreach (var dir in directions)
            {
                Vector2Int movePos = emptyPos + dir;
                if (IsValidPosition(movePos))
                    possibleMoves.Add(movePos);
            }

            // Если есть куда двигаться - делаем ход
            if (possibleMoves.Count > 0)
            {
                Vector2Int randomMove = possibleMoves[Random.Range(0, possibleMoves.Count)];
                Tile movingTile = tiles[randomMove.x, randomMove.y];
                RectTransform rect = movingTile.GetComponent<RectTransform>();

                rect.DOAnchorPos(GetAnchoredPosition(emptyPos.x, emptyPos.y), moveDuration / 2);
                SwapTiles(randomMove, emptyPos);
                emptyPos = randomMove;

                movesMade++; // Увеличиваем только при реальном ходе
            }

            yield return null; // Убрал задержку для мгновенного перемешивания
        }
    }

    private bool IsValidPosition(Vector2Int pos) => pos.x >= 0 && pos.x < gridSize && pos.y >= 0 && pos.y < gridSize;





    //-----------------------------------------------------------------
    //-----------------------------------------------------------------

    private bool CheckWinCondition()
    {
        for (int y = 0; y < gridSize; y++)
        {
            for (int x = 0; x < gridSize; x++)
            {
                // Пропускаем пустую клетку (последнюю)
                if (x == gridSize - 1 && y == gridSize - 1)
                {
                    if (tiles[x, y] != null) return false; // Если плитка есть - ошибка
                    continue;
                }

                // Если плитки нет или её имя не соответствует текущим координатам
                if (tiles[x, y] == null || !IsInOriginalPosition(tiles[x, y], x, y))
                    return false;
            }
        }
        return true;
    }

    // Проверяет, совпадает ли исходная позиция плитки (из имени) с текущей
    private bool IsInOriginalPosition(Tile tile, int currentX, int currentY)
    {
        // Разбираем имя плитки (формат "Tile_X_Y")
        string[] parts = tile.gameObject.name.Split('_');

        if (parts.Length != 3) return false; // Неправильный формат имени

        int originalX = int.Parse(parts[1]); // Получаем X из имени
        int originalY = int.Parse(parts[2]); // Получаем Y из имени

        return (originalX == currentX) && (originalY == currentY);
    }

    //---------------------------------------------------------------------
    //---------------------------------------------------------------------




    private void UpdateMovesText() => movesText.text = $"Ходы: {movesCount}";

















    private Sprite CreateSpriteFromTexture(int x, int y, int segmentWidth, int segmentHeight) //AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
    {
        // Создаем текстуру для сегмента
        Texture2D segmentTexture = new Texture2D(segmentWidth, segmentHeight);

        // Копируем пиксели из исходной картинки
        Color[] pixels = sourceImage.GetPixels(
            x * segmentWidth,
            y * segmentHeight,
            segmentWidth,
            segmentHeight
        );

        segmentTexture.SetPixels(pixels);
        segmentTexture.Apply();

        // Создаем спрайт
        return Sprite.Create(
            segmentTexture,
            new Rect(0, 0, segmentWidth, segmentHeight),
            new Vector2(0.5f, 0.5f)
        );
    }
}