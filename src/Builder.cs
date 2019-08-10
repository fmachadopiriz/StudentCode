using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Proyecto.StudentsCode
{
    public class Builder
    {
        private abstract class UIElement
        {
            internal abstract void Visit(IMainViewAdapter adapter);
        }

        private class Background : UIElement, IUIElement
        {
            public string Name { get; set; }

            public IUIElement Parent { get; set; }

            public IList<IUIElement> Children { get; } = new List<IUIElement>();

            internal Background()
            {
                this.Parent = null;
                this.Children.Add(new Button(this));
                this.Name = "Background1";
            }

            internal override void Visit(IMainViewAdapter adapter)
            {
                adapter.ChangeLayout(Layout.ContentSizeFitter);
            }
        }

        private class Button : UIElement, IUIElement
        {
            public string Name { get; set; }

            public IUIElement Parent { get; set; }

            public IList<IUIElement> Children { get; }

            internal Button(IUIElement parent)
            {
                this.Parent = parent;
                this.Name = "Button1";
            }

            internal override void Visit(IMainViewAdapter adapter)
            {
                adapter.CreateButton(400, 180, 160, 50, "#123456", this.OnClick);
            }

            internal void OnClick()
            {
                Debug.WriteLine($"Button {this.Name} clicked!");
            }
        }

        public IUIElement GetRootElement()
        {
            return new Background();
        }

        public void CreateElement(IUIElement element, IMainViewAdapter adapter)
        {
            (element as UIElement).Visit(adapter);
        }
    }
}
