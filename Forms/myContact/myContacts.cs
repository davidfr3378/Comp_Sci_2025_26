namespace myContact;
using Microsoft.AspNetCore.Components.WebView.WindowsForms;

namespace myContact
{
    public partial class myContacts : Form
    {
        public myContacts()
        {
            InitializeComponent();

            var bwv = new BlazorWebView()
            {
                Dock = DockStyle.Fill,
                HostPage = "wwwroot/index.html",
                Services = Startup.Services!,
                StartPath = "/"
            };

            bwv.RootComponents.Add<Main>("#app");
            Controls.Add(bwv);
        }
    }
}
