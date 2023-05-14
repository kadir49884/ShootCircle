using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private bool isTriggerEnemy;
    private bool isTriggerPlayer;
    private bool isShootActive;
    private Vector3 shootDirection;
    private Rigidbody rb;


    [SerializeField] private Itemtype itemType;

    private void Awake()
    {
        rb = transform.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (isShootActive)
        {
            rb.velocity = shootDirection * 60;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerCollector playerCollector))
        {
            isTriggerPlayer = true;
            RotaterItemLayout.Instance.GetItem(this);
        }
        if (other.TryGetComponent(out EnemyController enemyController) && !isTriggerEnemy && isTriggerPlayer)
        {
            isTriggerEnemy = true;
            isShootActive = false;
            enemyController.HitEnemy();
            enemyController.GetComponent<CapsuleCollider>().enabled = false;
            transform.GetComponent<BoxCollider>().isTrigger = false;
            Destroy(gameObject, 2);
        }

    }

    public void ShootEnemy(Transform getShootTransform)
    {
        transform.parent = null;
        transform.GetComponent<Rigidbody>().isKinematic = false;
        shootDirection = (getShootTransform.position - transform.position).normalized;
        isShootActive = true;
    }

}
