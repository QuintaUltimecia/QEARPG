using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace QuintaEssenta.Library
{
    public class BaseBehaviour : MonoBehaviour
    {
        protected virtual void Awake()
        {
            Inject();
            InjectGetComponent();
        }

        private void Inject()
        {
            var container = FindObjectOfType<DIContainer>();
            var fields = GetFieldsWithAttribute(typeof(InjectAttribute));

            foreach (var field in fields)
            {
                var type = field.FieldType;
                var component = new UnityEngine.Object();

                component = container.GetInjectComponent(type);

                if (component == null)
                {
                    Debug.LogWarning($"Inject typeof(" + type.Name + ") in gameObject '" + gameObject.name + "' is null");
                    continue;
                }

                field.SetValue(this, component);
            }
        }

        private void InjectGetComponent()
        {
            var fields = GetFieldsWithAttribute(typeof(GetComponentAttribute));

            foreach (var field in fields)
            {
                var type = field.FieldType;
                var component = new UnityEngine.Object();

                if (type == gameObject.GetType())
                    component = gameObject;
                else component = GetComponent(type);

                if (component == null)
                {
                    Debug.LogWarning($"GetComponent typeof(" + type.Name + ") in gameObject '" + gameObject.name + "' is null");
                    continue;
                }

                field.SetValue(this, component);
            }
        }

        private IEnumerable<FieldInfo> GetFieldsWithAttribute(Type attributeType)
        {
            var fields = GetType()
                .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(field => field.GetCustomAttributes(attributeType, true).FirstOrDefault() != null);

            return fields;
        }
    }
}
