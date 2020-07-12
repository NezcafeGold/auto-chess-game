using System.Collections.Generic;
using System.Security.Cryptography;
using Heroes;
using Shop;
using UnityEngine;
using Random = UnityEngine.Random;


public class ShopHero : MonoBehaviour, PanelWithCells
{
    [SerializeField] private List<HeroImpl> Heroes = new List<HeroImpl>();
    [SerializeField] private ShopCell _shopCell;
    [SerializeField] private Transform panel;
    [SerializeField] private InventoryHero _inventoryHero;
    private List<HeroImpl> HeroesRand = new List<HeroImpl>();
    private const int MAX_SHOP_VALUE = 5;

    public void ReRollHeroes()
    {
        HeroesRand.Clear();

        for (int i = 0; i < MAX_SHOP_VALUE; i++)
        {
            int ind = Random.Range(0, Heroes.Count);
            HeroesRand.Add(Heroes[ind]);
        }

        UpdateSlots();
    }


    public void ClickOnCell()
    {
    }

    private void Start()
    {
        ReRollHeroes();
    }

    public void UpdateSlots()
    {
        foreach (Transform child in panel.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        int index = 0;
        HeroesRand.ForEach(hero =>
        {
            var cell = Instantiate(_shopCell, panel);
            cell.Render(hero, PlaceToHero.SHOP, this, index);
            index++;
        });
    }

    public void MoveToInventory(ShopCell shopCell)
    {
        if (_inventoryHero.transform.childCount < 5)
        {
            shopCell.transform.SetParent(_inventoryHero.transform, false);
            shopCell.PlaceToHero = PlaceToHero.INVENTORY;
        }
    }
}