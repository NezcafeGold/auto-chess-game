using System.Collections;
using System.Collections.Generic;
using Heroes;
using Shop;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HeroesArenaScript : MonoBehaviour
{

    private Tilemap _tilemap;

    private List<HeroImpl> _heroes;
    [SerializeField] private Tile tileHero;
    
    // Start is called before the first frame update
    void Start()
    {
        _tilemap = GetComponent<Tilemap>();
        _heroes = new List<HeroImpl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void onDrop(ShopCell shopCell)
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int tileCoordinate = _tilemap.WorldToCell(mouseWorldPos);
        
//        Texture2D t = shopCell.HeroImpl.icon.texture;
//        tileHero.sprite = Sprite.Create(t, new Rect (0, 0, t.width, t.height), new Vector2 (0.5f, 0.5f), 256f);
//        _tilemap.SetTile(tileCoordinate, tileHero);
//        Debug.Log(shopCell);
        
    }
}
