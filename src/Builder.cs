//--------------------------------------------------------------------------------
// <copyright file="Builder.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using System;

namespace Proyecto.StudentsCode
{
    /// <summary>
    /// Una implementación de referencia de <see cref="IBuilder"/> para mostrar su uso.
    /// </summary>
    public class Builder : IBuilder
    {
        private IMainViewAdapter adapter;

        private string firstPageName;

        private string nextPageName;

        /// <summary>
        /// Construye una interfaz de usuario interactiva utilizando un <see cref="IMainViewAdapter"/>.
        /// </summary>
        /// <param name="providedAdapter">Un <see cref="IMainViewAdapter"/> que permite construir una interfaz de usuario
        /// interactiva.</param>
        public void Build(IMainViewAdapter providedAdapter)
        {
            this.adapter = providedAdapter ?? throw new ArgumentNullException(nameof(providedAdapter));

            this.adapter.ToDoAfterBuild(this.AfterBuildShowFirstPage);

            this.firstPageName = this.adapter.AddPage();

            this.adapter.ChangeLayout(Layout.ContentSizeFitter);

            string sourceCellImageId = this.adapter.CreateDragAndDropSource(50, 180, 100, 200);
            this.adapter.SetImage(sourceCellImageId, "Images\\Cell");

            string destinationCellImageId = this.adapter.CreateDragAndDropDestination(250, 180, 200, 100);
            this.adapter.SetImage(destinationCellImageId, "Images\\Cell");

            string itemId = this.adapter.CreateDragAndDropItem(0, 0, 100, 100);
            this.adapter.SetImage(itemId, "Images\\Hammer");
            this.adapter.AddItemToDragAndDropSource(sourceCellImageId, itemId);

            string imageId = this.adapter.CreateImage(40, 100, 100, 100);
            this.adapter.SetImage(imageId, "Images\\BlueButton");

            this.adapter.CreateButton(150, 100, 100, 100, "#09FF0064", this.GoToNextPage);

            this.nextPageName = this.adapter.AddPage();

            this.adapter.CreateButton(100, 100, 100, 100, "#BC2FA864", this.GoToFirstPage);
        }

        private void AfterBuildShowFirstPage()
        {
            this.adapter.ShowPage(this.firstPageName);
        }

        private void GoToFirstPage()
        {
            this.adapter.ShowPage(this.firstPageName);
        }

        private void GoToNextPage()
        {
            this.adapter.ShowPage(this.nextPageName);
        }

        private void OnClick()
        {
            this.adapter.Debug($"Button clicked!");
            this.adapter.ShowPage("MainPage");
        }
    }
}
