using UnityEngine;

public class ActiveSlotSkillOnHud : MonoBehaviour
{
    void Update()
    {
        if (transform.childCount > 0 && transform.GetChild(0).GetComponent<DragAndDrop>())
        {
            Destroy(transform.GetChild(0).GetComponent<DragAndDrop>());
        }
    }
}
