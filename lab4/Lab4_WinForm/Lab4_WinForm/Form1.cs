using Lab4_WinForm.Proxy;
using Lab4_WinForm.SimplexService;
using System.Windows.Forms;

namespace Lab4_WinForm
{
    public partial class Form1 : Form
    {
        private readonly SimplexSoapClient _simplexClient;
        private readonly Simplex _simplexWsdl;

        public Form1()
        {
            InitializeComponent();
            _simplexClient = new SimplexSoapClient();
            _simplexWsdl = new Simplex();
        }

        private void Request_btn_Click(object sender, System.EventArgs e)
        {
            response_text.Text = string.Empty;

            var a1s = a1_s.Text;
            var a2s = a2_s.Text;

            if (string.IsNullOrWhiteSpace(a1s) ||
                string.IsNullOrWhiteSpace(a2s) ||
                !int.TryParse(a1_k.Text, out var a1k) || 
                !int.TryParse(a2_k.Text, out var a2k) || 
                !float.TryParse(a1_f.Text, out var a1f) || 
                !float.TryParse(a2_f.Text, out var a2f))
            {
                response_text.Text = "Invalid parameters";
                return;
            }

            var response = _simplexClient.Sum(
                new SimplexService.A { S = a1s, K = a1k, F = a1f },
                new SimplexService.A { S = a2s, K = a2k, F = a2f });

            response_text.Text += $"VS Generated: [ S = {response.S}, K = {response.K}, F = {response.F} ]\r\n\r\n";
            response_text.Text += $"WSDL Generated: [ Add = {_simplexWsdl.Add(a1k, a2k)} ]\r\n\r\n";
            response_text.Text += $"WSDL Generated: [ Concat = {_simplexWsdl.Concat(a1s, a2f)} ]";
        }
    }
}
