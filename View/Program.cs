using System;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;
using Contracts.StorageContracts;
using Contracts.BusinessLogicContracts;
using BusinessLogic.BusinessLogic;
using DatabaseImplement.Implements;

namespace View
{
    static class Program
    {
        private static IUnityContainer container = null;

        public static IUnityContainer Container
        {
            get
            {
                if (container == null)
                {
                    container = BuildUnityContainer();
                }
                return container;
            }
        }


        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Container.Resolve<FormMain>());
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();

            currentContainer.RegisterType<IEmployeeStorage, EmployeeStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IDepartmentStorage, DepartmentStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IPostStorage, PostStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IAssignmentStorage, AssignmentStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IFullEmplInfoStorage, FullEmplInfoStorage>(new HierarchicalLifetimeManager());

            currentContainer.RegisterType<IEmployeeLogic, EmployeeLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IDepartmentLogic, DepartmentLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IPostLogic, PostLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IAssignmentLogic, AssignmentLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IFullEmplInfoLogic, FullEmplInfoLogic>(new HierarchicalLifetimeManager());

            return currentContainer;
        }
    }
}
