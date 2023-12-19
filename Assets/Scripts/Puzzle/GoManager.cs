using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GoManager : MonoBehaviour
{
    private static GoManager _Instance;

    public static GoManager Instance => _Instance;

    public bool PlayerIsWhite;
    
    private GridStatus[,] Grids = new GridStatus[4,4];
    private List<Grid> ListGrids = new List<Grid>();
    
    // Start is called before the first frame update
    private void Awake()
    {
        if (_Instance == null)
        {
            _Instance = this;
        }
    }

    public void RegisterGrid(Grid grid)
    {
        ListGrids.Add(grid);
    }

    public void CheckPieceThatCanBeEliminated(int row, int column)
    {
        //fill
        Grids[row, column] = PlayerIsWhite ? GridStatus.WHITE : GridStatus.BLACK;

        //Check neighbor
        //Check if enemy exist in neighbor
        Grid[] gridEnemies =
        {
            GetGrid(row - 1, column),
            GetGrid(row + 1, column),
            GetGrid(row, column - 1),
            GetGrid(row, column + 1)
        };
        
        //if exist check if it's surrounded
        foreach (var enemy in gridEnemies)
        {
            if (enemy == null) continue;
            var enemyStatCheck = GetGridStatus(enemy.Row, enemy.Column);
            if (enemyStatCheck != GridStatus.EMPTY)
            {
                if (IsSurrounded(enemy.Row, enemy.Column, enemyStatCheck))
                {
                    enemy.Destroy();
                    Grids[enemy.Row, enemy.Column] = GridStatus.EMPTY;
                }
            }
        }
        
        if (IsSurrounded(row, column, Grids[row, column]))
        {
            //GetGrid(row, column).Destroy();
            //Grids[row, column] = GridStatus.EMPTY;
        }

        //Switch turn
        PlayerIsWhite = !PlayerIsWhite;
    }

    private bool IsSurrounded(int row, int column, GridStatus status)
    {
        GridStatus[] gridCheck =
        {
            GetGridStatus(row - 1, column),
            GetGridStatus(row + 1, column),
            GetGridStatus(row, column - 1),
            GetGridStatus(row, column + 1)
        };

        if (status == GridStatus.WHITE && GridArrayCheck(gridCheck, GridStatus.BLACK))
        {
            return true;
        }

        if (status == GridStatus.BLACK && GridArrayCheck(gridCheck, GridStatus.WHITE))
        {
            return true;
        }
        
        return false;
    }

    private bool GridArrayCheck(IEnumerable<GridStatus> arr, GridStatus value)
    {
        return arr.All(data => data == value);
    }

    private GridStatus GetGridStatus(int row, int column)
    {
        if (row < 0 || column < 0 || row > 3 || column > 3)
        {
            return GridStatus.EMPTY;
        }

        return Grids[row, column];
    }

    private Grid GetGrid(int row, int column)
    {
        if (row < 0 || column < 0 || row > 3 || column > 3)
        {
            return null;
        }
        
        return ListGrids.FirstOrDefault(data => data.Row == row && data.Column == column);
    }
}

public enum GridStatus
{
    EMPTY,
    WHITE,
    BLACK
}

public enum PieceColor
{
    WHITE,
    BLACK
}
