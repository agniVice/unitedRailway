using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MenuTrainScript : MonoBehaviour
{
    public List<GameObject> position;
    public Transform _target;
    public float _speed;
    private Quaternion lookOnLook;
    private void Start()
    {
        ControllTarget();
        ControllTrain();
    }
    private void Update()
    {
        lookOnLook = Quaternion.LookRotation(_target.position - gameObject.transform.position);
        gameObject.transform.rotation = Quaternion.Slerp(transform.rotation, lookOnLook, (_speed / 3) * Time.fixedDeltaTime);
    }
    private void ControllTarget()
    {
          _target.DOMove(position[Random.Range(0,3)].transform.position, Random.Range(6, 8)).SetEase(Ease.InOutSine).OnComplete(() => { ControllTarget(); });
    }
    private void ControllTrain()
    { 
        gameObject.transform.DOScale(Random.Range(0.6f, 1.2f), Random.Range(5, 10)).SetEase(Ease.InOutSine).OnComplete(() => { ControllTrain(); });
    }
}
