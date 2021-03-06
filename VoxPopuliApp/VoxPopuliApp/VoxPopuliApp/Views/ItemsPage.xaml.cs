﻿using System;
using System.Diagnostics;
using VoxPopuliApp.Models;
using VoxPopuliApp.Services;
using VoxPopuliApp.ViewModels;

using Xamarin.Forms;

namespace VoxPopuliApp.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ItemsViewModel();
            MessagingCenter.Subscribe<CampaniaDataStore, string>(this, "ErrInsert", async (sender, arg) =>
            {
                await DisplayAlert("Aviso", arg, "OK");
                await Navigation.PopAsync();

            });
            MessagingCenter.Subscribe<ItemDetailViewModel, string>(this, "ErrLoad", async (sender, arg) =>
            {
                await DisplayAlert("Aviso", arg, "OK");
                await Navigation.PopAsync();
            });
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Rootobject;
            if (item == null)
                return;
            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewItemPage());
        }

        protected override void OnAppearing()
        {
            try
            {
                base.OnAppearing();

                if (viewModel.Campanias.Count == 0)
                    viewModel.CargaCampaniasCommand.Execute(null);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
