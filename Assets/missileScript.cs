using UnityEngine;
using System.Collections;

public class missileScript : MonoBehaviour {
    public Vector3 targetPoint;
    Transform m_transform;
    Rigidbody2D m_rigid;
    float speed = 5f;
    public GameObject explosionPrefab;


    void Awake()
    {
        m_rigid = GetComponent<Rigidbody2D>();
        m_transform = GetComponent<Transform>();
    }
    
    // Use this for initialization
	void Start () {
        StartCoroutine(checkForDistance());
	}

    IEnumerator checkForDistance()
    {
        while (true)
        {
            targetPoint.z = m_transform.position.z;
            if (Vector3.Distance(targetPoint, m_transform.position) < 20f)
            {
                destroyNow();
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        destroyNow();
    }

    void destroyNow()
    {
        Instantiate(explosionPrefab, m_transform.position, Quaternion.identity);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_transform.position, 50f);
        foreach (Collider2D coll in colliders)
        {
            if (coll.gameObject.GetComponent<Rigidbody2D>() && coll.gameObject.layer != 8)
            {
                ExplosionForce2D.AddExplosionForce(coll.gameObject.GetComponent<Rigidbody2D>(), 800000f, m_transform.position, 100f);
            }
        }
        defenderScript.missiles--;
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        //targetPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 vectorToTarget = targetPoint - m_transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        angle -= 90f;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        m_transform.rotation = Quaternion.Slerp(m_transform.rotation, q, Time.deltaTime * speed);
        m_rigid.AddForce(m_transform.up * 2000f);
	}
}
