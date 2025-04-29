using UnityEngine;

public struct CellScript
{
    public enum Type
    {
        Invalid,
        Empty,
        NomNom,
        Number,
    }
    public Vector3Int position;
    public Type type;
    public int number;
    public bool revealed, covered, burnt;
}
