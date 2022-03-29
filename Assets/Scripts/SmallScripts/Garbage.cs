//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;

//public class Garbage : MonoBehaviour, IDropHandler
//{
//    private ItemCache itemCache;

//    void Start()
//    {
//        itemCache = GameObject.Find("EventSystem").GetComponent<ItemCache>();
//    }
//    public void OnDrop(PointerEventData data)
//    {
//        if (this.gameObject.tag != "activeSlotSkill" && itemCache.itemCache != null)
//        {
//            DropInfo();
//        }
//    }
//    public void DropInfo()
//    {
//        itemCache.itemCache.transform.localScale = new Vector3(1f, 1f, 1f);
//        Destroy(itemCache.itemCache.transform.gameObject);
//        itemCache.itemCache = null;
//    }
//}
