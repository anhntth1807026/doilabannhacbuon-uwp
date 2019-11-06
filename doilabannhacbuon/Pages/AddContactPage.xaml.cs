using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using doilabannhacbuon.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace doilabannhacbuon.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddContactPage : Page
    {
        private AddContactModel contactModel;
        public AddContactPage()
        {
            this.InitializeComponent();
            this.contactModel = new AddContactModel();
        }

        private void ButtonClickAdd_Click(object sender, RoutedEventArgs e)
        {
            Entity.UserContact contact = new Entity.UserContact()
            {
                Name = name.Text,
                Phone_Number = phone_number.Text
            };
            contactModel.Insert(contact);
        }

        private void ButtonSearch_OnClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SearchContact));
        }
    }
}
