using System;
using System.Collections.Generic;
using Heroes;
using Shop;
using UnityEngine;

namespace Shop
{
    public class InventoryHero : MonoBehaviour, PanelWithCells
    {
        private List<HeroImpl> _heroes = new List<HeroImpl>();
        [SerializeField] private int maxSlots = 5;
        [SerializeField] private ShopCell shopCell;
        
        

        private void Start()
        {
            _heroes = new List<HeroImpl>();
        }

        public void AddToInventory(HeroImpl hero)
        {
            if (_heroes.Count != maxSlots)
            {
                _heroes.Add(hero);
                UpdateSlots();
            }
        }

        public void DeleteFromInventory(HeroImpl hero)
        {
            _heroes.Remove(hero);
            UpdateSlots();
        }

        public void UpdateSlots()
        {
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }

            _heroes.ForEach(hero =>
            {
                var cell = Instantiate(shopCell, transform);
                cell.Render(hero, PlaceToHero.INVENTORY, this, 0);
            });
        }
        

        public List<HeroImpl> Heroes
        {
            get => _heroes;
        }
    }
}