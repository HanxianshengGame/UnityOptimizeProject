using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class BulletPool : MonoBehaviour
    {
        private GameObject _bulletPrefab;
        private int _bulletCount;
        private List<GameObject> _bullets;
        public static BulletPool Instance;
        private void Start()
        {
            Instance = this;
            _bulletPrefab = null;
            _bulletCount = 30;
            _bullets=new List<GameObject>();
            CreatePool(_bulletPrefab, _bulletCount);
        }

        private void CreatePool(GameObject poolItem,int itemCount)  //创建资源池
        {
            if (poolItem == null) poolItem = GameObject.Find("Bullet");
            for (int i = 0; i < itemCount; i++)
            { 
               var tempBullet=GameObject.Instantiate<GameObject>(poolItem, transform);
               _bullets.Add(tempBullet);
               tempBullet.SetActive(false); 
            }
            Destroy(poolItem);
        }

        public GameObject GetOneBullet()       //获取一颗隐藏状态的子弹
        {
            for (int i = 0; i < _bullets.Count; i++)
            {
                if (!_bullets[i].activeInHierarchy)
                    return _bullets[i];
            }

            return null;
        }
    }
}