using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace DitzelGames.FastIK
{
    public class FastIKLook : MonoBehaviour
    {
        public Transform Enemy;
        public float Speed;
        public Animator animator;

        public GameObject FOV;

        /// <summary>
        /// Look at target
        /// </summary>
        public Transform Target;

        /// <summary>
        /// Initial direction
        /// </summary>
        protected Vector3 StartDirection;

        /// <summary>
        /// Initial Rotation
        /// </summary>
        protected Quaternion StartRotation;

        public bool FirstMove = true;

        public Transform FinalPosition;
        private Vector3 targetLastPosition;

       
       
        void Awake()
        {
            targetLastPosition = FinalPosition.position;

            if (Target == null)
                return;

            StartDirection = Target.position - transform.position;
            StartRotation = transform.rotation;
        }

        void Update()
        {
            string HeadName = FOV.name;
            if (GameObject.Find(HeadName).GetComponent<FOVDetection>().isInFov == true)
            {
                if (Target == null)
                    return;

                //animator.SetBool("ItsWalking", true);
                //FirstMove = false;
                //transform.rotation = Quaternion.FromToRotation(StartDirection, Target.position - transform.position) * StartRotation;
                //Enemy.position += Enemy.forward * Speed * Time.deltaTime;
              

                Vector3 dir = Target.position - Enemy.position;
                Quaternion lookRot = Quaternion.LookRotation(dir);
                lookRot.x = 0; lookRot.z = 0;
                Enemy.rotation = Quaternion.Slerp(Enemy.rotation, lookRot, Mathf.Clamp01(3.0f * Time.maximumDeltaTime));
                transform.LookAt(Target);
            }
            else
            {
                //animator.SetBool("ItsWalking", false);
            }

            if(FirstMove == true)
            {
                animator.SetBool("ItsWalking", true);
                //rotateToPosition(targetLastPosition);
                //Enemy.Translate(Vector3.forward * 6.5f * Time.deltaTime);

            }
        }
        void rotateToPosition(Vector3 targetPosition)
        {
            var targetRotation = Quaternion.LookRotation(targetPosition - Enemy.position);

            // Smoothly rotate towards the target point.
            Enemy.rotation = Quaternion.Slerp(Enemy.rotation, targetRotation, 6.5f * Time.deltaTime);
        }

    }

}
