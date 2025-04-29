using UnityEngine;
using UnityEngine.Tilemaps;

public class BoardScript : MonoBehaviour
{
    public Tilemap tilemap {  get; private set; }
    public Tile tileUnkown;
    public Tile tileEmpty;
    public Tile tileNomNom;
    public Tile tileBurnt;
    public Tile tileCovered;
    public Tile tileNum1;
    public Tile tileNum2;
    public Tile tileNum3;
    public Tile tileNum4;
    public Tile tileNum5;
    public Tile tileNum6;
    public Tile tileNum7;
    public Tile tileNum8;



    private void Awake()
    {
        tilemap = GetComponentInChildren<Tilemap>();
    }

    public void Draw(CellScript[,] state)
    {
        int width = state.GetLength(0);
        int height = state.GetLength(1);
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                CellScript cell = state[x, y];
                tilemap.SetTile(cell.position, GetTile(cell));
            }
        }
    }

    private Tile GetTile(CellScript cell)
    {
        if (cell.revealed)
        {
            return GetRevealedTile(cell);
        }
        else if (cell.covered)
        {
            return tileCovered;
        }
        else
        {
            return tileUnkown;
        }
    }

    private Tile GetRevealedTile(CellScript cell)
    {
        switch (cell.type)
        {
            case CellScript.Type.Empty:
                return tileEmpty;
                break;
            case CellScript.Type.NomNom:
                return cell.burnt ? tileBurnt : tileNomNom;
                break;
            case CellScript.Type.Number:
                return GetNumberTile(cell);
            default:
                return null;
        }
    }

    private Tile GetNumberTile(CellScript cell)
    {
        switch (cell.number) 
        {
            case 1:
                return tileNum1;
                break;
            case 2:
                return tileNum2;
                break;
            case 3:
                return tileNum3;
                break;
            case 4:
                return tileNum4;
                break;
            case 5:
                return tileNum5;
                break;
            case 6:
                return tileNum6;
                break;
            case 7:
                return tileNum7;
                break;
            case 8:
                return tileNum8;
                break;
            default: return null;
        }
    }
}
