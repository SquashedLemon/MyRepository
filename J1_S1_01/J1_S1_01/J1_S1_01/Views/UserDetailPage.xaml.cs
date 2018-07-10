using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using J1_S1_01.Models;
using J1_S1_01.ViewModels;

namespace J1_S1_01.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserDetailPage : ContentPage
	{
		public UserDetailPage (UserAccounts _userAccounts)
		{
			InitializeComponent ();

            this.BindingContext = new UserDetailPageViewModel(_userAccounts);
		}
	}
}