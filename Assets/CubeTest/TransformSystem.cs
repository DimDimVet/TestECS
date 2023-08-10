using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class TransformSystem : ComponentSystem
{
    //�������� ��������� ���������� ������� ��������� - ����������� ��� ComponentSystem
    private EntityQuery entityQuery;
    protected override void OnCreate()//�������� ���������� ������ - ����������� ��� ComponentSystem
    {
        entityQuery = GetEntityQuery(ComponentType.ReadOnly<TransformData>());
        //����� ���� �������� ComponentType.ReadOnly<���������>()
    }

    protected override void OnUpdate()//��������� �� ������� ������ ������ - ����������� ��� ComponentSystem
=>
        //        //������� ��� ������, ������� ������� ��� ������� - ��������
        Entities.With(entityQuery).ForEach
        (
        (Entity entity, TransformComponent transformData) =>
        //���������� ������, ref ���������� ������ ����������
                {
                    //� ������ �������� ��������� ������ �� ������� ���������
                    if (transformData is ITransformComponent ability)
                    {

                        ability.ModeTransform();// � ������������ ����� �� ������ �� ����������
                    }
                }
                );
}
