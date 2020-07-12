using UnityEngine;


namespace Heroes
{
    [CreateAssetMenu(menuName = "hero")]
    public class HeroImpl : ScriptableObject, Hero
    {
        public string name => _name;
        public Sprite icon => _icon;
        public Sprite Sprite => _sprite;

        [SerializeField] private string _name;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Sprite _sprite;
    }
}