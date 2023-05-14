using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    private GameManager gameManager;
    private Animator playerAnimator;
    private void Start()
    {
        gameManager = GameManager.Instance;
        gameManager.GameStart += GameStart;
        playerAnimator = transform.GetComponent<Animator>();
    }

    public void GameStart()
    {
        ChangePlayerAnim(1);
    }
    public void ChangePlayerAnim(int getAnimIndex)
    {
        playerAnimator.SetInteger("PlayerAnimStatus", getAnimIndex);
    }

}
