using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skinnedMeshRendererArmor : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer playerSkin;

    void Start()
    {
        playerSkin = transform.parent.GetComponent<SkinnedMeshRenderer>();
    }

    void FixedUpdate()
    {
        if (transform.childCount != 0)
        {
            SkinnedMeshRenderer[] renderers = this.gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
            foreach (SkinnedMeshRenderer renderer in renderers)
            {
                renderer.bones = playerSkin.bones;
                renderer.rootBone = playerSkin.rootBone;
            }
        }
    }
}

