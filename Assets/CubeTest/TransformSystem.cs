using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class TransformSystem : ComponentSystem
{
    //создадим переменую результата запроса сущностей - обязательно для ComponentSystem
    private EntityQuery entityQuery;
    protected override void OnCreate()//создадим переменную ентити - обязательно для ComponentSystem
    {
        entityQuery = GetEntityQuery(ComponentType.ReadOnly<TransformData>());
        //могут быть варианты ComponentType.ReadOnly<структура>()
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

                        ability.ModeTransform();// и обрабатываем какие то методы из компонента
                    }
                }
                );
}
