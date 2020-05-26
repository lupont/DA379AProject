using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimScript : MonoBehaviour
{
    [SerializeField] private Animator animator;
  
    [SerializeField] private Vector3 Offset;
    private Transform chest;
    // Start is called before the first frame update
    void Start()
    {
        chest = animator.GetBoneTransform(HumanBodyBones.Chest);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        chest.LookAt(Input.mousePosition);
    }

}
