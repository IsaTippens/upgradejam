using System.Collections.Generic;
using System.Collections;


namespace upgradejam;

public class ManagerList : IEnumerable<IManager>
{
    private List<IManager> _managers = new List<IManager>();

    public T Add<T>() where T : IManager, new()
    {
        return Add(new T());
    }
    public T Add<T>(T manager) where T : IManager
    {
        _managers.Add(manager);
        return manager;
    }

    public void Remove<T>(T manager) where T : IManager
    {
        _managers.Remove(manager);
    }

    public IEnumerator<IManager> GetEnumerator()
    {
        return _managers.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _managers.GetEnumerator();
    }

    public void Initialize()
    {
        foreach (IManager manager in _managers)
        {
            manager.Initialize();
        }
    }

    public void Update()
    {
        foreach (IManager manager in _managers)
        {
            manager.Update();
        }
    }

    public void Render(SpriteBatch batch)
    {
        foreach (IManager manager in _managers)
        {
            if (manager.Drawable)
                manager.Render(batch);
        }
    }
}