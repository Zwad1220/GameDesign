using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public GameObject GameOverScreen;
    public GameObject GameWonScreen;
    public GameObject Exit;
    public GameObject text;
    public int width = 10;
    public int height = 10;
    private BoardScript board;
    private CellScript[,] state;
    public int NomNomCount = 5;
    public int coversNum = 15;
    private bool gameover = false;
    public bool complete;
    public bool active = false;
    public Text covers;
    public LogicScript logic;
    private void Awake()
    {
        board = GetComponentInChildren<BoardScript>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        complete = false;
        staticData2.value = complete;

        NewGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameover)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Cover();
            }
            if (Input.GetMouseButtonDown(0))
            {
                Reveal();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (active == false)
            {
                Exit.SetActive(true);
                active = true;
                gameover = true;
            }
            else
            {
                Exit.SetActive(false);
                active = false;
                gameover = false;
            }
        }
    }

    public void NewGame()
    {
       // coversNum = 15;
       // covers.text = coversNum.ToString();
        //Cover();
        GameOverScreen.SetActive(false);
        text.SetActive(true);
        gameover = false;
        state = new CellScript[width, height];
        GenerateCells();
        GenerateNomNoms();
        GenerateNumbers();
        board.Draw(state);
    }

    private void GenerateCells()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                CellScript cell = new CellScript();
                cell.position = new Vector3Int(x, y, 0);
                cell.type = CellScript.Type.Empty;
                state[x, y] = cell;
            }
        }
    }

    private void GenerateNomNoms()
    {
        for (int i = 0; i < NomNomCount; i++)
        {
            int x = Random.Range(0, width);
            int y = Random.Range(0, height);
            while (state[x, y].type == CellScript.Type.NomNom)
            {
                x++;
                if (x >= width)
                {
                    x = 0;
                    y++;
                    if (y >= height)
                    {
                        y = 0;
                    }
                }
            }
            state[x, y].type = CellScript.Type.NomNom;
        }
    }

    private void GenerateNumbers()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                CellScript cell = state[x, y];
                if (state[x, y].type == CellScript.Type.NomNom)
                {
                    continue;
                }
                cell.number = CountMines(x, y);
                if (cell.number > 0)
                {
                    cell.type = CellScript.Type.Number;
                }
                state[x, y] = cell;
            }
        }
    }

    private int CountMines(int cellX, int cellY)
    {
        int count = 0;
        for (int AdjacentX = -1; AdjacentX <= 1; AdjacentX++)
        {
            for (int AdjacentY = -1; AdjacentY <= 1; AdjacentY++)
            {
                if (AdjacentX == 0 && AdjacentY == 0)
                {
                    continue;
                }
                int x = cellX + AdjacentX;
                int y = cellY + AdjacentY;

                if (GetCell(x, y).type == CellScript.Type.NomNom)
                {
                    count++;
                }
            }
        }
        return count;
    }

    private void Cover()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPosition = board.tilemap.WorldToCell(worldPosition);
        CellScript cell = GetCell(cellPosition.x, cellPosition.y);

        if (cell.type == CellScript.Type.Invalid || cell.revealed || coversNum == 0)
        {
            return;
        }
        cell.covered = !cell.covered;
        if (cell.covered)
        {
            coversNum--;
            covers.text = coversNum.ToString();
        }
        else
        {
            coversNum++;
            covers.text = coversNum.ToString();
        }
        state[cell.position.x, cell.position.y] = cell;
        board.Draw(state);
    }

    private void Reveal()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPosition = board.tilemap.WorldToCell(worldPosition);
        CellScript cell = GetCell(cellPosition.x, cellPosition.y);

        if (cell.type == CellScript.Type.Invalid || cell.revealed || cell.covered)
        {
            return;
        }

        switch (cell.type)
        {
            case CellScript.Type.NomNom:
                BurnNomNom(cell);
                break;
            case CellScript.Type.Empty:
                SpreadFire(cell);
                checkWin();
                break;
            default:
                cell.revealed = true;
                state[cell.position.x, cell.position.y] = cell;
                checkWin();
                break;
        }
        board.Draw(state);
    }

    private void SpreadFire(CellScript cell)
    {
        if (cell.revealed || cell.type == CellScript.Type.NomNom || cell.type == CellScript.Type.Invalid) return;
        cell.revealed = true;
        state[cell.position.x, cell.position.y] = cell;
        if (cell.type == CellScript.Type.Empty)
        {
            SpreadFire(GetCell(cell.position.x - 1, cell.position.y));
            SpreadFire(GetCell(cell.position.x + 1, cell.position.y));
            SpreadFire(GetCell(cell.position.x, cell.position.y - 1));
            SpreadFire(GetCell(cell.position.x, cell.position.y + 1));
            SpreadFire(GetCell(cell.position.x - 1, cell.position.y - 1)); // Diagonal
            SpreadFire(GetCell(cell.position.x - 1, cell.position.y + 1)); // Diagonal
            SpreadFire(GetCell(cell.position.x + 1, cell.position.y - 1)); // Diagonal
            SpreadFire(GetCell(cell.position.x + 1, cell.position.y + 1)); // Diagonal
        }
    }

    private void BurnNomNom(CellScript cell)
    {
        text.SetActive(false);
        GameOverScreen.SetActive(true);
        logic.ReduceLife();
        gameover = true;

        cell.revealed = true;
        cell.burnt = true;
        state[cell.position.x, cell.position.y] = cell;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                cell = state[x, y];
                if (cell.type == CellScript.Type.NomNom)
                {
                    cell.revealed = true;
                    state[x, y] = cell;
                }
            }
        }
    }

    private void checkWin()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                CellScript cell = state[x, y];
                if (!cell.revealed && cell.type != CellScript.Type.NomNom)
                {
                    return;
                }

            }
        }
        complete = true;
        staticData2.value = complete;
        GameWonScreen.SetActive(true);
        gameover = true;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                CellScript cell = state[x, y];
                if (cell.type == CellScript.Type.NomNom)
                {
                    cell.covered = true;
                    state[x, y] = cell;
                }
            }
        }
    }

    private CellScript GetCell(int x, int y)
    {
        if (IsValid(x, y))
        {
            return state[x, y];
        }
        else
        {
            return new CellScript();
        }
    }

    private bool IsValid(int x, int y)
    {
        return x >= 0 && x < width && y >= 0 && y < height;
    }
}