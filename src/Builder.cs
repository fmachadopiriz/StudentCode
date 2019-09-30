//--------------------------------------------------------------------------------
// <copyright file="Builder.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using System;
using Proyecto.Common;

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
            string imageId;

            this.adapter = providedAdapter ?? throw new ArgumentNullException(nameof(providedAdapter));

            this.adapter.ToDoAfterBuild(this.AfterBuildShowFirstPage);

            this.firstPageName = this.adapter.AddPage();

            this.adapter.ChangeLayout(Layout.ContentSizeFitter);

            imageId = this.adapter.CreateImage(-(1024 / 2 - 100 / 2), -(768 / 2 - 100 / 2), 100, 100);
            try
            {
                this.adapter.SetImage(imageId, "color-splash-trail-76686.jpg");
            }
            catch (Exception ex)
            {
                this.adapter.Debug(ex.Message);
            }

            imageId = this.adapter.CreateImage(1024 / 2 - 100 / 2, 768 / 2 - 100 / 2, 100, 100);
            this.adapter.SetImage(imageId, "pexels-photo-1545505.jpeg");

            string sourceCellImageId = this.adapter.CreateDragAndDropSource(50, 180, 100, 200);
            this.adapter.SetImage(sourceCellImageId, "Cell.png");

            string destinationCellImageId = this.adapter.CreateDragAndDropDestination(250, 180, 200, 100);
            this.adapter.SetImage(destinationCellImageId, "Cell.png");

            string itemId = this.adapter.CreateDragAndDropItem(0, 0, 100, 100);
            this.adapter.SetImage(itemId, "Hammer.png");
            this.adapter.AddItemToDragAndDropSource(sourceCellImageId, itemId);

            imageId = this.adapter.CreateImage(40, 100, 100, 100);
            this.adapter.SetImage(imageId, "pexels-photo-1545505.jpeg");

            string buttonId = this.adapter.CreateButton(150, 100, 100, 100, "#09FF0064", this.GoToNextPage);
            this.adapter.SetImage(buttonId, "BlueButton.png");

            this.nextPageName = this.adapter.AddPage();
            this.adapter.ChangeLayout(Layout.Grid);

            buttonId = this.adapter.CreateButton(100, 100, 100, 100, "#BC2FA864", this.GoToFirstPage);
            this.adapter.SetImage(buttonId, "BlueButton.png");
            imageId = this.adapter.CreateImage(40, 100, 100, 100);
            this.adapter.SetImage(imageId, "pexels-photo-1545505.jpeg");
        }

        public void AfterBuildShowFirstPage()
        {
            this.adapter.ShowPage(this.firstPageName);
        }

        private void GoToFirstPage()
        {
            this.adapter.ShowPage(this.firstPageName);
            this.adapter.PlayAudio("Speech On.wav");
        }

        private void GoToNextPage()
        {
            this.adapter.ShowPage(this.nextPageName);
            this.adapter.PlayAudio("Speech Off.wav");
        }

        private void OnClick()
        {
            this.adapter.Debug($"Button clicked!");
            this.adapter.ShowPage("MainPage");
        }
    }
}
