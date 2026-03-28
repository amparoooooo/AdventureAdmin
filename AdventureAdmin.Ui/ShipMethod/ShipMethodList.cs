using AdventureAdmin.Ui.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AdventureAdmin.Ui.ShipMethod
{
    public partial class ShipMethodList : Form
    {
        private readonly ShipMethodService _service;
        public ShipMethodList(ShipMethodService service)
        {
            InitializeComponent();
            _service = service;
        }

        private async void ShipMethodList_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                var shipMethods = await _service.GetList(c => true);
                ShipMethodDataView.DataSource = shipMethods;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private async void nuevoButton_Click(object sender, EventArgs e)
        {
            var shipMethodForm = Program.ServiceProvider.GetRequiredService<ShipMethodForm>();
            shipMethodForm.ShowDialog();
            await LoadDataAsync();
        }
    }
}
