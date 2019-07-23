namespace Proyecto.StudentsCode
{
    public interface IDragAndDropItem : IUIElement
    {
        void OnBeginDrag();

        void OnEndDrag();
    }
}