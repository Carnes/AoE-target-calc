using System;
using System.Collections.Generic;
using UnityEngine;

namespace AoeExample
{
    public class Bomb_AoE_Angle : Bomb_AoE
    {
        [Range(45f, 180f)]
        public float AngleYdegrees;
        
        protected override void PhysicsExplosion()
        {
            // no op because the physics would have to be applied directionally
        }

        protected override void OnDrawGizmos()
        {
            
            Gizmos.color = Color.magenta;
            Gizmos.DrawRay(transform.position, transform.forward);
            Gizmos.matrix = Matrix4x4.TRS( transform.position, transform.rotation, Vector3.one );
            Gizmos.DrawFrustum( Vector3.zero, 90f, ExplosionRadius, 0,  1.0f);
        }

        protected override List<Target> GetTargets()
        {
            var targets = new List<Target>();
            var targetsInRange = base.GetTargets();
            
            foreach (var target in targetsInRange)
            {
                if(IsTargetInAngle(target))
                    targets.Add(target);
            }

            return targets;
        }

        private bool IsTargetInAngle(Target target)
        {
            var directionGlobal = (target.transform.position - transform.position).normalized;
            var y = Vector3.Angle(directionGlobal, transform.forward);
            
            if (Math.Abs(y) < AngleYdegrees)
            {
                Debug.Log($"Bomb({AngleYdegrees}) can hit {target.name} at {y} degrees");
                Debug.DrawRay(transform.position, directionGlobal * ExplosionRadius, Color.red, 3f);
                return true;
            }
            
            Debug.DrawRay(transform.position, directionGlobal * ExplosionRadius, Color.white, 1.5f);
            return false;
        }
    }
}