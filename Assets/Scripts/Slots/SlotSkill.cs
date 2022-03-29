using UnityEngine;

public class SlotSkill : MonoBehaviour
{
    private GameObject skill;

    [SerializeField] private Transform _slotSkillOnHud;
    private Slot _slot;

    private void Awake() => _slot = GetComponent<Slot>();

    private void Update()
    {
        if (_slot.IsFull == true && skill == null)
        {
            skill = Instantiate(transform.GetChild(0).gameObject, _slotSkillOnHud);
            Destroy(skill.GetComponent<DragAndDrop>());
        }
        else if (_slot.IsFull == false && skill != null) Destroy(_slotSkillOnHud.transform.GetChild(0).gameObject);
    }
}
