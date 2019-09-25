using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class BullteShooting : MonoBehaviour
    {
        private BulletPool _bulletPool;
        void Start()
        {
            _bulletPool = BulletPool.Instance;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject bullet=_bulletPool.GetOneBullet();
                bullet.SetActive(true);
                bullet.transform.SetPositionAndRotation(transform.position+new Vector3(0,2,0),transform.rotation);
                bullet.GetComponent<Rigidbody>().velocity=Vector3.forward*10f;
                StartCoroutine(HideBullet(bullet));
            }
        }

        private IEnumerator HideBullet(GameObject bullet)
        {
            yield return new WaitForSeconds(3.0f);
            bullet.SetActive(false);
        }
    }
}
