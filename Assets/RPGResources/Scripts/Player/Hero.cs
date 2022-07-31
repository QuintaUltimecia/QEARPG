using UnityEngine;

public class Hero : CombatCharacter
{
    private TransferPlayerComponents _transferPlayerComponents;

    private void Awake()
    {
        _transferPlayerComponents = GetComponent<TransferPlayerComponents>();
    }

    private void Start()
    {
        InitCharacter(100);
        _transferPlayerComponents.InitHero(this);
        ReturnHealth().ApplyDamage(0);
    }
}
