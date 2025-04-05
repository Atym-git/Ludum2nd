using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentItem : MonoBehaviour
{
    //Equipment items
    private float _equipmentDamage;

    private float _equipmentHealth;

    private bool _isPlayerInsideTrigger = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            _isPlayerInsideTrigger = true;
        }
    }
    public virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            _isPlayerInsideTrigger = false;
        }
    }
}
