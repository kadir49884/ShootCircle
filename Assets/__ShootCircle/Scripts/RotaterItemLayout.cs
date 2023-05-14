using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotaterItemLayout : Singleton<RotaterItemLayout>
{
    private int itemCount;

    private ShootController shootController;

    [SerializeField, ReadOnly] private List<Transform> itemTransformList = new List<Transform>();
    [SerializeField, ReadOnly] private List<Transform> itemPointList = new List<Transform>();

    private void Start()
    {
        shootController = ShootController.Instance;
        for (int i = 0; i < transform.childCount; i++)
        {
            itemPointList.Add(transform.GetChild(i));
        }
    }

    public void GetItem(ItemController getItemController)
    {
        itemCount++;
        Transform itemTransform = getItemController.transform;
        itemTransformList.Add(itemTransform);
        SetItemLayout();
        itemTransform.parent = itemPointList[itemCount - 1].GetChild(0);
        itemTransform.localPosition = Vector3.zero;
        //itemTransform.DOLocalMove(Vector3.zero, 0.3f).SetEase(Ease.Linear).SetUpdate(UpdateType.Fixed);
    }

    private void ReduceItem()
    {
        itemCount--;
        itemTransformList.Remove(itemTransformList[^1].transform);
        SetItemLayout();
    }


    private void SetItemLayout()
    {
        for (int i = 0; i < itemTransformList.Count; i++)
        {
            itemPointList[i].DOLocalRotate(new Vector3(0, i * (360f / itemCount), 0), 0.3f).SetEase(Ease.Linear).SetUpdate(UpdateType.Fixed);
        }
    }



    public void ShootEnemy(Transform getShootTransform)
    {
        //shootController.ShootEnemy(getShootTransform, itemTransformList[^1].transform);
        itemTransformList[^1].GetComponent<ItemController>().ShootEnemy(getShootTransform);
        ReduceItem();
    }



}
