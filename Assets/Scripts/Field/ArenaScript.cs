
using Shop;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ArenaScript : MonoBehaviour
{
    private Tilemap tilemap;
    private Camera camera;
    [SerializeField] private Tile tileChosen;
    private Vector3Int previousTileCoordinate = new Vector3Int(0, 0, 0);
    private int lx = -5;
    private int rx = 4;
    private int uy = 2;
    private int dy = -3;

    // Start is called before the first frame update
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        camera = Camera.main;
        previousTileCoordinate = new Vector3Int(0, 0, 0);
        tileChosen.color = new Color(1f, 1f, 1f, .4f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int tileCoordinate = tilemap.WorldToCell(mouseWorldPos);

        if (tileCoordinate != previousTileCoordinate)
        {
            tilemap.SetTile(previousTileCoordinate, null);
            if (tileCoordinate.x > lx && tileCoordinate.x < rx && tileCoordinate.y < uy && tileCoordinate.y > dy)
                tilemap.SetTile(tileCoordinate, tileChosen);
            previousTileCoordinate = tileCoordinate;
        }
    }
}