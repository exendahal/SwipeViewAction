using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SwipeAction
{
    public partial class MainPage : ContentPage
    {
        readonly IList<CartModel> source;

        public ICommand TapCommandEdit { get; set; }
        public ICommand TapCommandDel { get; set; }
        public ObservableCollection<CartModel> itemPreview { get; private set; }
        public MainPage()
        {
            BindingContext = this;
            InitializeComponent();
            source = new List<CartModel>();

            TapCommandEdit = new Command<CartModel>(async items =>
            {

                App.Current.MainPage.Navigation.PushModalAsync(new EditPage(items));
            });

            TapCommandDel = new Command<CartModel>(async items =>
            {
                itemPreview.Remove(items);

            });
            CreateItemCollection();

            MessagingCenter.Subscribe<EditPage, CartModel>(this, "EditData",
                 (page, data) =>
                 {
                     CartModel dataEdit = itemPreview.Where(dat => dat.id == data.id).FirstOrDefault();

                     int newIdex = itemPreview.IndexOf(dataEdit);
                     itemPreview.Remove(dataEdit);

                     itemPreview.Add(data);
                     int oldIndex = itemPreview.IndexOf(data);

                     itemPreview.Move(oldIndex, newIdex);
                 });
        }
       

        void CreateItemCollection()
        {
            source.Add(new CartModel
            {
                id = 1,
                image = "icon",
                name = "Tag Heuer Wristwatch",
                price = "$2400",
                numbers = 1
            });
            source.Add(new CartModel
            {
                id = 2,
                image = "icon",
                name = "BeoPlay Speaker",
                price = "$4400",
                numbers = 1
            });
            source.Add(new CartModel
            {
                id = 3,
                image = "icon",
                name = "Electric Kettle",
                price = "$400",
                numbers = 1
            });
            source.Add(new CartModel
            {
                id = 4,
                image = "icon",
                name = "Bang & Olufsen Case",
                price = "$4500",
                numbers = 1
            });
            itemPreview = new ObservableCollection<CartModel>(source);
            collectionView.ItemsSource = itemPreview;
        }

       
    }

    public class CartModel
    {
        public int id { get; set; }
        public string image { get; set; }
        public string name { get; set; }
        public string price { get; set; }
        public int numbers { get; set; }
    }
}
