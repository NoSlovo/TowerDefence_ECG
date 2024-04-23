using System;
using System.Collections.Generic;

public class ServiceLocator : IServiceLocator
{
    private Dictionary<Type, IService> _services = new Dictionary<Type, IService>();
        
    public static ServiceLocator Instance;

    private ServiceLocator()
    {
    }

    public static void Init()
    {
        Instance = Instance != null ? Instance : new ServiceLocator();
    }

    public void RegisterService<T>(IService service) where T : IService =>
        _services.Add(typeof(T), service);


    public T GetService<T>() where T : IService => (T)_services[typeof(T)];
}

public interface IService
{
    
}