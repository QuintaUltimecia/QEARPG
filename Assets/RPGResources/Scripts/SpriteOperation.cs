using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class SpriteOperation : MonoBehaviour, IPointerDownHandler
{
    private TextMeshProUGUI weaponFeaturesBar;
    private GameObject statusBar;
    private Vector3 nullPosition;
    public InventoryPlayer inventoryPlayer;
    private Image image;
    private int itemReachLength;
    public string[][] itemReach =
    {
        new string[] {"leatherHelmet"},
        new string[] {"leatherUndershirt"},
        new string[] {"leatherPants"},
        new string[] {"leatherShoes"},
        new string[] {"leatherGloves"},
        new string[] {"leatherShield"},
        new string[] {"axe","stick", "yatagan", "buster"},
    };
    public string[][] itemReachRus =
    {
        new string[] {"Кожаная шапка"},
        new string[] {"Кожаная фуфайка"},
        new string[] {"Кожаные ретузы"},
        new string[] {"Кожаные сапоги"},
        new string[] {"Кожаные варежки"},
        new string[] {"Кожаный щит"},
        new string[] {"Топор","Палка", "Ятаган", "Нарушитель"},
    };

    [SerializeField] private string itemName;

    public enum itemType
    {
        Helmet,
        Armor,
        Pants,
        Shoes,
        Gloves,
        Shield,
        Weapon
    };
    [Header("Тип предмета")] public itemType Item_type;
    public enum itemRarity
    {
        common,
        uncommon,
        rare,
        unique,
        legendary
    }
    [Header("Редкость предмета")] public itemRarity ItemRarity;
    //Статус предмета
    private string itemNameBar;
    //Стандартные характеристики
    public int itemDamage = 0;
    public int armorDefense = 0;
    //Рандомные характеристики
    private int random;
    private string[] itemFeatures = { "Скорость атаки", "Шанс крита", "Шанс стана", "Процент здоровья" };
    public int attackSpeed, critChance, stunChance, healthPercent;
    public string[] featuresAvailable = new string[4];
    private int[] featureValue = new int[4];
    private GameObject itemCache;


    void Start()
    {
        nullPosition = transform.position;
        statusBar = transform.GetChild(0).gameObject;
        itemReachLength = UnityEngine.Random.Range(0, itemReach.Length);
        image = transform.GetComponent<Image>();
        ItemSpawn();
        ItemType();
        RandomRarity();
        if (Item_type == itemType.Weapon)
        {
            itemDamage = 15;
            weaponFeaturesBar.text += $"\r\n\r\n<i><color=grey>Урон:</color> {itemDamage}";
        }
        else if (Item_type == itemType.Armor || Item_type == itemType.Shield || Item_type == itemType.Helmet || Item_type == itemType.Shoes || Item_type == itemType.Gloves || Item_type == itemType.Pants)
        {
            armorDefense = 5;
            weaponFeaturesBar.text += $"\r\n\r\n<i><color=grey>Защита:</color> {armorDefense}";
        }
        RandomFeatures();
    }

    public void OnPointerDown(PointerEventData data)
    {
        if (transform.parent.tag == "GiveItemSlot")
        {
            statusBar.transform.SetParent(this.transform);
            statusBar.SetActive(false);
            for (int i = 0; i < inventoryPlayer.inventorySlot.Length; i++)
            {
                if (inventoryPlayer.inventorySlot[i].GetComponent<Slot>().IsFull == false)
                {
                    inventoryPlayer.inventorySlot[i].GetComponent<Slot>().IsFull = true;
                    transform.SetParent(inventoryPlayer.inventorySlot[i].gameObject.transform);
                    break;
                }
            }
        }
    }

    //Спавн предметов
    public void ItemSpawn()
    {
        int itemReachLengthLength = UnityEngine.Random.Range(0, itemReach[itemReachLength].Length);
        itemName = itemReach[itemReachLength][itemReachLengthLength];
        this.gameObject.name = itemName;
        image.sprite = Resources.Load<Sprite>($"inventorySprite/{itemName}");
        weaponFeaturesBar = transform.Find("statusObject").transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
        itemNameBar = itemReachRus[itemReachLength][itemReachLengthLength];
    }
    private void ItemType()
    {
        switch (itemReachLength)
        {
            case 0:
                Item_type = itemType.Helmet;
                break;
            case 1:
                Item_type = itemType.Armor;
                break;
            case 2:
                Item_type = itemType.Pants;
                break;
            case 3:
                Item_type = itemType.Shoes;
                break;
            case 4:
                Item_type = itemType.Gloves;
                break;
            case 5:
                Item_type = itemType.Shield;
                break;
            case 6:
                Item_type = itemType.Weapon;
                break;
        }
    }
    private void RandomRarity()
    {
        random = UnityEngine.Random.Range(0, 101);
        if (random <= 75)
        {
            ItemRarity = itemRarity.common;
            weaponFeaturesBar.text = $"<size=46><b><color=grey>{itemNameBar}</color></b></size>\r\n<color=yellow><b>____________________</b></color>";
        }
        else if (random <= UnityEngine.Random.Range(76, 91))
        {
            ItemRarity = itemRarity.uncommon;
            weaponFeaturesBar.text = $"<size=46><b><color=#00ffffff>{itemNameBar}</color></b></size>\r\n<color=yellow><b>____________________</b></color>";
        }
        else if (random <= UnityEngine.Random.Range(91, 96))
        {
            ItemRarity = itemRarity.rare;
            weaponFeaturesBar.text = $"<size=46><b><color=yellow>{itemNameBar}</color></b></size>\r\n<color=yellow><b>____________________</b></color>";
        }
        else if (random <= UnityEngine.Random.Range(96, 98))
        {
            ItemRarity = itemRarity.unique;
            weaponFeaturesBar.text = $"<size=46><b><color=orange>{itemNameBar}</color></b></size>\r\n<color=yellow><b>____________________</b></color>";
        }
        else if (random <= UnityEngine.Random.Range(99, 101))
        {
            ItemRarity = itemRarity.legendary;
            weaponFeaturesBar.text = $"<size=46><b><color=red>{itemNameBar}</color></b></size>\r\n<color=yellow><b>____________________</b></color>";
        }
    }
    private void RandomFeatures()
    {
        switch (ItemRarity)
        {
            case itemRarity.common:
                break;
            case itemRarity.uncommon:
                featuresAvailable[0] = itemFeatures[UnityEngine.Random.Range(0, itemFeatures.Length)];
                featureValue[0] = UnityEngine.Random.Range(1, 11);

                break;
            case itemRarity.rare:
                featuresAvailable[0] = itemFeatures[UnityEngine.Random.Range(0, itemFeatures.Length)];
                do
                {
                    featuresAvailable[1] = itemFeatures[UnityEngine.Random.Range(0, itemFeatures.Length)];
                } while (featuresAvailable[1] == featuresAvailable[0]);
                featureValue[0] = UnityEngine.Random.Range(1, 11);
                featureValue[1] = UnityEngine.Random.Range(1, 11);

                break;
            case itemRarity.unique:
                featuresAvailable[0] = itemFeatures[UnityEngine.Random.Range(0, itemFeatures.Length)];
                do
                {
                    featuresAvailable[1] = itemFeatures[UnityEngine.Random.Range(0, itemFeatures.Length)];
                } while (featuresAvailable[1] == featuresAvailable[0]);
                do
                {
                    featuresAvailable[2] = itemFeatures[UnityEngine.Random.Range(0, itemFeatures.Length)];
                } while (featuresAvailable[2] == featuresAvailable[0] || featuresAvailable[2] == featuresAvailable[1]);
                featureValue[0] = UnityEngine.Random.Range(1, 11);
                featureValue[1] = UnityEngine.Random.Range(1, 11);
                featureValue[2] = UnityEngine.Random.Range(1, 11);

                break;
            case itemRarity.legendary:
                featuresAvailable[0] = itemFeatures[UnityEngine.Random.Range(0, itemFeatures.Length)];
                do
                {
                    featuresAvailable[1] = itemFeatures[UnityEngine.Random.Range(0, itemFeatures.Length)];
                } while (featuresAvailable[1] == featuresAvailable[0]);
                do
                {
                    featuresAvailable[2] = itemFeatures[UnityEngine.Random.Range(0, itemFeatures.Length)];
                } while (featuresAvailable[2] == featuresAvailable[0] || featuresAvailable[2] == featuresAvailable[1]);
                do
                {
                    featuresAvailable[3] = itemFeatures[UnityEngine.Random.Range(0, itemFeatures.Length)];
                } while (featuresAvailable[3] == featuresAvailable[0] || featuresAvailable[3] == featuresAvailable[1] || featuresAvailable[3] == featuresAvailable[2]);
                featureValue[0] = UnityEngine.Random.Range(1, 11);
                featureValue[1] = UnityEngine.Random.Range(1, 11);
                featureValue[2] = UnityEngine.Random.Range(1, 11);
                featureValue[3] = UnityEngine.Random.Range(1, 11);

                break;
            default:
                break;
        }
        weaponFeaturesBar.text += "<color=#00ffffff>";
        for (int i = 0; i < featuresAvailable.Length; i++)
        {
            if (featuresAvailable[i] != null && featureValue[i] != 0)
            {
                weaponFeaturesBar.text += "\r\n\r\n" + featuresAvailable[i] + ": " + featureValue[i] + "%";
            }
        }
        for (int i = 0; i < featuresAvailable.Length; i++)
        {
            for (int k = 0; k < itemFeatures.Length; k++)
            {
                if (featuresAvailable[i] == itemFeatures[k])
                {
                    if (itemFeatures[k] == itemFeatures[0])
                    {
                        attackSpeed += featureValue[i];
                    }
                    else if (itemFeatures[k] == itemFeatures[1])
                    {
                        critChance += featureValue[i];
                    }
                    else if (itemFeatures[k] == itemFeatures[2])
                    {
                        stunChance += featureValue[i];
                    }
                    else if (itemFeatures[k] == itemFeatures[3])
                    {
                        healthPercent += featureValue[i];
                    }
                }
            }
        }
    }
}
