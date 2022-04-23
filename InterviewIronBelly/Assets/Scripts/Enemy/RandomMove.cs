using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IronBelly.Enemy
{
    public class RandomMove : MonoBehaviour
    {
        public float velocidadMax;

        private float xMax;
        private float zMax;
        private float xMin;
        private float zMin;

        private float x;
        private float z;
        private float time;
        private float angle;
        private Vector3 size;

        // Use this for initialization
        void Start()
        {
            x = Random.Range(-velocidadMax, velocidadMax);
            z = Random.Range(-velocidadMax, velocidadMax);
            angle = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
            //transform.localRotation = Quaternion.Euler(0, angle, 0);
            size = RandomEnemy.Instance.size;

            xMin = (-size.x / 2);
            xMax = (size.x / 2);

            zMin = 0;
            zMax = size.z;
        }

        void Update()
        {
            time += Time.deltaTime;

            if (transform.localPosition.x > xMax)
            {
                x = Random.Range(-velocidadMax, 0.0f);
                angle = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
                //transform.localRotation = Quaternion.Euler(0, angle, 0);
                time = 0.0f;
            }
            if (transform.localPosition.x < xMin)
            {
                x = Random.Range(0.0f, velocidadMax);
                angle = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
                //transform.localRotation = Quaternion.Euler(0, angle, 0);
                time = 0.0f;
            }
            if (transform.localPosition.z > zMax)
            {
                z = Random.Range(-velocidadMax, 0.0f);
                angle = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
                //transform.localRotation = Quaternion.Euler(0, angle, 0);
                time = 0.0f;
            }
            if (transform.localPosition.z < zMin)
            {
                z = Random.Range(0.0f, velocidadMax);
                angle = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
                //transform.localRotation = Quaternion.Euler(0, angle, 0);
                time = 0.0f;
            }

            if (time > 1.0f)
            {
                x = Random.Range(-velocidadMax, velocidadMax);
                z = Random.Range(-velocidadMax, velocidadMax);
                angle = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
                //transform.localRotation = Quaternion.Euler(0, angle, 0);
                time = 0.0f;
            }

            transform.localPosition = new Vector3(transform.localPosition.x + x, transform.localPosition.y, transform.localPosition.z + z);
        }
    }
}