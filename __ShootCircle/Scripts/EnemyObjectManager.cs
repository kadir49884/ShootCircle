using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectManager : MonoBehaviour
{

    [SerializeField] private Color32 enemyGrayColor;

    public Color32 EnemyGrayColor { get => enemyGrayColor; set => enemyGrayColor = value; }
}
