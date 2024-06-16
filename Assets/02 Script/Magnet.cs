using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public float magnetRange = 3f;
    public float magnetSpeed = 10f;
    public bool magnetActive = false;
    public float magnetDuration = 5f;

    public void ActivateMagnet()
    {
        magnetActive = true;
        StartCoroutine(DeactivateMagnetAfterDelay());
        Debug.Log("Magnet effect is now active!"); // �ڼ� ȿ�� Ȱ��ȭ �޽��� ���
    }

    private IEnumerator DeactivateMagnetAfterDelay()
    {
        yield return new WaitForSeconds(magnetDuration);
        magnetActive = false;
        Debug.Log("Magnet effect has ended."); // �ڼ� ȿ�� ��Ȱ��ȭ �޽��� ���
    }

    // Update is called once per frame
    void Update()
    {
        if (magnetActive)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, magnetRange);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.gameObject.CompareTag("Part"))
                {
                    hitCollider.gameObject.transform.position = Vector3.Lerp(
                        hitCollider.gameObject.transform.position,
                        transform.position,
                        Time.deltaTime * magnetSpeed
                    );
                }
            }
        }
    }


}
