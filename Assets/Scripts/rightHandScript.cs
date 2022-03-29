//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.EventSystems;

//public class rightHandScript : MonoBehaviour, IDropHandler
//{
//    private GameObject Slots;
//    private GameObject lastSlot;
//    private ItemCache _itemCache;
//    private InventoryPlayer inventoryPlayer;
//    public bool slotFull = false;
//    private GameObject slotType;
//    public SpriteOperation _SpriteOperation;
//    public string itemName;
//    public Player _player;
//    //Префабы пушек
//    public GameObject itemPrefab;

//    private Image image;
//    //Прцоенты
//    private float _healthPercent;

//    void Start()
//    {
//        _itemCache = GameObject.Find("EventSystem").GetComponent<ItemCache>();
//        Slots = GameObject.Find("Canvas").transform.Find("Status").transform.Find("inventory").gameObject;
//        lastSlot = this.gameObject;
//        inventoryPlayer = GameObject.Find("Player").GetComponent<InventoryPlayer>();
//        _player = GameObject.Find("Player").GetComponent<Player>();
//        image = transform.GetComponent<Image>();
//        if (this.gameObject.name == "SlotArmor")
//        {
//            slotType = GameObject.FindWithTag("Armor");
//        }
//        if (this.gameObject.name == "SlotRightHand")
//        {
//            slotType = GameObject.FindWithTag("rightHand");
//        }
//        if (this.gameObject.name == "SlotLeftHand")
//        {
//            slotType = GameObject.FindWithTag("leftHand");
//        }
//        if (this.gameObject.name == "SlotHead")
//        {
//            slotType = GameObject.FindWithTag("head");
//        }
//        if (this.gameObject.name == "SlotLegs")
//        {
//            slotType = GameObject.FindWithTag("Shoes");
//        }
//        if (this.gameObject.name == "SlotPants")
//        {
//            slotType = GameObject.FindWithTag("pants");
//        }
//        if (this.gameObject.name == "SlotGloves")
//        {
//            slotType = GameObject.FindWithTag("gloves");
//        }
//    }

//    void FixedUpdate()
//    {
//        if (transform.childCount != 0)
//        {
//            image.color = new Color(0.7294118f, 0.7294118f, 0.7294118f, 1f);
//            slotFull = true;
//            transform.GetChild(0).GetComponent<DragAndDrop>().lastSlot = this.gameObject;
//        }
//        if (transform.childCount == 0)
//        {
//            image.color = new Color(1f, 1f, 1f, 1f);
//            itemName = null;
//            slotFull = false;
//        }
//        if (transform.childCount == 0 && slotType.transform.childCount != 0)
//        {
//            Destroy(slotType.transform.GetChild(0).gameObject);
//            itemFeatureNull();
//        }
//    }

//    public void OnDrop(PointerEventData data)
//    {
//        if (this.gameObject.name == "SlotArmor" && _itemCache.itemTypeCache == "Armor")
//        {
//            if (_itemCache.itemCache != null && slotFull == false)
//            {
//                _itemCache.itemCache.transform.SetParent(this.transform);
//                _itemCache.itemCache.transform.localScale = new Vector3(1f, 1f, 1f);
//                _itemCache.itemCache.transform.position = this.transform.position;
//                _itemCache.itemCache = null;

//                itemName = transform.GetChild(0).gameObject.name;

//                itemPrefab = Resources.Load<GameObject>($"prefabItem/Armor/{itemName}");
//                Instantiate(itemPrefab, slotType.transform);
//                _SpriteOperation = transform.GetChild(0).GetComponent<SpriteOperation>();
//                itemFeature();
//            }
//        }
//        if (this.gameObject.name == "SlotRightHand" && _itemCache.itemTypeCache == "Weapon")
//        {
//            if (_itemCache.itemCache != null && slotFull == false)
//            {
//                _itemCache.itemCache.transform.SetParent(this.transform);
//                _itemCache.itemCache.transform.localScale = new Vector3(1f, 1f, 1f);
//                _itemCache.itemCache.transform.position = this.transform.position;
//                _itemCache.itemCache = null;

//                itemName = transform.GetChild(0).gameObject.name;

//                itemPrefab = Resources.Load<GameObject>($"prefabItem/Weapon/{itemName}");
//                Instantiate(itemPrefab, slotType.transform);
//                _SpriteOperation = transform.GetChild(0).GetComponent<SpriteOperation>();
//                itemFeature();
//            }
//        }
//        if (this.gameObject.name == "SlotLeftHand" && _itemCache.itemTypeCache == "Weapon" || this.gameObject.name == "SlotLeftHand" && _itemCache.itemTypeCache == "Shield")
//        {
//            if (_itemCache.itemCache != null && slotFull == false)
//            {
//                _itemCache.itemCache.transform.SetParent(this.transform);
//                _itemCache.itemCache.transform.localScale = new Vector3(1f, 1f, 1f);
//                _itemCache.itemCache.transform.position = this.transform.position;
//                _itemCache.itemCache = null;

