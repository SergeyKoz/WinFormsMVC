using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace WinFormsMVC
{
    public class Router
    {
        private static Router instance;

        private Dictionary<string, object> _controllers;

        private Router()
        {
            List<Type> controllersList = Router.ControllersList(Assembly.GetExecutingAssembly());
            WinFormsMVC.RouteAttribute attribute;
            _controllers = new Dictionary<string, object>();
            foreach (Type itemType in controllersList)
            {
                attribute = (WinFormsMVC.RouteAttribute)Attribute.GetCustomAttribute(itemType, typeof(WinFormsMVC.RouteAttribute));
                object instance = Activator.CreateInstance(itemType);
                _controllers.Add(attribute.Route, instance);                
            }
        }        

        public static Router GetInstance()
        {
            if (instance == null)
            {
                instance = new Router();
            }
            return instance;
        }

        public static object Run(string route, params ActionParameter[] args)
        {
            string[] parts = route.Split('/');
            string action = parts.Last();

            char[] a = action.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            action = new string(a);

            string controller = route.Substring(0, route.Length - action.Length - 1);

            object instance = GetInstance()._controllers[controller];
            MethodInfo method = instance.GetType().GetMethod(action + "Action");
            return method.Invoke(instance, args);
        }

        public static List<Type> ControllersList(Assembly assembly)
        {
            List<Type> types = new List<Type>();
            foreach (Type type in assembly.GetTypes())
            {
                if (Attribute.IsDefined(type, typeof(WinFormsMVC.RouteAttribute)))
                { 
                    types.Add(type);
                }
            }
            return types;
        }

        public void AddController(string route, Type type)
        {
            object instance = Activator.CreateInstance(type);
            _controllers.Add(route, instance);
        }
    }
}