using Student.Todo.Data;
using System.Configuration;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.Mvc5;

namespace Student.MvcTodo
{
    public static class UnityConfig
    {
        public static IUnityContainer Container { get; private set; }

        public static void RegisterComponents()
        {

            Container = new UnityContainer();

            Container.RegisterType<AppDbContext>(
                new HierarchicalLifetimeManager(),
                new InjectionConstructor(
                    ConfigurationManager.ConnectionStrings["TodoTasks"].ConnectionString
                )
            );

            Container.RegisterType<ITaskService, TaskServiceEF>(
                new HierarchicalLifetimeManager()
            );

            DependencyResolver.SetResolver(
                new UnityDependencyResolver(Container)
            );
        }
    }
}