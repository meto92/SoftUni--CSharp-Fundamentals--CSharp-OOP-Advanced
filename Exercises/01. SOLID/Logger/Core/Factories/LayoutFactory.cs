using System;
using System.Linq;
using System.Reflection;

public class LayoutFactory
{
    private const string LayoutSuffix = "Layout";

    public ILayout CreateLayout(string type)
    {
        Type layoutType = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.IsClass &&
                t.Name.EndsWith(LayoutSuffix) &&
                t.Name == type);

        if (layoutType == null)
        {
            throw new ArgumentNullException(nameof(layoutType), "Unknown layout type");
        }

        ILayout layout = Activator.CreateInstance(layoutType) as ILayout;

        return layout;
    }
}