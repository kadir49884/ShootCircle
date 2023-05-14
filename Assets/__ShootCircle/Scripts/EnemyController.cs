using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] private Transform enemyHead;
    [SerializeField] private Transform deathParticle;

    private GameManager gameManager;
    private Animator enemyAnim;
    private float enemySpeed = 3;
    private bool isShootActive, isDead;

    private RotaterItemLayout rotaterItemLayout;
    private Transform playerTransform;
    private float playerDistance;
    private Color32 enemyGrayColor;

    private void Awake()
    {
        enemyAnim = GetComponent<Animator>();
    }

    private void Start()
    {
        gameManager = GameManager.Instance;
        gameManager.GameStart += GameStart;

        rotaterItemLayout = RotaterItemLayout.Instance;
        playerTransform = rotaterItemLayout.transform;
        enemyGrayColor = ObjectManager.Instance.EnemyObjectManager.EnemyGrayColor;
    }

    private void Update()
    {
        if (!gameManager.RunGame || isDead)
        {
            return;
        }
        transform.Translate(Vector3.forward * Time.deltaTime * enemySpeed);
        playerDistance = Vector3.Distance(playerTransform.position, transform.position);
        if (playerDistance < 20 && !isShootActive)
        {
            isShootActive = true;
            rotaterItemLayout.ShootEnemy(enemyHead);
        }
    }
    public void GameStart()
    {
        enemyAnim.SetInteger("EnemyAnimStatus", 1);
    }

    public void HitEnemy()
    {
        if (isDead)
        {
            return;
        }
        EnemyDead();


    }

    private void EnemyDead()
    {
        isDead = true;
        enemyAnim.enabled = false;
        StrechEnemyHead();
        MakeEnemyDead();
        Material enemyMat = transform.GetComponent<ChangeRenderingMode>().ReturnMakeFade();
        enemyMat.DOColor(enemyGrayColor, 1f).OnComplete(() =>
        {
            enemyGrayColor.a = 10;
            enemyMat.DOColor(enemyGrayColor, 1f);
            Destroy(gameObject,1);
        });
        deathParticle.position = enemyHead.position;
        deathParticle.gameObject.SetActive(true);
    }

    private void StrechEnemyHead()
    {
        enemyHead.DOLocalMove(new Vector3(0, 0.35f, -0.35f), 0.2f).SetEase(Ease.Linear).OnComplete(() =>
        {
            //StartCoroutine(SlowMotion());
            enemyHead.DOLocalMove(Vector3.zero, 0.2f).SetEase(Ease.Linear);
        });
        enemyHead.DOLocalRotate(new Vector3(-30, 0, 0), 0.2f).SetEase(Ease.Linear).OnComplete(() =>
        {
            enemyHead.DOLocalRotate(Vector3.zero, 0.2f).SetEase(Ease.Linear);
        });
    }
    private void MakeEnemyDead()
    {
        foreach (Rigidbody item in transform.GetComponentsInChildren<Rigidbody>())
        {
            item.isKinematic = false;
            item.AddForce(Vector3.forward * 1200 + Vector3.up * 700);
        }
    }

    IEnumerator SlowMotion()
    {
        Time.timeScale = 0.7f;
        yield return new WaitForSeconds(0.3f);
        Time.timeScale = 1f;

    }


}
