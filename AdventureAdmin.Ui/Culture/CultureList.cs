using AdventureAdmin.Ui.Services;
using Aplicada1.Core;
using Microsoft.Extensions.DependencyInjection;
using CultureModel = AdventureAdmin.Data.Models.Culture;
namespace AdventureAdmin.Ui.Culture
{
    public partial class CultureList : Form
    {
        public CultureList()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Culture = Program.ServiceProvider.GetRequiredService<CultureForm>();
            Culture.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un registro para modificar.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var entidad = (CultureModel)dataGridView1.CurrentRow.DataBoundItem;

            var form = ActivatorUtilities.CreateInstance<CultureForm>(
                Program.ServiceProvider, entidad);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                _ = LoadDataAsync();
            }
        }

        private async Task LoadDataAsync()
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un registro para modificar.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var entidad = (CultureService)dataGridView1.CurrentRow.DataBoundItem;

            var form = ActivatorUtilities.CreateInstance<CultureForm>(
                Program.ServiceProvider, entidad);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                _ = LoadDataAsync();
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un registro para eliminar.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var entidad = (CultureModel)dataGridView1.CurrentRow.DataBoundItem;

            var result = MessageBox.Show(
                $"¿Desea eliminar la cultura '{entidad.CultureId}'?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _ = EliminarAsync(entidad.CultureId);
            }
        }

        private async Task EliminarAsync(string id)
        {
            try
            {
                var success = await Program.ServiceProvider.GetRequiredService<CultureService>().Eliminar(id);

                if (success)
                {
                    MessageBox.Show("Departamento eliminado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataAsync();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el departamento.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
