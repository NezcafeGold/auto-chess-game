using UnityEngine;


namespace Heroes
{
    [CreateAssetMenu(menuName = "hero")]
    public class HeroImpl : ScriptableObject
    {
        public string name => _name;
        public Sprite icon => _icon;
        public Sprite Sprite => _sprite;
        public int Attack => _attack;
        public int Hp => _hp;

        [SerializeField] private string _name;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private int _attack;
        [SerializeField] private int _hp;

    }
}