using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public SpaceCell[,] cells => InitCells();

    [SerializeField] private Vector2Int _spaceSize;
    [SerializeField] private SpaceCell[] _spiceCells;

    private SpaceCell[,] _cells;
    private SpaceCell[,] InitCells()
    {
        if(_cells == null)
        {
            _cells = new SpaceCell[_spaceSize.x, _spaceSize.y];
            for (int i = 0; i < _spiceCells.Length; i++)
            {
                _cells[i % _spaceSize.x, i / _spaceSize.y] = _spiceCells[i];
            }
        }
        return _cells;
    }
}
