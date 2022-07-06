using ByteBank.Core.Model;
using ByteBank.Core.Repository;
using ByteBank.Core.Service;
using ByteBank.View.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ByteBank.View
{
    public partial class MainWindow : Window
    {
        private readonly ContaClienteRepository r_Repositorio;
        private readonly ContaClienteService r_Servico;
        private CancellationTokenSource _cts;

        public MainWindow()
        {
            InitializeComponent();

            r_Repositorio = new ContaClienteRepository();
            r_Servico = new ContaClienteService();
        }

        private async void BtnProcessar_Click(object sender, RoutedEventArgs e)
        {
            BtnProcessar.IsEnabled = false;

            _cts = new CancellationTokenSource();

            var contas = r_Repositorio.GetContaClientes();

            PgsProgressp.Maximum = contas.Count();

            LimpaView();

            var inicio = DateTime.Now;

            BtnCancel.IsEnabled = true;

            var progress = new Progress<string>(str => PgsProgressp.Value++);

            try
            {
                var resultado = await ConsolidaContas(contas, progress, _cts.Token);

                var fim = DateTime.Now;
                AtualizarView(resultado, fim - inicio);
            }
            catch (OperationCanceledException)
            {
                TxtTempo.Text = "Operação cancelada pelo usuário";
            }
            finally
            {
                BtnProcessar.IsEnabled = true;
                BtnCancel.IsEnabled = false;
            }



        }
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            BtnCancel.IsEnabled = false;
            _cts.Cancel();
        }

        private async Task<string[]> ConsolidaContas(IEnumerable<ContaCliente> contas, IProgress<string> reportadorProgresso, CancellationToken ct)
        {
            var tasks = contas.Select(conta =>
                Task.Run(() =>
                {
                    ct.ThrowIfCancellationRequested();
                    var resultadoCosolidacao = r_Servico.ConsolidarMovimentacao(conta, ct);

                    reportadorProgresso.Report(resultadoCosolidacao);

                    ct.ThrowIfCancellationRequested();

                    return resultadoCosolidacao;

                }, ct)
                );


            return await Task.WhenAll(tasks);
        }


        private void LimpaView()
        {
            LstResultados.ItemsSource = null;
            TxtTempo.Text = null;
            PgsProgressp.Value = 0;


        }
        private void AtualizarView(IEnumerable<String> result, TimeSpan elapsedTime)
        {
            var tempoDecorrido = $"{elapsedTime.Seconds}.{elapsedTime.Milliseconds} segundos!";
            var mensagem = $"Processamento de {result.Count()} clientes em {tempoDecorrido}";

            LstResultados.ItemsSource = result;
            TxtTempo.Text = mensagem;
        }


    }
}
