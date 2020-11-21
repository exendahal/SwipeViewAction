using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SwipeAction
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditPage : ContentPage
    {
        CartModel _model;
        public EditPage(CartModel cartModel)
        {
            InitializeComponent();
            _model = cartModel;
            this.BindingContext = _model;
        }
        private void Button_Clicked_update(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "EditData", _model);
            Navigation.PopModalAsync();
        }
    }
}