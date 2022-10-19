using UnityEngine;

public class SlotSkill : MonoBehaviour
{
    private GameObject skill;

    [SerializeField] private Transform _slotSkillOnHud;
    private SlotUI _slot;

    private void Awake() => _slot = GetComponent<SlotUI>();

    private void Update()
    {
        if (_slot.CheckFullness() == true && skill == null)
        {
            skill = Instantiate(transform.GetChild(0).gameObject, _slotSkillOnHud);
            Destroy(skill.GetComponent<DragAndDrop>());
        }
        else if (_slot.CheckFullness() == false && skill != null) Destroy(_slotSkillOnHud.transform.GetChild(0).gameObject);
    }
}
