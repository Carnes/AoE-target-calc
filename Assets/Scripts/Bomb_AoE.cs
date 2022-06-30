using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AoeExample
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class Bomb_AoE : MonoBehaviour
    {
        [Range(1f, 20f)]
        public float ExplosionRadius;
        [Range(1f, 20f)]
        public float PhysicsPush;
        [Range(1f, 20f)]
        public float PhysicsPushUpwards;
        
        private void OnCollisionEnter(Collision other)
        {
            Explode();
        }

        [ContextMenu("Explode")]
        public void Explode()
        {
            var targets = GetTargets();
            
            foreach(var target in targets)
                target.Hit();

            PhysicsExplosion();
            
            Destroy(gameObject);
        }

        protected virtual void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, ExplosionRadius);
        }

        protected virtual void PhysicsExplosion()
        {
            var colliders = Physics.OverlapSphere(transform.position, ExplosionRadius);
            foreach (var collider in colliders)
            {
                var rb = collider.GetComponent<Rigidbody>();
                if (rb != null)
                    rb.AddExplosionForce(PhysicsPush * 1000, transform.position, ExplosionRadius, PhysicsPushUpwards);
            }            
        }

        protected virtual List<Target> GetTargets()
        {
            var targets = new List<Target>();
            var colliders = Physics.OverlapSphere(transform.position, ExplosionRadius);
            foreach (var collider in colliders)
            {
                var target = collider.GetComponent<Target>();
                if(target != null)
                    targets.Add(target);
            }

            return targets;
        }

    }
}