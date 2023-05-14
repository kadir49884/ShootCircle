using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : Singleton<ObjectManager>
{
	[SerializeField] private Camera orthoCamera;

    [SerializeField] private EnemyObjectManager enemyObjectManager;


	public Camera OrthoCamera { get => orthoCamera; set => orthoCamera = value; }
    public EnemyObjectManager EnemyObjectManager { get => enemyObjectManager; set => enemyObjectManager = value; }
}