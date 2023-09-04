using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class TransformSystem : ComponentSystem
{
    //
    private Vector3 vector;

    //�������� ��������� ���������� ������� ��������� - ����������� ��� ComponentSystem
    private EntityQuery entityQuery;
    protected override void OnCreate()//�������� ���������� ������ - ����������� ��� ComponentSystem
    {
        entityQuery = GetEntityQuery(ComponentType.ReadOnly<TransformData>());
        //����� ���� �������� ComponentType.ReadOnly<���������>()
        //
        vector = new Vector3 (0.01f,0.01f,0.01f );
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
                        vector.z= vector.z+0.01f;
                        vector.x = vector.x + 0.01f;
                        ability.ModeTransform(vector);// � ������������ ����� �� ������ �� ����������
                    }
                }
                );
}
