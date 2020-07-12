
using Heroes;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Shop
{
    //Отображает информацию в клетке персонажа в магазине
    public class ShopCell : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] public Image _icon;
        [SerializeField] private GameObject dragParent;
        private PlaceToHero _placeToHero = PlaceToHero.SHOP;
        private PanelWithCells _panelWithCells;
        private int _index;
        private HeroImpl _heroImpl;


        public PlaceToHero PlaceToHero
        {
            get => _placeToHero;
            set => _placeToHero = value;
        }

        public HeroImpl HeroImpl
        {
            get => _heroImpl;
            set => _heroImpl = value;
        }

        public void Render(HeroImpl hero, PlaceToHero placeToHere, PanelWithCells panelWithCells, int index)
        {
            _heroImpl = hero;
            _icon.sprite = hero.icon;
            _placeToHero = placeToHere;
            _panelWithCells = panelWithCells;
            _index = index;
        }

        public void OnClick()
        {
            if (_placeToHero == PlaceToHero.SHOP)
            {
                ((ShopHero) _panelWithCells).MoveToInventory(this);
            }
        }

        public int Index
        {
            get => _index;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (_placeToHero == PlaceToHero.INVENTORY)
            {
                Debug.Log("DRAG");
                // transform.SetParent(transform.parent.parent, false);
                Debug.Log("DRAG");
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (_placeToHero == PlaceToHero.INVENTORY)
                transform.position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (_placeToHero == PlaceToHero.INVENTORY)
            {
                Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
                if (hit.collider != null && hit.collider.CompareTag("Arena"))
                {
                    Debug.Log(hit.collider.name);
                    var heroesArena = (HeroesArenaScript) GameObject.FindWithTag("HeroesArena").GetComponent(typeof(HeroesArenaScript));
                    heroesArena.onDrop(this);
                    Destroy(this.gameObject);
                }
            }
        }
    }
}