

namespace appAddress.ViewModels
{
    using appAddress.Models;
    using appAddress.Services;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;

    public class BookViewModel: BaseViewModel
    {
        #region Attributes
        ApiService apiService;
        private ObservableCollection<book> boook;
        #endregion
        #region Properties
        public ObservableCollection<book> boooks
        {
            get { return this.boooks; }
            set { SetValue(ref this.boook, value); }
        }
        #endregion
        #region Constructor
        public BookViewModel()
        {
            this.apiService = new ApiService();
            this.LoadBooks();
        }
        #endregion
        #region Method
        private async void LoadBooks()
        {
            var connection = await apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Internet error",
                    connection.Message,
                    "Accept"
                    );
                return;
            }
            var response = await apiService.GetList<book>(
                "http://localhost:50086/",
                "api/",
                "Books"
                );
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Service Book Error",
                    response.Message,
                    "Accept");
                return;
            }
            MainViewModel mainViewModel = MainViewModel.GetInstance();
            mainViewModel.ListBook = (List<book>)response.Result;
            this.boooks = new ObservableCollection<book>(this.ToBookcollect());
        }

        private IEnumerable<book> ToBookcollect()
        {
            ObservableCollection<book> collect = new ObservableCollection<book>();
            MainViewModel main = MainViewModel.GetInstance();
            foreach(var lista in main.ListBook)
            {
                book book = new book();
                book.BookID = lista.BookID;
                book.Name = lista.Name;
                book.type = lista.type;
                book.Contact = lista.Contact;
                collect.Add(book);
            }
            return (collect);
        }
        #endregion
    }
}