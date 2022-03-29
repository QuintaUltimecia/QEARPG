using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class AnimRig : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private Rig rigRightHand;
    [SerializeField] private Rig rigLeftHand;
    public bool SkillIsActive;

    //void FixedUpdate()
    //{
    //    SkillIsActive = Player.GetComponent<Character>().SkillIsActive;
        
    //    if (this.gameObject.name == "RightHand" && transform.childCount != 0)
    //    {
    //        rigRightHand.weight = 0.5f;
    //    }
    //    else if (this.gameObject.name == "RightHand" && transform.childCount == 0 && SkillIsActive != true)
    //    {
    //        rigRightHand.weight = 0f;
    //    }

    //    if (this.gameObject.name == "LeftHand" && transform.childCount != 0)
    //    {
    //        rigLeftHand.weight = 0.5f;
    //    }
    //    else if (this.gameObject.name == "LeftHand" && transform.childCount == 0 && SkillIsActive != true)
    //    {
    //        rigLeftHand.weight = 0f;
    //    }

    //    if (SkillIsActive == true)
    //    {
    //        rigRightHand.weight = 0f;
    //    }
    //}

}
