using UnityEngine;
using System.Collections;

public class asteroidScript : MonoBehaviour {

    float leftEdge = 0f;
    float rightEdge = 0f;
    Transform m_transform;
    Rigidbody2D m_rigid;
    public GameObject explosionPrefab;
    

    void Awake()
    {
        m_transform = GetComponent<Transform>();
        m_rigid = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
	void Start () {
        leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 1f)).x;
        rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, 1f)).x;
        m_rigid.AddForce(new Vector2(Random.Range(-200000f,200000f),Random.Range(-200f,200f)));
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(explosionPrefab, other.gameObject.GetComponent<Transform>().position, Quaternion.identity);
        Destroy(other.gameObject);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.layer != 8)
        {
            Instantiate(explosionPrefab, m_transform.position, Quaternion.identity);
            asteroidGeneratorScript.asteroidAmount--;
            asteroidsDestroyedScript.current.addScore();
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        if (m_transform.position.x > rightEdge)
        {
            Vector2 newVelocity = m_rigid.velocity;
            newVelocity.x = -Mathf.Abs(m_rigid.velocity.x);
            m_rigid.velocity = newVelocity;
        }
        if (m_transform.position.x < leftEdge)
        {
            Vector2 newVelocity = m_rigid.velocity;
            newVelocity.x = Mathf.Abs(m_rigid.velocity.x);
            m_rigid.velocity = newVelocity;

        }

    }

}
