using FEC_APP.Models;
using FEC_APP.Services;
using FEC_APP.Views.Docente;
using FEC_APP.Views.Popup;
using PropertyChanged;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FEC_APP.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class NovoDocenteViewModel
    {
        public long Id { get; set; }
        public string NomeCompleto { get; set; }

        public string Foto { get; set; }

        public string CEP { get; set; }

        public string Endereco { get; set; }

        public string Numero { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string Telefone1 { get; set; }

        public string Telefone2 { get; set; }

        public long UsuarioId { get; set; }
        
        public bool ErrorNomeCompleto { get; set; } = false;

        public string Titulo { get; set; } = "";
        private Docente _docente = new Docente();

        public ICommand RegistrarDocente => new Command(async () => await RegistrarDocenteAsync());

        private async Task RegistrarDocenteAsync()
        {
            Popup.ExibirLoading();
            try
            {
                this.ErrorNomeCompleto = (string.IsNullOrWhiteSpace(this.NomeCompleto));

                if (ErrorNomeCompleto)
                {
                    Toast.Show("Informe todos os campos obrigatórios!", Toast.ToastType.Error);
                }
                else
                {
  
                    this._docente.NomeCompleto = this.NomeCompleto;

                    this._docente.Foto = this.Foto;

                    this._docente.CEP = this.CEP;

                     this._docente.Endereco = this.Endereco;

                    this._docente.Numero = this.Numero;

                    this._docente.Bairro = this.Bairro;

                    this._docente.Cidade = this.Cidade;

                    this._docente.Estado = this.Estado;

                    this._docente.Telefone1 = this.Telefone1;

                    this._docente.Telefone2 = this.Telefone2;

                    Toast.Show("Docente registrada com sucesso", Toast.ToastType.Success);

                    DocenteService serviceDocente = new DocenteService();
                    if (this._docente.Id > 0)
                        await serviceDocente.Alterar(this._docente);
                    else
                        await serviceDocente.Criar(this._docente);
                }
            }
            catch (Exception)
            {

                Toast.Show("Falha ao registrar bomba", Toast.ToastType.Error);
            }
            finally
            {
                Popup.FecharLoading();
                
            }
        }

        public NovoDocenteViewModel(Docente docente = null)
        {        
            if (!(docente == null))
            {                            
                _docente = docente;
                //Titulo = "Editar Docente";
            }
            CargaInicial();
        }

        public async void CargaInicial()
        {

            try
            {
                PopupAguarde aguarde = new PopupAguarde();
                await NavigationExtension.PushPopupAsync(null, aguarde);
                this.Titulo = "Novo Docente";

                if (_docente.Id >0)
                {
                    this.Titulo = "Editar Docente";

                    this.NomeCompleto = _docente.NomeCompleto;

                    this.Foto = _docente.Foto;

                    this.CEP = _docente.CEP;

                    this.Endereco = _docente.Endereco;

                    this.Numero = _docente.Numero;

                    this.Bairro = _docente.Bairro;

                    this.Cidade = _docente.Cidade;

                    this.Estado = _docente.Estado;

                    this.Telefone1 = _docente.Telefone1;

                    this.Telefone2 = _docente.Telefone2;

                    this.UsuarioId = _docente.UsuarioId;
                }

                await NavigationExtension.RemovePopupPageAsync(null, aguarde);

            }
            catch (Exception ex)
            {
                Toast.Show($"Falha ao carregar Docente. {ex.Message}");
            }
        }
        


    }
}
