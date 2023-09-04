using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

//Strukture - обязательно для ComponentSystem
public struct TransformData : IComponentData
{
}

//ECS
public class TransformComponent :MonoBehaviour, IConvertGameObjectToEntity, ITransformComponent//укажем ComponentSystem и укажем интерфейс по функционалу компонента и MonoBehaviour чтоб цеплять к объекту
{
    private Transform obj;
    private void Awake()
    {
        obj = this.gameObject.transform;
    }
    public Vector3 ModeTransform(Vector3 vector)
    {
        obj.position = vector;
        return vector;
    }

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    //в менеджер ентити EntityManager добавим структуру
    {

        dstManager.AddComponentData(entity, new TransformData());//добавим в сущность стурктуру с любыми датами;
                                                                 //или с добавление\изменением данных в структуре
                                                                 //entityManager.AddComponentData(entity, new MoveData()//добавим в сущность стурктуру режима движения(скорость)
                                                                 //{
                                                                 //    MoveSpeed = Speed / 100,
                                                                 //});
                                                                 //или с проверкой условий наличия интерфеса, как правило если используем в качестве компонента MonoBehaviour в подключаемых скриптах
                                                                 //public MonoBehaviour ShootAction;
                                                                 //if (ShootAction != null & ShootAction is IShootComponent)
                                                                 //{
                                                                 //    entityManager.AddComponentData(entity, new ShootData());//добавим в сущность стурктуру ввода стрельбы
                                                                 //}
    }
}
