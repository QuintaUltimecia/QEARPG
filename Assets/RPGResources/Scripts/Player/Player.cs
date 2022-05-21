using UnityEngine;
using UnityEngine.Events;

public class Player : Character
{
    [Header("Leveling")]
    [SerializeField] private int _experience;
    [SerializeField] private int _level;
    [SerializeField] private int _passiveSkillPoints;
    [SerializeField] private int _activeSkillPoints;

    private int _maxExperience = 100;

    private void Start()
    {
        Initialization("Player", CharacterClass.Warrior);
    }

    public void GetExp(int value)
    {
        _experience += Mathf.Abs(value);

        if (_experience >= _maxExperience)
        {
            _maxExperience *= 2;
            _level++;
        }
    }

    public void Death()
    {
        Destroy(this);
    }
}
