using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class ShootController : Singleton<ShootController>
{

    //private Vector3 direction;
    //private Transform getItemTransform;
    //private bool isShootActive;

    //private void FixedUpdate()
    //{
    //    if(isShootActive)
    //    {
    //        getItemTransform.GetComponent<Rigidbody>().AddForce(direction * 3000);
    //    }
    //}


    //public void ShootEnemy(Transform getShootTransform, Transform getItem)
    //{
    //    getItemTransform = getItem;
    //    getItem.parent = null;
    //    getItem.GetComponent<Rigidbody>().isKinematic = false;
    //    direction = (getShootTransform.position - Vector3.forward - getItem.position).normalized;
    //    isShootActive = true;
    //}

}
