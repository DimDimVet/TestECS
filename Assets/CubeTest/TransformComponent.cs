using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

//Strukture - ����������� ��� ComponentSystem
public struct TransformData : IComponentData
{
}

//ECS
public class TransformComponent :MonoBehaviour, IConvertGameObjectToEntity, ITransformComponent//������ ComponentSystem � ������ ��������� �� ����������� ���������� � MonoBehaviour ���� ������� � �������
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
    //� �������� ������ EntityManager ������� ���������
    {

        dstManager.AddComponentData(entity, new TransformData());//������� � �������� ��������� � ������ ������;
                                                                 //��� � ����������\���������� ������ � ���������
                                                                 //entityManager.AddComponentData(entity, new MoveData()//������� � �������� ��������� ������ ��������(��������)
                                                                 //{
                                                                 //    MoveSpeed = Speed / 100,
                                                                 //});
                                                                 //��� � ��������� ������� ������� ���������, ��� ������� ���� ���������� � �������� ���������� MonoBehaviour � ������������ ��������
                                                                 //public MonoBehaviour ShootAction;
                                                                 //if (ShootAction != null & ShootAction is IShootComponent)
                                                                 //{
                                                                 //    entityManager.AddComponentData(entity, new ShootData());//������� � �������� ��������� ����� ��������
                                                                 //}
    }
}