//                itemName = transform.GetChild(0).gameObject.name;
//                if (_itemCache.itemTypeCache == "Weapon")
//                {
//                    slotType = GameObject.FindWithTag("leftHand");
//                    itemPrefab = Resources.Load<GameObject>($"prefabItem/Weapon/{itemName}");
//                    Instantiate(itemPrefab, slotType.transform);
//                    _SpriteOperation = transform.GetChild(0).GetComponent<SpriteOperation>();
//                    itemFeature();
//                }
//                else
//                {
//                    slotType = GameObject.FindWithTag("shield");
//                    itemPrefab = Resources.Load<GameObject>($"prefabItem/Armor/{itemName}");
//                    Instantiate(itemPrefab, slotType.transform);
//                    _SpriteOperation = transform.GetChild(0).GetComponent<SpriteOperation>();
//                    itemFeature();
//                }
//            }
//        }
//        if (this.gameObject.name == "SlotHead" && _itemCache.itemTypeCache == "Helmet")
//        {
//            if (_itemCache.itemCache != null && slotFull == false)
//            {
//                _itemCache.itemCache.transform.SetParent(this.transform);
//                _itemCache.itemCache.transform.localScale = new Vector3(1f, 1f, 1f);
//                _itemCache.itemCache.transform.position = this.transform.position;
//                _itemCache.itemCache = null;

//                itemName = transform.GetChild(0).gameObject.name;

//                itemPrefab = Resources.Load<GameObject>($"prefabItem/Armor/{itemName}");
//                Instantiate(itemPrefab, slotType.transform);
//                _SpriteOperation = transform.GetChild(0).GetComponent<SpriteOperation>();
//                itemFeature();
//            }
//        }
//        if (this.gameObject.name == "SlotLegs" && _itemCache.itemTypeCache == "Shoes")
//        {
//            if (_itemCache.itemCache != null && slotFull == false)
//            {
//                _itemCache.itemCache.transform.SetParent(this.transform);
//                _itemCache.itemCache.transform.localScale = new Vector3(1f, 1f, 1f);
//                _itemCache.itemCache.transform.position = this.transform.position;
//                _itemCache.itemCache = null;

//                itemName = transform.GetChild(0).gameObject.name;

//                itemPrefab = Resources.Load<GameObject>($"prefabItem/Armor/{itemName}");
//                Instantiate(itemPrefab, slotType.transform);
//                _SpriteOperation = transform.GetChild(0).GetComponent<SpriteOperation>();
//                itemFeature();
//            }
//        }
//        if (this.gameObject.name == "SlotGloves" && _itemCache.itemTypeCache == "Gloves")
//        {
//            if (_itemCache.itemCache != null && slotFull == false)
//            {
//                _itemCache.itemCache.transform.SetParent(this.transform);
//                _itemCache.itemCache.transform.localScale = new Vector3(1f, 1f, 1f);
//                _itemCache.itemCache.transform.position = this.transform.position;
//                _itemCache.itemCache = null;

//                itemName = transform.GetChild(0).gameObject.name;

//                itemPrefab = Resources.Load<GameObject>($"prefabItem/Armor/{itemName}");
//                Instantiate(itemPrefab, slotType.transform);
//                _SpriteOperation = transform.GetChild(0).GetComponent<SpriteOperation>();
//                itemFeature();
//            }
//        }
//        if (this.gameObject.name == "SlotPants" && _itemCache.itemTypeCache == "Pants")
//        {
//            if (_itemCache.itemCache != null && slotFull == false)
//            {
//                _itemCache.itemCache.transform.SetParent(this.transform);
//                _itemCache.itemCache.transform.localScale = new Vector3(1f, 1f, 1f);
//                _itemCache.itemCache.transform.position = this.transform.position;
//                _itemCache.itemCache = null;

//                itemName = transform.GetChild(0).gameObject.name;

//                itemPrefab = Resources.Load<GameObject>($"prefabItem/Armor/{itemName}");
//                Instantiate(itemPrefab, slotType.transform);
//                _SpriteOperation = transform.GetChild(0).GetComponent<SpriteOperation>();
//                itemFeature();
//            }
//        }
//    }
//    private void itemFeature()
//    {
//        _healthPercent = _SpriteOperation.healthPercent;
//    }
//    private void itemFeatureNull()
//    {
//        _healthPercent = 0;
//    }
//}
