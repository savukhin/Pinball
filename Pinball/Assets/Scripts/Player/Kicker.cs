using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kicker : MonoBehaviour
{
    [SerializeField] private bool active = false;
    private bool activated = false;
    private Rigidbody m_rigidbody;
    [SerializeField] private Vector3 m_centerOfMass;
    [SerializeField] private Vector3 m_activatedDirection;
    [SerializeField] private Vector3 m_deactivatedDirection;
    private Vector3 m_actualActivatedDirection;
    private Vector3 m_actualDeactivatedDirection;
    [SerializeField] private Vector3 m_rotatingAxis;
    [SerializeField] private float m_rotationSpeed;

    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_rigidbody.centerOfMass = m_centerOfMass;
        
    }

    void Update()
    {
        m_rigidbody.centerOfMass = m_centerOfMass;
    }

    void OnValidate() {
        m_actualActivatedDirection = transform.rotation * m_activatedDirection;
        m_actualDeactivatedDirection = transform.rotation * m_deactivatedDirection;
        if (active)
            Activate();
        else
            Deactivate();
    }

    IEnumerator RotateOnZ(Vector3 direction) {
        direction = direction.normalized;
        Vector3 velo = Vector3.zero;
        Vector3 perpendicular = Vector3.Cross(transform.rotation * m_rotatingAxis, direction).normalized;
        velo.z = m_rotationSpeed * Mathf.Sign(perpendicular.z);
        m_rigidbody.angularVelocity = velo;
        for (; Vector3.Cross(transform.rotation * m_rotatingAxis, direction).normalized == perpendicular.normalized;) {
            yield return null;
        }
        m_rigidbody.angularVelocity = Vector3.zero;
    }

    public void Activate()
    {
        if (activated)
            return;
        activated = true;
        StopCoroutine("RotateOnZ");
        StartCoroutine(RotateOnZ(m_actualActivatedDirection));
    }

    public void Deactivate()
    {
        if (!activated)
            return;
        activated = false;
        StopCoroutine("RotateOnZ");
        StartCoroutine(RotateOnZ(m_actualDeactivatedDirection));
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + transform.rotation * m_rigidbody.centerOfMass, 1f);
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position + m_rigidbody.centerOfMass, m_actualActivatedDirection);
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position + m_rigidbody.centerOfMass, m_actualDeactivatedDirection);
        Gizmos.color = Color.white;
        Gizmos.DrawRay(transform.position + m_rigidbody.centerOfMass, transform.rotation * m_rotatingAxis);
    }
}
