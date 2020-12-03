using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class CollisionDetector : MonoBehaviour
{
    [SerializeField] private TriggerEvent onTriggerStay = new TriggerEvent();
    /// <summary>
    /// Is TriggerがONで他のColliderと重なっている時は、このメソッドがコールされる
    /// </summary>
    ///<param name="other"></param>
    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        onTriggerStay.Invoke(other);
    }

    [Serializable]
    public class TriggerEvent : UnityEvent<Collider>
    {

    }
}
