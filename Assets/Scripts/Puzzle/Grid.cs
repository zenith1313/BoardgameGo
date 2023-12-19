using UnityEngine;
using UnityEngine.EventSystems;

public class Grid : MonoBehaviour, IPointerClickHandler
{
    //protected GoManager _manager;
    public int Row;
    public int Column;
    
    private bool _isOccupied;
    
    private void Start()
    {
        //_manager = FindObjectOfType<GoManager>();
        GoManager.Instance.RegisterGrid(this);
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!_isOccupied)
        {
            var prefabname = GoManager.Instance.PlayerIsWhite ? "WhitePiece" : "BlackPiece";
            var piece = Instantiate(Resources.Load(prefabname), transform);
            piece.name = $"piece-{Row}-{Column}";
            _isOccupied = true;
            GoManager.Instance.CheckPieceThatCanBeEliminated(Row,Column);
        }
    }

    public void Destroy()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
            _isOccupied = false;
        }
    }
}
