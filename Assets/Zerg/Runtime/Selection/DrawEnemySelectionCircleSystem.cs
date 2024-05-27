using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace ProjectDawn.Navigation.Sample.Zerg
{
    [RequireMatchingQueriesForUpdate]
    [UpdateInGroup(typeof(PresentationSystemGroup))]
    public partial class DrawEnemySelectionCircleSystem : SystemBase
    {
        SelectionCircle m_SelectionCircle;

        protected override void OnCreate()
        {
            m_SelectionCircle = GameObject.FindObjectOfType<SelectionCircle>(true);
        }

        protected override void OnUpdate()
        {
            if (m_SelectionCircle == null)
                return;

            Entities.ForEach((in UnitFollow unitFollow) =>
            {
                if (unitFollow.Target != Entity.Null)
                {
                    var shapeLookup = GetComponentLookup<AgentShape>(true);
                    var transformLookup = GetComponentLookup<LocalTransform>(true);

                    if (shapeLookup.TryGetComponent(unitFollow.Target, out AgentShape shape) && transformLookup.TryGetComponent(unitFollow.Target, out LocalTransform transform))
                    {
                        Debug.Log($"unitFollow.Target:{unitFollow.Target}");
                        m_SelectionCircle.DrawEnemy(transform.Position, shape.Radius * 2.5f);
                    }
                }
                //m_LifeBar.Draw(transform.Position, life.Life / life.MaxLife, (int)(shape.Radius / 0.2f), shape.Radius, shape.Height);

            }).WithoutBurst().Run();

            //var unitFollow = GetComponentLookup<UnitFollow>(true);

            //if (!unitFollow.TryGetComponent(unitFollow.Target, out AgentShape shape))
            //{
            //    return;
            //}

            //var shapeLookup = GetComponentLookup<AgentShape>(true);
            //var transformLookup = GetComponentLookup<LocalTransform>(true);

            //Dependency.Complete();

            ////foreach (var entity in selection.SelectedEntities)
            ////{
            ////    if (!shapeLookup.TryGetComponent(entity, out AgentShape shape))
            ////        continue;
            ////    if (!transformLookup.TryGetComponent(entity, out LocalTransform transform))
            ////        continue;
            ////    m_SelectionCircle.Draw(transform.Position, shape.Radius * 2.5f);
            ////}
            //if (!shapeLookup.TryGetComponent(unitFollow.Target, out AgentShape shape))
            //{
            //    return;
            //}
            //if (!transformLookup.TryGetComponent(unitFollow.Target, out LocalTransform transform))
            //{
            //    return;
            //}

            //m_SelectionCircle.Draw(transform.Position, shape.Radius * 2.5f);
        }
    }
}
