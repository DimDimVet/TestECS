using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class TransformSystem : ComponentSystem
{
    //
    private Vector3 vector;

    //создадим переменую результата запроса сущностей - обязательно для ComponentSystem
    private EntityQuery entityQuery;
    protected override void OnCreate()//создадим переменную ентити - обязательно для ComponentSystem
    {
        entityQuery = GetEntityQuery(ComponentType.ReadOnly<TransformData>());
        //могут быть варианты ComponentType.ReadOnly<структура>()
        //
        vector = new Vector3 (0.01f,0.01f,0.01f );
    }

    protected override void OnUpdate()//проверяем по каждому фрейму ентити - обязательно для ComponentSystem
=>
        //        //опросим ВСЕ ентити, которые попадут под условия - работаем
        Entities.With(entityQuery).ForEach
        (
        (Entity entity, TransformComponent transformData) =>
        //переменная ентити, ref исполняемы скрипт компонента
                {
                    //в случае отобрать найденные ентити по наличию интрефеса
                    if (transformData is ITransformComponent ability)
                    {
                        vector.z= vector.z+0.01f;
                        vector.x = vector.x + 0.01f;
                        ability.ModeTransform(vector);// и обрабатываем какие то методы из компонента
                    }
                }
                );
}
