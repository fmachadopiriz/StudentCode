using System.Collections.Generic;

namespace Proyecto.StudentsCode
{
    public interface IUIElement
    {
        string Name { get; set; }

        IUIElement Parent { get; set; }

        IList<IUIElement> Children { get; }
    }
}